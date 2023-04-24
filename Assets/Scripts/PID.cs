using System;
using UnityEngine;

public class PID : MonoBehaviour
{
    private const float deltaTime = 0.1f;
    
    public float kp = 0.8f;
    public float ki = 0.05f;
    public float kd = 8f;
    
    public Ball ball;
    public Transform platform;
    public float targetPosition = 0;

    private float _minOut = 0;
    private float _maxOut = 0;
    
    private float _currentPosition;
    
    private float previousI = 0;
    private float previousError = 0;

    private void FixedUpdate()
    {
        UpdateMinAndMax();
        
        _currentPosition = ball.transform.localPosition.x;
        var output = ComputePID();

        platform.Rotate(Vector3.forward, -output);
    }

    public void SetTargetPosition(string position)
    {
        if (float.TryParse(position, out targetPosition))
            return;
    }

    private void UpdateMinAndMax()
    {
        _minOut = -60f - ball.Alpha;
        _maxOut = 60f - ball.Alpha;
    }

    private float ComputePID() => 
        Constrain(P()*kp + I()*ki + D()*kd, _minOut, _maxOut);

    private float P() => 
        Constrain(targetPosition - _currentPosition, _minOut, _maxOut);

    private float I()
    {
        previousI += (targetPosition - _currentPosition) * deltaTime;
        
        return Constrain(previousI, _minOut, _maxOut);
    }

    private float D()
    {
        var error = targetPosition - _currentPosition;
        var D = (error - previousError) / deltaTime;
        previousError = error;
        
        return Constrain(D, _minOut, _maxOut);
    }

    private float Constrain(float value, float minOut, float maxOut)
    {
        if (value >= maxOut)
            return maxOut;
        
        if (value <= minOut)
            return minOut;

        return value;
    }
}