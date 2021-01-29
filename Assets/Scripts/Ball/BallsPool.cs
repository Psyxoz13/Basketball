using UnityEngine;

public class BallsPool : MonoBehaviour
{
    [SerializeField] private Ball[] _balls;

    public void SetBallsCanTaken(bool canTaken)
    {
        for (int i = 0; i < _balls.Length; i++)
        {
            _balls[i].CanTaken = canTaken;
        }
    }
}
