using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using XIV.UpgradeSystem.Integration;

namespace XIV.UpgradeSystem.Editor
{
    [CustomEditor(typeof(UpgradeSO), true)]
    public class UpgradeSOEditor : UnityEditor.Editor
    {
        // Taken from ReflectionUtils
        static readonly BindingFlags DefaultFieldBindingFlags = 
            BindingFlags.Instance | 
            BindingFlags.NonPublic | 
            BindingFlags.Public | 
            BindingFlags.GetField;
        
        public override void OnInspectorGUI()
        {
            //TODO : Draw Key-Value pair correctly
            //TODO : Ability to new Keys
            DrawDefaultInspector();
            if (GUILayout.Button("Fix Name"))
            {
                var upgradeSO = (UpgradeSO)target;
                GetDefinedName(upgradeSO, out string name, out int instanceID);
                RenameAsset(upgradeSO, name, instanceID);
            }

        }

        static void GetDefinedName(UpgradeSO upgradeSO, out string name, out int instanceID)
        {
            var paramaters = new object[] { "", -1 };
            var method = typeof(UpgradeSO).GetMethod("GetName", DefaultFieldBindingFlags);
            method.Invoke(upgradeSO, paramaters);
            name = (string)paramaters[0];
            instanceID = (int)paramaters[1];
        }

        static void RenameAsset(UpgradeSO upgradeSO, string name, int instanceID)
        {
            string assetPath = AssetDatabase.GetAssetPath(instanceID);
            var nameOfAsset = assetPath.Split('/')[^1];
            if (name == nameOfAsset) return;

            var error = AssetDatabase.RenameAsset(assetPath, name);
            if (string.IsNullOrEmpty(error) == false)
            {
                Debug.LogError("Couldnt rename the asset. " + error);
                return;
            }

            EditorUtility.SetDirty(upgradeSO);
            AssetDatabase.SaveAssetIfDirty(upgradeSO);
        }
    }
}