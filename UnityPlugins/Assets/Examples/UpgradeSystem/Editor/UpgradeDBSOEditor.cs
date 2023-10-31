using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using XIV.UpgradeSystem.DataStructures;
using XIV.UpgradeSystem.Examples;
using XIV.UpgradeSystem.Integration;
using XIV.XIVEditor.Utils;

namespace XIV.UpgradeSystem.Editor
{
    [CustomEditor(typeof(UpgradeDBSO))]
    public class UpgradeDBSOEditor : UnityEditor.Editor
    {
        public string UpgradeFolderPath = "Assets/Scripts/UpgradeSystem/Examples";

        const string UPGRADE_SYSTEM_UPGRADE_FOLDER_PATH_KEY = "UpgradeSystem_UpgradeFolderPath";

        void OnEnable()
        {
            UpgradeFolderPath = EditorPrefs.GetString(UPGRADE_SYSTEM_UPGRADE_FOLDER_PATH_KEY, UpgradeFolderPath);
        }

        void OnDisable()
        {
            EditorPrefs.SetString(UPGRADE_SYSTEM_UPGRADE_FOLDER_PATH_KEY, UpgradeFolderPath);
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            UpgradeFolderPath = EditorGUILayout.TextArea(UpgradeFolderPath);
            
            if (GUILayout.Button("Load Upgrades"))
            {
                var upgradeDBSO = target as UpgradeDBSO;
                Undo.RegisterCompleteObjectUndo(upgradeDBSO, "Load Upgrades");
                var allUpgrades = (UpgradeDictionary)ReflectionUtils.GetFieldValue("allUpgrades", upgradeDBSO);
                allUpgrades.Clear();
                Dictionary<Type, List<UpgradeSO<PlayerUpgrade>>> upgrades = AssetUtils.LoadAssetsByBaseClass<UpgradeSO<PlayerUpgrade>>(UpgradeFolderPath);
                foreach (Type key in upgrades.Keys)
                {
                    allUpgrades.Add(key.Name, new CustomSerializedList<UpgradeSO<PlayerUpgrade>>(upgrades[key]));
                }
                EditorUtility.SetDirty(upgradeDBSO);
                AssetDatabase.SaveAssetIfDirty(upgradeDBSO);
            }
        }
        
    }
}