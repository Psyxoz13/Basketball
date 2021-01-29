using UnityEngine;
using UnityEngine.UI;

public class MoneyView : MonoBehaviour
{
    [SerializeField] private Text _moneyText;

    private void Start()
    {
        SetMoneyText();
        PlayerPresenter.OnPlayerValuesChanged += SetMoneyText;
    }

    private void OnDestroy()
    {
        PlayerPresenter.OnPlayerValuesChanged -= SetMoneyText;
    }

    public void SetMoneyText()
    {
        _moneyText.text = PlayerView.Coins.ToString();
    }
}
