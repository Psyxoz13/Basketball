using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class PreporationTimeView : MonoBehaviour
{
    private Text _textField;

    private void Awake()
    {
        _textField = GetComponent<Text>();
    }

    public void UpdateView()
    {
        _textField.text = GameTimer.PreporationTime.ToString();
    }
}
