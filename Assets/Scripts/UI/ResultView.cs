using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ResultView : MonoBehaviour
{
    [SerializeField] private GameScore _gameScore;

    private Text _textField;

    private void Awake()
    {
        _textField = GetComponent<Text>();
    }

    private void OnEnable()
    {
        _textField.text = _gameScore.Count + "\n" + PlayerView.Record;
    }
}
