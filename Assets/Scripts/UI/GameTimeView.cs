using UnityEngine;

[RequireComponent(typeof(Scoreboard))]
public class GameTimeView : MonoBehaviour
{
    private Scoreboard _scoreboard;

    private void Awake()
    {
        _scoreboard = GetComponent<Scoreboard>();
    }

    private void Start()
    {
        UpdateTime();
    }

    public void UpdateTime()
    {
        _scoreboard.SetNumber(GameTimer.GameTime);
    }
}
