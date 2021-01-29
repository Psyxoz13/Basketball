using UnityEngine;
using UnityEngine.Events;

public class SkinShopItem : MonoBehaviour
{
    public delegate void SkinBuyEvent(SkinShopItem skinShopItem);

    public static event UnityAction OnSelected;
    public static event SkinBuyEvent OnTryBuy;

    public BallSkin BallSkin { get; set; }

    public bool IsPurchased { get; set; } = false;
    public bool IsSelected { get; set; } = false;

    private static SkinShopItem _lastSelectedItem;

    public void TrySelect()
    {
        if (_lastSelectedItem != null)
        {
            _lastSelectedItem.IsSelected = false;
        }

        if (IsPurchased == false)
        {
            MenuActiveState.GetInstance().ShowMenu("BuySkin");
            OnTryBuy?.Invoke(this);

            return;
        }

        IsSelected = true;

        BallTexture.GetInstance().SetSkin(BallSkin);
        PlayerPresenter.SelectedBallSkin = BallSkin.SkinInfo;

        _lastSelectedItem = this;

        OnSelected?.Invoke();
    }
}
