using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private GameScore _score;

    private Scoreboard _scoreboard;

    private void Awake()
    {
        _scoreboard = GetComponent<Scoreboard>();
    }

    public void UpdateScore()
    {
        _scoreboard.SetNumber(_score.Count);
    }
}
