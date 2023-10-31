using UnityEditor;
using UnityEngine;
using XIV.Core;

namespace XIV.XIVEditor
{
    [CustomPropertyDrawer(typeof(DisplayWithoutEdit))]
    public class DisplayWithoutEditDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            GUI.enabled = false;
            switch (property.propertyType)
            {
                case SerializedPropertyType.AnimationCurve:
                    EditorGUI.CurveField(position, label, property.animationCurveValue);
                    break;
                case SerializedPropertyType.ArraySize:
                    base.OnGUI(position, property, label);
                    break;
                case SerializedPropertyType.Boolean:
                    EditorGUI.Toggle(position, label, property.boolValue);
                    break;
                case SerializedPropertyType.Bounds:
                    EditorGUI.LabelField(position, label.ToString(), property.boundsValue.ToString());
                    break;
                case SerializedPropertyType.Character:
                    base.OnGUI(position, property, label);
                    break;
                case SerializedPropertyType.Color:
                    EditorGUI.ColorField(position, label, property.colorValue);
                    break;
                case SerializedPropertyType.Enum:
                    EditorGUI.LabelField(position, label, new GUIContent(property.enumDisplayNames[property.enumValueIndex]));
                    break;
                case SerializedPropertyType.Float:
                    EditorGUI.LabelField(position, label, new GUIContent(property.floatValue.ToString()));
                    break;
                case SerializedPropertyType.Generic:
                    base.OnGUI(position, property, label);
                    break;
                case SerializedPropertyType.Gradient:
                    base.OnGUI(position, property, label);
                    break;
                case SerializedPropertyType.Integer:
                    EditorGUI.LabelField(position, label, new GUIContent(property.intValue.ToString()));
                    break;
                case SerializedPropertyType.LayerMask:
                    EditorGUI.LayerField(position, label, property.intValue);
                    break;
                case SerializedPropertyType.ObjectReference:
                    EditorGUI.ObjectField(position, property, label);
                    break;
                case SerializedPropertyType.Quaternion:
                    EditorGUI.Vector4Field(position, label, new Vector4(property.quaternionValue.x, property.quaternionValue.y, property.quaternionValue.z, property.quaternionValue.w));
                    break;
                case SerializedPropertyType.Rect:
                    EditorGUI.LabelField(position, label.ToString(), property.rectValue.ToString());
                    break;
                case SerializedPropertyType.String:
                    EditorGUI.LabelField(position, label.ToString(), property.stringValue);
                    break;
                case SerializedPropertyType.Vector2:
                    EditorGUI.Vector2Field(position, label, new Vector2(property.vector2Value.x, property.vector2Value.y));
                    break;
                case SerializedPropertyType.Vector3:
                    EditorGUI.Vector3Field(position, label, new Vector3(property.vector3Value.x, property.vector3Value.y, property.vector3Value.z));
                    break;
                case SerializedPropertyType.Vector4:
                    EditorGUI.Vector4Field(position, label, new Vector4(property.vector4Value.x, property.vector4Value.y, property.vector4Value.z, property.vector4Value.w));
                    break;
            }
            GUI.enabled = true;
        }
    }
}