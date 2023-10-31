#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace XIV.Core.Tools.ColliderConverter.Editor
{
    public static class ColliderConverterMenuItems
    {
        [MenuItem("CONTEXT/Collider/Convert/To 2D (Recursive)")]
        static void ConvertTo2D_Recursive()
        {
            var activeObjects = Selection.gameObjects;
            for (var i = 0; i < activeObjects.Length; i++)
            {
                GameObject activeObject = activeObjects[i];
                Undo.RegisterCompleteObjectUndo(activeObject, "Collider Change : " + activeObject.name);
                ColliderConverter.ConvertCollidersTo2D_Recursive(activeObject);
            }
        }
        
        [MenuItem("CONTEXT/Collider/Convert/To 2D")]
        static void ConvertTo2D()
        {
            var activeObjects = Selection.gameObjects;
            for (var i = 0; i < activeObjects.Length; i++)
            {
                GameObject activeObject = activeObjects[i];
                Undo.RegisterCompleteObjectUndo(activeObject, "Collider Change : " + activeObject.name);
                ColliderConverter.ConvertCollidersTo2D(activeObject);
            }
        }

        [MenuItem("CONTEXT/Collider2D/Convert/To 3D (Recursive)")]
        static void ConvertTo3D_Recursive()
        {
            var activeObjects = Selection.gameObjects;
            for (var i = 0; i < activeObjects.Length; i++)
            {
                GameObject activeObject = activeObjects[i];
                Undo.RegisterCompleteObjectUndo(activeObject, "Collider Change : " + activeObject.name);
                ColliderConverter.ConvertCollidersTo3D_Recursive(activeObject);
            }
        }

        [MenuItem("CONTEXT/Collider2D/Convert/To 3D")]
        static void ConvertTo3D()
        {
            var activeObjects = Selection.gameObjects;
            for (var i = 0; i < activeObjects.Length; i++)
            {
                GameObject activeObject = activeObjects[i];
                Undo.RegisterCompleteObjectUndo(activeObject, "Collider Change : " + activeObject.name);
                ColliderConverter.ConvertCollidersTo3D(activeObject);
            }
        }
        
    }
}
#endif