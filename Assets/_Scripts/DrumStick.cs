using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumStick : MonoBehaviour
{
    public Vector2 velocity;
    public float mass;
    public Transform velocityCalculationPoint1;
    public Transform velocityCalculationPoint2;
    private Vector3 previousPos1;
    private Vector3 previousPos2;

    private void Start()
    {
        previousPos1 = velocityCalculationPoint1.position;
        previousPos2 = velocityCalculationPoint2.position;
    }

    public void Update()
    {
        CalculateVelocity();
    }

    public float CalculateVelocityAtHitPoint(Transform pos)
    {
        // Calculate distances from the known points
        float distanceA = Vector3.Distance(velocityCalculationPoint1.position, pos.position);
        float distanceB = Vector3.Distance(velocityCalculationPoint2.position, pos.position);

        // Interpolate velocity
        float interpolatedVelocity = velocity.x + (velocity.y - velocity.x) * (distanceA / (distanceA + distanceB));

        return interpolatedVelocity;
    }

    public void CalculateVelocity()
    {
        Vector3 currentPos1 = velocityCalculationPoint1.position;
        Vector3 currentPos2 = velocityCalculationPoint2.position;

        // Calculate velocities at each point
        float velocityX = (currentPos1 - previousPos1).magnitude / Time.deltaTime * mass;
        float velocityY = (currentPos2 - previousPos2).magnitude / Time.deltaTime * mass;

        // Update previous positions
        previousPos1 = currentPos1;
        previousPos2 = currentPos2;

        // Assign velocities to the vector2
        velocity = new Vector2(velocityX, velocityY);
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Drum"))
        {
            other.transform.GetComponent<ValueChanger>().DrumHit(velocity.x);
        }
    }
}
