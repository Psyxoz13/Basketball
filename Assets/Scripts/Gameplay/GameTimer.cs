using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GameTimer : MonoBehaviour
{
    public static int PreporationTime { get; private set; } = 0;
    public static int GameTime { get; private set; } = 0;
    public static int AfterGameTime { get; private set; } = 0;

    [Header("Timers Ticks Events")]
    public UnityEvent OnPreparationTimerTick;
    public UnityEvent OnGameTimerTick;
    
    [Header("Timers End Events")]
    public UnityEvent OnPreparationEnd;
    public UnityEvent OnGameEnd;
    public UnityEvent OnAfterGameTimerEnd;

    [Space(20f)]
    [SerializeField] private int _preparationSeconds = 3;
    [SerializeField] private int _gameSeconds = 90;
    [SerializeField] private int _afterGameSeconds = 3;

    private void Awake()
    {
        GameTime = _gameSeconds;
        PreporationTime = _preparationSeconds;
        AfterGameTime = _afterGameSeconds;
    }

    private void Start()
    {
        StartCoroutine(GetTimeLeft());
    }

    private IEnumerator GetTimeLeft()
    {
        yield return GetPreporationTimerTicks();
        yield return GetGameTimerTicks();
        yield return GetAfterGameTimerTicks();
    }

    private IEnumerator GetPreporationTimerTicks()
    {
        while (PreporationTime != 0)
        {
            yield return new WaitForSecondsRealtime(1);
            PreporationTime--;

            OnPreparationTimerTick?.Invoke();
        }
        OnPreparationEnd?.Invoke();
    }

    private IEnumerator GetGameTimerTicks()
    {
        while (GameTime != 0)
        {
            yield return new WaitForSecondsRealtime(1);
            GameTime--;

            OnGameTimerTick?.Invoke();
        }
        OnGameEnd?.Invoke();
    }

    private IEnumerator GetAfterGameTimerTicks()
    {
        while (AfterGameTime != 0)
        {
            yield return new WaitForSecondsRealtime(1);
            AfterGameTime--;
        }
        OnAfterGameTimerEnd?.Invoke();
    }
}
