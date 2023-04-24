using System;
using UnityEngine;
using UnityEngine.UI;

public class Platform : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Slider slider;
    
    public float alpha = 0;

    private void Awake() => 
        slider.onValueChanged.AddListener(Rotate);

    void Update()
    {
        HandleRotation();
        UpdateAlpha();
    }

    private void HandleRotation()
    {
        var axisRaw = Input.GetAxisRaw("Horizontal");
        Rotate(axisRaw * rotationSpeed * Time.deltaTime);
    }

    private void Rotate(float value) => 
        transform.Rotate(Vector3.forward, value);

    private void UpdateAlpha()
    {
        alpha = transform.rotation.eulerAngles.z;
        
        if (alpha > 180)
            alpha -= 360;
    }
}
