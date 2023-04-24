using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public Platform platform;
    public Image image;
    public float mass;
    public float radius = 5f;

    public float acceleration;
    public float angleVelocity;
    public float velocity;

    public float Alpha => -platform.alpha;

    private void Update()
    {
        acceleration = Constants.g * Mathf.Sin(Alpha * Mathf.Deg2Rad) * mass;
        
        UpdatePosition();
        UpdateRotation();
    }

    private void UpdatePosition()
    {
        velocity += acceleration * Time.deltaTime;
        transform.localPosition += new Vector3(velocity * Time.deltaTime, 0, 0);
    }

    private void UpdateRotation()
    {
        angleVelocity = -velocity / radius;
        transform.RotateAround(transform.position, Vector3.forward, angleVelocity * Time.deltaTime * Mathf.Rad2Deg);
    }
}