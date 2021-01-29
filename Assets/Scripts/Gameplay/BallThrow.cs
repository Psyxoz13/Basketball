using UnityEngine;

[RequireComponent(typeof(Camera))]
public class BallThrow : MonoBehaviour
{
    [SerializeField] private float _forceAmount = 500f;
    [SerializeField] private float _throwingPowerMultiplier = 1f;

    private Ball _selectedBall;
    private Camera _targetCamera;
    private Vector3 _originalScreenTargetPosition;
    private Vector3 _originalBallPosition;
    private float _selectionDistance;

    private void Awake()
    {
        _targetCamera = GetComponent<Camera>();
    }

    private void Update()
    {
        ListenInput();
    }

    private void ListenInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TakeBall();
        }
        if (Input.GetMouseButtonUp(0) && _selectedBall)
        {
            ThrowBall();
        }
    }

    private void FixedUpdate()
    {
        if (_selectedBall)
        {
            MoveBall();
        }
    }

    private void TakeBall()
    {
        _selectedBall = GetBall();

        if (_selectedBall)
        {
            _selectedBall.IsTaken = true;
        }
    }

    private Ball GetBall()
    {
        var ray = _targetCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            if (hitInfo.rigidbody == null)
                return null;

            _selectionDistance = Vector3.Distance(ray.origin, hitInfo.point);
            _originalScreenTargetPosition = _targetCamera.ScreenToWorldPoint(
                new Vector3(
                    Input.mousePosition.x,
                    Input.mousePosition.y,
                    _selectionDistance));
            _originalBallPosition = hitInfo.rigidbody.position;

            var ball = hitInfo.rigidbody.gameObject.GetComponent<Ball>();

            if (ball.CanTaken)
                return ball;
        }
        return null;
    }

    private void ThrowBall()
    {
        _selectedBall.BallRigidbody.velocity +=
            Mathf.Abs(_selectedBall.BallRigidbody.velocity.y)
            * Vector3.forward
            * _throwingPowerMultiplier;

        _selectedBall.IsTaken = false;
        _selectedBall = null;
    }

    private void MoveBall()
    {
        var mousePositionOffset = GetMousePositionOffset();
        _selectedBall.BallRigidbody.velocity = GetBallVelocity(mousePositionOffset);
        _selectedBall.BallRigidbody.angularVelocity = GetBallAngularVelocity(
            _selectedBall.BallRigidbody.velocity);
    }

    private Vector3 GetMousePositionOffset()
    {
        return _targetCamera.ScreenToWorldPoint(
            new Vector3(
                Input.mousePosition.x,
                Input.mousePosition.y,
                _selectionDistance))
            - _originalScreenTargetPosition;
    }

    private Vector3 GetBallVelocity(Vector3 mousePositionOffset)
    {
         return (
            _originalBallPosition
            + mousePositionOffset
            - _selectedBall.BallRigidbody.position)
         * _forceAmount
         * Time.fixedDeltaTime;
    }

    private Vector3 GetBallAngularVelocity(Vector3 ballVelocity)
    {    
        return Vector3.Lerp(
                _selectedBall.BallRigidbody.angularVelocity,
                transform.InverseTransformDirection(
                    new Vector3(
                        ballVelocity.y,
                        -ballVelocity.x)),
                Time.fixedDeltaTime);
    }
}
