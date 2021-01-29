using UnityEngine;
using UnityEngine.Advertisements;

public class RewardAdvertisement : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] private int _rewardCoins = 25;

    void Start()
    {
        if (Advertisement.isSupported)
        {
            Advertisement.Initialize("3956111", false);
            Advertisement.AddListener(this);
        }
    }

    public void Show()
    {
        Advertisement.Show("rewardedVideo");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            PlayerPresenter.Coins = PlayerView.Coins + _rewardCoins;
        }
    }

    public void OnUnityAdsReady(string placementId)
    {

    }

    public void OnUnityAdsDidError(string message)
    {

    }

    public void OnUnityAdsDidStart(string placementId)
    {

    }
}
