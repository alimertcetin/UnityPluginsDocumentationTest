using System.IO;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using XIV.XIVEditor.CodeGeneration;

namespace XIV.XIVEditor
{
    public static class MenuItems
    {
        public const string BASE_MENU = "XIV Utilities";
        
        public const string CODE_GENERATION_MENU = BASE_MENU + "/Code Generation";
        public const string UPDATE_ALL_CONSTANTS_MENU = CODE_GENERATION_MENU + "/Update All Constants";
        public const string GENERATE_ANIMATION_CONSTANTS_MENU = CODE_GENERATION_MENU + "/Generate Animation Constants";
        public const string GENERATE_PHYSICS_CONSTANTS_MENU = CODE_GENERATION_MENU + "/Generate Physics Constants";
        public const string GENERATE_TAG_CONSTANTS_MENU = CODE_GENERATION_MENU + "/Generate Tag Constants";
        public const string GENERATE_SHADER_CONSTANTS_MENU = CODE_GENERATION_MENU + "/Generate Shader Constants";
        public const string GENERATE_AUDIO_MIXER_CONSTANTS_MENU = CODE_GENERATION_MENU + "/Generate Audio Mixer Constants";

        public const string FRAME_RATE_MENU = BASE_MENU + "/Frame Rate";
        public const string SET_FRAME_RATE_MAX_MENU = FRAME_RATE_MENU + "/Set Max";
        public const string SET_FRAME_RATE_120_MENU = FRAME_RATE_MENU + "/Set 120";
        public const string SET_FRAME_RATE_90_MENU = FRAME_RATE_MENU + "/Set 90";
        public const string SET_FRAME_RATE_60_MENU = FRAME_RATE_MENU + "/Set 60";
        public const string SET_FRAME_RATE_45_MENU = FRAME_RATE_MENU + "/Set 45";
        public const string SET_FRAME_RATE_30_MENU = FRAME_RATE_MENU + "/Set 30";
        public const string SET_FRAME_RATE_15_MENU = FRAME_RATE_MENU + "/Set 15";
        public const string SET_FRAME_RATE_5_MENU = FRAME_RATE_MENU + "/Set 5";
        
        
        public const string FIND_OBJECTS_WITH_MISSING_SCRIPTS = BASE_MENU + "/Find Objects With Missing Scripts";

        [MenuItem(UPDATE_ALL_CONSTANTS_MENU)]
        public static void UpdateAllConstants()
        {
            WriteCodeGeneration(FilePaths.ANIMATION_CONSTANTS_FILE, AnimationConstantsGenerator.GetClassString());
            WriteCodeGeneration(FilePaths.PHYSICS_CONSTANTS_FILE, PhysicsConstantsGenerator.GetClassString());
            WriteCodeGeneration(FilePaths.TAG_CONSTANTS_FILE, TagConstantsGenerator.GetClassString());
            WriteCodeGeneration(FilePaths.SHADER_CONSTANTS_FILE, ShaderConstantsGenerator.GetClassString());
            WriteCodeGeneration(FilePaths.AUDIO_MIXER_CONSTANTS_FILE, AudioMixerConstantsGenerator.GetClassString());
            AssetDatabase.Refresh();
        }

        [MenuItem(GENERATE_ANIMATION_CONSTANTS_MENU)]
        public static void GenerateAnimationConstants()
        {
            WriteCodeGeneration(FilePaths.ANIMATION_CONSTANTS_FILE, AnimationConstantsGenerator.GetClassString());
            AssetDatabase.Refresh();
        }

        [MenuItem(GENERATE_PHYSICS_CONSTANTS_MENU)]
        public static void GeneratePhysicsConstants()
        {
            WriteCodeGeneration(FilePaths.PHYSICS_CONSTANTS_FILE, PhysicsConstantsGenerator.GetClassString());
            AssetDatabase.Refresh();
        }

        [MenuItem(GENERATE_TAG_CONSTANTS_MENU)]
        public static void GenerateTagConstants()
        {
            WriteCodeGeneration(FilePaths.TAG_CONSTANTS_FILE, TagConstantsGenerator.GetClassString());
            AssetDatabase.Refresh();
        }

        [MenuItem(GENERATE_SHADER_CONSTANTS_MENU)]
        public static void GenerateShaderConstants()
        {
            WriteCodeGeneration(FilePaths.SHADER_CONSTANTS_FILE, ShaderConstantsGenerator.GetClassString());
            AssetDatabase.Refresh();
        }

        [MenuItem(GENERATE_AUDIO_MIXER_CONSTANTS_MENU)]
        public static void GenerateAudioMixerConstants()
        {
            WriteCodeGeneration(FilePaths.AUDIO_MIXER_CONSTANTS_FILE, AudioMixerConstantsGenerator.GetClassString());
            AssetDatabase.Refresh();
        }

        static void WriteCodeGeneration(string path, string fileContent)
        {
            if (Directory.Exists(FilePaths.CODE_GENERATION_FOLDER) == false) Directory.CreateDirectory(FilePaths.CODE_GENERATION_FOLDER);
            if (File.Exists(path) == false) File.Create(path).Dispose();
            File.WriteAllText(path, fileContent);
        }

        [MenuItem(SET_FRAME_RATE_MAX_MENU)]
        public static void SetFrameRateMax() => Application.targetFrameRate = int.MaxValue;

        [MenuItem(SET_FRAME_RATE_120_MENU)]
        public static void SetFrameRate120() => Application.targetFrameRate = 120;

        [MenuItem(SET_FRAME_RATE_90_MENU)]
        public static void SetFrameRate90() => Application.targetFrameRate = 90;
        
        [MenuItem(SET_FRAME_RATE_60_MENU)]
        public static void SetFrameRate60() => Application.targetFrameRate = 60;
        
        [MenuItem(SET_FRAME_RATE_45_MENU)]
        public static void SetFrameRate45() => Application.targetFrameRate = 45;
        
        [MenuItem(SET_FRAME_RATE_30_MENU)]
        public static void SetFrameRate30() => Application.targetFrameRate = 30;
        
        [MenuItem(SET_FRAME_RATE_15_MENU)]
        public static void SetFrameRate15() => Application.targetFrameRate = 15;
        
        [MenuItem(SET_FRAME_RATE_5_MENU)]
        public static void SetFrameRate5() => Application.targetFrameRate = 5;
        
        [MenuItem(FIND_OBJECTS_WITH_MISSING_SCRIPTS)]
        public static void FindObjectsWithMissingScripts()
        {
            GameObject[] rootObjects = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();

            List<GameObject> list = UnityEngine.Pool.ListPool<GameObject>.Get();
            foreach (GameObject rootObject in rootObjects)
            {
                FindMissingScriptsRecursive(rootObject, list);
            }

            Selection.objects = list.ToArray();
            
            UnityEngine.Pool.ListPool<GameObject>.Release(list);

            static void FindMissingScriptsRecursive(GameObject gameObject, List<GameObject> list)
            {
                // Check if the game object has any missing scripts
                Component[] components = gameObject.GetComponents<Component>();
                for (int i = 0; i < components.Length; i++)
                {
                    if (components[i] == null)
                    {
                        list.Add(gameObject);
                        Debug.LogWarning($"Missing script found on GameObject '{gameObject.name}'");
                        break;
                    }
                }

                // Recursively check child objects
                for (int i = 0; i < gameObject.transform.childCount; i++)
                {
                    GameObject childObject = gameObject.transform.GetChild(i).gameObject;
                    FindMissingScriptsRecursive(childObject, list);
                }
            }

        }
    }

}
