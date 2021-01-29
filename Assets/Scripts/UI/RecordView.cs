using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class RecordView : MonoBehaviour
{
    private Text _textField;

    private void Awake()
    {
        _textField = GetComponent<Text>();
    }

    private void OnEnable()
    {
        _textField.text = PlayerView.Record.ToString();
    }
}
