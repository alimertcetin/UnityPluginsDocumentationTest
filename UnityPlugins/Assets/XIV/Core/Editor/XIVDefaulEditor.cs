using System.Reflection;
using UnityEditor;
using UnityEngine;
using XIV.Core;
using XIV.XIVEditor.Utils;
using Object = UnityEngine.Object;

namespace XIV.XIVEditor
{
    [CustomEditor(typeof(Object), true, isFallback = true), CanEditMultipleObjects]
    public class XIVDefaulEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            // otherwise base.OnInspectorGUI throws NullReferenceException
            if (target == false) return;

            base.OnInspectorGUI();
            
            var methods = ReflectionUtils.GetMethodsHasAttribute<ButtonAttribute>(target.GetType());
            int length = methods.Length;
            for (var i = 0; i < length; i++)
            {
                var method = methods[i];
                var buttonAttribute = method.GetCustomAttribute<ButtonAttribute>();
                var buttonText = string.IsNullOrWhiteSpace(buttonAttribute.label) ? method.Name : buttonAttribute.label;
                if (GUILayout.Button(buttonText))
                {
                    if (buttonAttribute.playModeOnly && Application.isPlaying == false)
                    {
                        Debug.LogWarning( $"\"{buttonText}\" is not allowed in editor mode");
                        continue;
                    }
                    method.Invoke(target, new object[method.GetParameters().Length]);
                }
            }
        }
    }
}