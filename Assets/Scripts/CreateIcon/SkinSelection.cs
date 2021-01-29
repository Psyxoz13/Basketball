using UnityEngine;

public class SkinSelection : MonoBehaviour
{
    [SerializeField] private BallSkin[] _ballSkins;
    [SerializeField] private BallTexture _ballTexture;

    private ObjectSelectionList<BallSkin> _ballSelectionList;

    private void Awake()
    {
        _ballSelectionList = _ballSkins.ToSelectionList();
    }

    public void NextSkin()
    {
        _ballTexture.SetSkin(_ballSelectionList.Next());
    }

    public void PreviousSkin()
    {
        _ballTexture.SetSkin(_ballSelectionList.Previous());
    }
}
