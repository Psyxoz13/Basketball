using UnityEngine;
using UnityEngine.Events;

public class GameScore : MonoBehaviour
{
    public int Count { get; private set; }

    public UnityEvent OnAddScore;

    public void AddScore(int addCount)
    {
        Count += addCount;
        OnAddScore?.Invoke();

        TrySetRecord();
    }

    private void TrySetRecord()
    {
        if (Count > PlayerView.Record)
        {
            PlayerPresenter.Record = Count;
        }
    }
}
