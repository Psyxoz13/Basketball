using UnityEngine;
using UnityEngine.Events;

public class ScoreZone : MonoBehaviour
{
    [SerializeField] private GameScore _score;

    private bool _isScored = false;

    private void OnTriggerEnter(Collider other)
    {
        var yOffset = other.transform.position.y - transform.position.y;
        if (yOffset > 0)
        {
            _isScored = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var yOffset = other.transform.position.y - transform.position.y;
        if (yOffset < 0 && _isScored)
        {
            _score.AddScore(1);
        }
        _isScored = false;
    }
}
