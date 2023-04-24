using System;
using UnityEngine;

public class PIDIndicator : MonoBehaviour
{
    public PID pid;

    private void Update() => 
        transform.localPosition = new Vector3(pid.targetPosition, transform.localPosition.y, transform.localPosition.z);
}