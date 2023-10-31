using System;
using UnityEditor;
using UnityEngine.Audio;
using XIV.Core.Utils;

namespace XIV.XIVEditor.CodeGeneration
{
    public static class AudioMixerConstantsGenerator
    {
        const string CLASS_NAME = "AudioMixerConstants";

        public static string GetClassString()
        {
            var guids = AssetDatabase.FindAssets("t: AudioMixer", new[] { "Assets" });
            
            ClassGenerator generator = new ClassGenerator(CLASS_NAME, classModifier: "static");

            for (var i = 0; i < guids.Length; i++)
            {
                var path = AssetDatabase.GUIDToAssetPath(guids[i]);
                var audioMixer = AssetDatabase.LoadAssetAtPath<AudioMixer>(path);

                var audioMixerClassName = audioMixer.name.Replace(" ", "")
                    .Replace("-", "_")
                    .Replace("/", "_")
                    .Replace("(","")
                    .Replace(")","");
                
                ClassGenerator mixerClass = new ClassGenerator(audioMixerClassName, classModifier: "static", isInnerClass: true);
                
                // https://forum.unity.com/threads/get-list-of-snapshots-and-groups-from-an-audio-mixer.454656/
                Array parameters = (Array)audioMixer.GetType().GetProperty("exposedParameters").GetValue(audioMixer, null);
                AudioMixerGroup[] audioMixerGroups = audioMixer.FindMatchingGroups(string.Empty);

                if (parameters.Length > 0) WriteExposedParamaters(parameters, mixerClass);
                if (audioMixerGroups.Length > 0) WriteMixerGroups(audioMixerGroups, mixerClass);

                generator.AddInnerClass(mixerClass);
            }

            return generator.EndClass();
        }

        static void WriteExposedParamaters(Array parameters, ClassGenerator mixerClass)
        {
            ClassGenerator parametersClass = new ClassGenerator("Parameters", classModifier: "static", isInnerClass: true);
            
            int paramatersLength = parameters.Length;
            string paramaterNames = "";
            for (int j = 0; j < paramatersLength; j++)
            {
                var o = parameters.GetValue(j);

                var propertyType = o.GetType();
                var propertyName = (string)propertyType.GetField("name").GetValue(o);
                var fieldValue = FormatStringFieldValue(propertyName);
                var fieldName = propertyName;

                parametersClass.AddField(fieldName, fieldValue, "string", "const");
                paramaterNames += "\t" + fieldName + "," + Environment.NewLine;
            }

            paramaterNames = FormatArray(paramaterNames);
            parametersClass.AddField("All", paramaterNames, "string[]", "static readonly");
            
            mixerClass.AddInnerClass(parametersClass);
        }

        static void WriteMixerGroups(AudioMixerGroup[] audioMixerGroups, ClassGenerator mixerClass)
        {
            ClassGenerator mixerGroupClass = new ClassGenerator("MixerGroups", classModifier: "static", isInnerClass: true);
            
            int mixerGroupsLength = audioMixerGroups.Length;
            string groupNamesAll = string.Empty;
            for (int j = 0; j < mixerGroupsLength; j++)
            {
                AudioMixerGroup group = audioMixerGroups[j];
                var fieldValue = group.name;
                mixerGroupClass.AddField(fieldValue, FormatStringFieldValue(fieldValue), "string", "static readonly");
                groupNamesAll += "\t" + fieldValue + "," + Environment.NewLine;
            }
            
            groupNamesAll = FormatArray(groupNamesAll);
            mixerGroupClass.AddField("All", groupNamesAll, "string[]", "static readonly");
            
            mixerClass.AddInnerClass(mixerGroupClass);
        }

        static string FormatStringFieldValue(string value) => $"\"{value}\"";

        static string FormatArray(string paramaterNames)
        {
            return Environment.NewLine + "{" + Environment.NewLine + paramaterNames + Environment.NewLine + "}";
        }
    }
}