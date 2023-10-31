using System.IO;
using UnityEditor;

namespace XIVPlugins.XIVEditor
{
    public static class MenuItems
    {
        const string PROJECT_VIEW_CONTEXT_MENU = "Assets/XIV/";
        const string PROJECT_VIEW_PACKAGE_MENU = PROJECT_VIEW_CONTEXT_MENU + "Package/";
        const string UNITYPACKAGE_EXTENSION = ".unitypackage";
    
        [MenuItem(PROJECT_VIEW_PACKAGE_MENU + nameof(ExportPackage), priority = 1000)]
        static void ExportPackage()
        {
            var guids = Selection.assetGUIDs;
            int length = guids.Length;
            if (length == 0) return;
            string[] selectionPaths = new string[length];
            string[] assetNames = new string[length];
            
            for (var i = 0; i < length; i++)
            {
                string completePath = AssetDatabase.GUIDToAssetPath(guids[i]);
                string assetName = completePath.Split("/")[^1];
                selectionPaths[i] = completePath;
                assetNames[i] = assetName;
            }

            Directory.CreateDirectory(FilePaths.EXPORT_PACKAGE_DIRECTORY);
            var coreFilePath = Path.Combine(FilePaths.EXPORT_PACKAGE_DIRECTORY, "XIV-Core");
            if (File.Exists(coreFilePath) == false)
            {
                AssetDatabase.ExportPackage(FilePaths.XIV_CORE_PATH, coreFilePath + UNITYPACKAGE_EXTENSION, ExportPackageOptions.Recurse);
            }
            
            for (int i = 0; i < length; i++)
            {
                var assetName = "XIV-" + assetNames[i];
                var fileName = Path.Combine(FilePaths.EXPORT_PACKAGE_DIRECTORY, assetName) + UNITYPACKAGE_EXTENSION;
                AssetDatabase.ExportPackage(selectionPaths[i], fileName, ExportPackageOptions.Recurse);
            }
            
            AssetDatabase.Refresh();
        }
    }
}