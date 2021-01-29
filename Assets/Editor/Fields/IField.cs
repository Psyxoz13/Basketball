using UnityEditor;
using UnityEngine;

public interface IField
{
    public SerializedProperty SerializedProperty { get; set; }
    public GUIContent Content { get; set; }

    public Rect Rectangle { get; set; }

    public bool IsShow { get; set; }

    public void Draw();
}


