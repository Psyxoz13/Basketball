using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkinsShop : MonoBehaviour
{
    public static List<SkinShopItem> SkinShopItems = new List<SkinShopItem>();

    [SerializeField] private BallSkin[] _skins;
    [SerializeField] private SkinShopItem _skinShopItem;

    private void Awake()
    {
        SortItems();
        CreateSkinShopItems();
    }

    private void OnEnable()
    {
        SetPurchasedBallSkins();
    }

    private void Start()
    {
        SelectLastSelected();
    }

    private void CreateSkinShopItems()
    {
        for (int i = 0; i < _skins.Length; i++)
        {
            var skinShopItem = Instantiate(_skinShopItem, transform);
            skinShopItem.BallSkin = _skins[i];
            SkinShopItems.Add(skinShopItem);
        }
    }

    private void SortItems()
    {
        for (int i = 0; i < _skins.Length; i++)
        {
            for (int j = i + 1; j < _skins.Length; j++)
            {
                if (_skins[i].SkinInfo.Cost > _skins[j].SkinInfo.Cost)
                {
                    var temp = _skins[i];
                    _skins[i] = _skins[j];
                    _skins[j] = temp;
                }
            }
        }
    }

    private void SetPurchasedBallSkins()
    {
        for (int i = 0; i < PlayerView.PurchasedBallSkins.Count; i++)
        {
            for (int j = 0; j < SkinShopItems.Count; j++)
            {
                if (SkinShopItems[j].BallSkin.SkinInfo.Equals(PlayerView.PurchasedBallSkins[i]))
                {
                    SkinShopItems[j].IsPurchased = true;        
                }
            }
        }
    }

    private void SelectLastSelected()
    {
        SkinShopItems.Where(
            skinShopItem =>
                skinShopItem.BallSkin.SkinInfo.Equals(
                    PlayerView.SelectedBallSkin))
            .FirstOrDefault()
            .TrySelect();
    }
}
