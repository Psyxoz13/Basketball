using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Localization : MonoBehaviour
{
    public delegate void LocalizationEvent();
    public static event LocalizationEvent OnLocalizationChanged;

    [SerializeField] private TextAsset _localizationXML;

    private static Dictionary<string, List<string>> _localizations = new Dictionary<string, List<string>>();
    private static int _selectedLocalizationIndex;

    private void Awake()
    {
        LoadLocalization();
    }

    private void Start()
    {
        SetLocalization(PlayerView.LocalizationID);
    }

    public static string GetTranslation(string localizationKey)
    {
        if (_localizations.ContainsKey(localizationKey))
        {
            return _localizations[localizationKey][_selectedLocalizationIndex];
        }

        return "Key not found";
    }

    public void SetLocalization(int id)
    {
        _selectedLocalizationIndex = id;
        PlayerPresenter.LocalizationID = id;

        OnLocalizationChanged?.Invoke();
    }

    private void LoadLocalization()
    {
        var xmlLocalization = new XmlDocument();
        xmlLocalization.LoadXml(_localizationXML.text);

        foreach (XmlNode key in xmlLocalization["Keys"].ChildNodes)
        {
            var keyName = key.Attributes["name"].Value;

            _localizations[keyName] = GetValues(key);
        }
    }

    private List<string> GetValues(XmlNode key)
    {
        var values = new List<string>();
        foreach (XmlNode translation in key["Localizations"].ChildNodes)
        {
            values.Add(translation.InnerText);
        }

        return values;
    }
}
