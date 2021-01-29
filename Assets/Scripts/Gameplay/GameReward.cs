using UnityEngine;

public class GameReward : MonoBehaviour
{
    [SerializeField] private GameScore _gameScore;

    public void SetReward()
    {
        PlayerPresenter.Coins += _gameScore.Count;
    }
}
