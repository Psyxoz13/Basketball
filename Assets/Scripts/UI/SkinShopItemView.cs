using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SkinShopItem))]
public class SkinShopItemView : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private Text _costField;
    [SerializeField] private GameObject _costPanel;
    [SerializeField] private GameObject _selectedMarker;

    private SkinShopItem _skinShopItem;

    private void Awake()
    {
       _skinShopItem = GetComponent<SkinShopItem>();

        SkinShopItem.OnSelected += SetSelected;
    }

    private void OnEnable()
    {      
        TryDeactivateCostPanel();
    }

    private void Start()
    {
        SetIcon();
        SetCost();
        TryDeactivateCostPanel();
    }

    private void SetSelected()
    {
        _selectedMarker.SetActive(_skinShopItem.IsSelected);
    }

    private void SetIcon()
    {
        _icon.sprite = _skinShopItem.BallSkin.Icon;
    }

    private void SetCost()
    {
        _costField.text = _skinShopItem.BallSkin.SkinInfo.Cost.ToString();
    }

    private void TryDeactivateCostPanel()
    {
        if (_skinShopItem.IsPurchased)
        {
            _costPanel.SetActive(false);
        }
    }
}
