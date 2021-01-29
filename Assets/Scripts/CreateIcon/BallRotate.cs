using UnityEngine;
using UnityEngine.EventSystems;

public class BallRotate : MonoBehaviour, IDragHandler
{
    [SerializeField] private GameObject _ball;

    public void OnDrag(PointerEventData eventData)
    {
        _ball.transform.Rotate(Vector3.right, eventData.delta.y, Space.World);
        _ball.transform.Rotate(Vector3.down, eventData.delta.x, Space.World);
    }
}
