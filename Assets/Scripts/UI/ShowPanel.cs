using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShowPanel : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Transform _showPosition;
    [SerializeField] private Transform _hidePosition;
    [Space]
    [SerializeField] private float _showOffsetSpeed = 2f;
    [SerializeField] private float _hideDelay = 3f;
    [Header("Button")]
    [SerializeField] private Button _showPanelButton;
    [SerializeField] private float _showPanelButtonSpeed = .1f;

  
    private Coroutine _delayCoroutine;

    public void OnPointerDown(PointerEventData eventData)
    {
        ResetDelay();
    }

    public void ResetDelay()
    {
        StopCoroutine(_delayCoroutine);
        _delayCoroutine = StartCoroutine(GetShowDelay());
    }

    public void Show()
    {
        StartCoroutine(Move(_showPosition.position));
        StartCoroutine(_showPanelButton.SetButtonEnabled(false, _showPanelButtonSpeed));
        _showPanelButton.enabled = false;

        _delayCoroutine = StartCoroutine(GetShowDelay());
    }

    private IEnumerator Move(Vector3 targetPosition)
    {
        while (transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPosition,
                _showOffsetSpeed * Time.deltaTime);

            yield return null;
        }
    }

    private IEnumerator GetShowDelay()
    {
        yield return new WaitForSecondsRealtime(_hideDelay);

        StartCoroutine(_showPanelButton.SetButtonEnabled(true, _showPanelButtonSpeed));
        StartCoroutine(Move(_hidePosition.position));
    }
}

public static class ButtonExtension
{
    public static IEnumerator SetButtonEnabled(this Button button, bool enabled, float fadeSpeed = 1f)
    {
        var newColor = button.image.color;
        newColor.a = Convert.ToInt32(enabled);

        while (button.image.color != newColor)
        {
            button.image.color = Color.Lerp(
                button.image.color,
                newColor,
                fadeSpeed * Time.deltaTime);

            yield return null;
        }

        button.enabled = enabled;
    }
}

