using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class DrumstickTracking : MonoBehaviour
{
    public Transform target;
    public Transform attachPosition;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.velocity = (target.position - attachPosition.position) / Time.fixedDeltaTime;
    }

    private void Update()
    {
        Quaternion rotationDifference = target.rotation * Quaternion.Inverse(transform.rotation);
        rotationDifference.ToAngleAxis(out float angleInDegree, out Vector3 rotationAxis);

        Vector3 rotationDifferenceInDegree = angleInDegree * rotationAxis;

        rb.angularVelocity = ((rotationDifferenceInDegree + new Vector3(-30, 0, 0)) * Mathf.Deg2Rad / Time.deltaTime);
    }
}
