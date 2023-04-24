using UnityEngine;

public class BallPositionChecker : MonoBehaviour
{
    public Transform leftBoard;
    public Transform rightBoard;
    public float touchOffset = 50;

    private Ball _ball;
    private Vector3 _ballPositionOnPreviousFrame;

    private void Awake() => 
        _ball = GetComponent<Ball>();

    private void Update()
    {
        if (BallIsTouchingLeftBoard())
            TeleportBall();
        else if (BallIsTouchingRightBoard())
            TeleportBall();

        _ballPositionOnPreviousFrame = _ball.transform.localPosition;
    }

    private bool BallIsTouchingLeftBoard() => 
        _ball.transform.localPosition.x <= leftBoard.localPosition.x + touchOffset;

    private bool BallIsTouchingRightBoard() => 
        _ball.transform.localPosition.x >= rightBoard.localPosition.x - touchOffset;

    private void TeleportBall()
    {
        _ball.transform.localPosition = _ballPositionOnPreviousFrame;
        _ball.velocity = 0;
    }
}