using UnityEditor;
using UnityEngine;

namespace XIV.DataTypes
{
    public abstract class EnumSOBase : ScriptableObject
    {
#if UNITY_EDITOR
        /// <summary>
        /// Make sure overriden method is editor only
        /// </summary>
        protected abstract string GetName();
        // protected override void GetName(out string name, out int instanceID)
        // {
        //     name = this.title + "_UpgradeDB";
        //     instanceID = this.GetInstanceID();
        // }

        public virtual void FixName()
        {
            string name = GetName();
            var instanceID = this.GetInstanceID();
            
            string assetPath = AssetDatabase.GetAssetPath(instanceID);
            var splitedPath = assetPath.Split('/');
            var nameOfAsset = splitedPath[splitedPath.Length - 1];
            if (name != nameOfAsset)
            {
                var error = AssetDatabase.RenameAsset(assetPath, name);
                if (string.IsNullOrEmpty(error) == false)
                {
                    Debug.LogError("Couldnt rename the asset. " + error);
                }
                else
                {
                    AssetDatabase.SaveAssets();
                }
            }
        }
#endif
    }
}