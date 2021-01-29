using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Icon : MonoBehaviour
{
    [SerializeField] private string _iconsPath = "D:/";
    [SerializeField] private InputField _nameField;

    [Space]
    [SerializeField] private float _hideDelay = 1f;
    [SerializeField] private GameObject[] _hideObjects;

    public void CreateIcon()
    {
        SetObjectsActive(false);

        ScreenCapture.CaptureScreenshot($"{_iconsPath + _nameField.text }.jpg");

        StartCoroutine(ActivateObjects());
    }

    private void SetObjectsActive(bool enabled)
    {
        for (int i = 0; i < _hideObjects.Length; i++)
        {
            _hideObjects[i].SetActive(enabled);
        }
    }

    private IEnumerator ActivateObjects()
    {
        yield return new WaitForSecondsRealtime(_hideDelay);

        SetObjectsActive(true);
    }
}
