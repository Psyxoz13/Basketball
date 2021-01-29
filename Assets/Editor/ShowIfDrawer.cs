using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(ShowIfAttribute))]
public class ShowIfDrawer : PropertyDrawer
{
    public override float GetPropertyHeight(
        SerializedProperty property,
        GUIContent label)
    {
        return EditorGUI.GetPropertyHeight(property, label, true);
    }

    public override void OnGUI(
        Rect position,                        
        SerializedProperty property,
        GUIContent label)
    {
        var showIf = attribute as ShowIfAttribute;

        var conditionPropertyField = property.serializedObject.FindProperty(showIf.FieldName);
        var conditionPropertyFieldValue = GetValue(conditionPropertyField);

        IField field = GetField(showIf.FieldType);

        field.Rectangle = position;
        field.SerializedProperty = property;
        field.Content = label;
        field.IsShow = CompareValues(
                            showIf.ConditionalValue,
                            conditionPropertyFieldValue,
                            showIf.ComparisonType);

        field.Draw();
    }

    private object GetValue(SerializedProperty property)
    {
        var targetObject = property.serializedObject.targetObject;
        var targetObjectClassType = targetObject.GetType();
        var field = targetObjectClassType.GetField(property.propertyPath);

        return field.GetValue(targetObject);
    }

    private bool CompareValues(object a, object b, ComparisonType comparisonType) =>
        comparisonType switch
        {
            ComparisonType.Equals => a.Equals(b),
            ComparisonType.NotEqual => a.Equals(b) == false,
            _ => throw new System.ArgumentException("Invalid enum value", nameof(comparisonType))
        };

    private IField GetField(FieldType fieldType)
    {
        return fieldType switch
        {
            FieldType.DontDraw => new DontDrawField(),
            FieldType.Readonly => new ReadonlyField(),
            FieldType.DontDrawReadonly => new DontDrawReadonlyField(),
            _ => throw new System.ArgumentException("Invalid enum value", nameof(fieldType)),
        };
    }
}