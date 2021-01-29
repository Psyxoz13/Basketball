using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class LocalizedText : MonoBehaviour
{
    public string Text { get; private set; }

    [SerializeField] private string _localizationKey;

    private Text _textField;

    private void Awake()
    {
        _textField = GetComponent<Text>();
        Localization.OnLocalizationChanged += SetText;
    }

    private void OnEnable()
    {
        SetText();
    }

    private void SetText()
    {
        try
        {
            _textField.text
                = Text
                = Localization.GetTranslation(_localizationKey);    
        }
        catch 
        { 
            SetText();
        }
    }
}
