using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SkinBuyMenu : MonoBehaviour
{
    public UnityEvent OnBuy;

    [SerializeField] private Image _skinImage;
    [SerializeField] private Text _skinCostField;

    private static SkinShopItem _selectedItem;

    private void Awake()
    {
        SkinShopItem.OnTryBuy += SetItem;
    }

    public void SetItem(SkinShopItem skinShopItem)
    {
        _selectedItem = skinShopItem;

        _skinImage.sprite = skinShopItem.BallSkin.Icon;
        _skinCostField.text = skinShopItem.BallSkin.SkinInfo.Cost.ToString();
    }

    public void TryBuy()
    {
        var skinInfo = _selectedItem.BallSkin.SkinInfo;
        if (skinInfo.Cost <= PlayerView.Coins)
        {
            PlayerPresenter.Coins -= skinInfo.Cost;
            PlayerPresenter.PurchasedBallSkins.Add(skinInfo);
            PlayerPresenter.Save();

            OnBuy?.Invoke();
        }
    }
}
