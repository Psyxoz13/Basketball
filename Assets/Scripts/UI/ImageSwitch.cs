using UnityEngine;
using UnityEngine.UI;

public class ImageSwitch : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites;

    private ObjectSelectionList<Sprite> _selectionSprites;

    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();

        _selectionSprites = _sprites.ToSelectionList();

        SetImageSprite(_selectionSprites[0]);
    }

    public void NextImage()
    {
        SetImageSprite(_selectionSprites.Next());
    }

    public void PrevImage()
    {
        SetImageSprite(_selectionSprites.Previous());
    }

    private void SetImageSprite(Sprite sprite)
    {
        _image.sprite = sprite;
    }
}
