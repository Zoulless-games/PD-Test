using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumHitEffect : MonoBehaviour
{
    public float horizontalSqueeze;
    public float verticalSqueeze;
    public float speed;
    private Vector3 originalShape;

    private void Start()
    {
        originalShape = transform.localScale;
    }

    public void SqueezeDrum(float amount)
    {
        StopCoroutine(Squeeze(0));
        transform.localScale = originalShape;
        StartCoroutine(Squeeze(amount));
    }

    IEnumerator Squeeze(float amount)
    {
        Vector3 newShape = new Vector3(transform.localScale.x * (horizontalSqueeze + amount / 2), transform.localScale.y * (verticalSqueeze - amount / 2), transform.localScale.z * (horizontalSqueeze + amount / 2));

        var timePassed = 0f;
        while (timePassed < speed)
        {
            var factor = timePassed / speed;
            transform.localScale = Vector3.Lerp(transform.localScale, newShape, factor);
            timePassed += Mathf.Min(Time.deltaTime, speed - timePassed);
            yield return null;
        }
        timePassed = 0f;
        while (timePassed < speed)
        {
            var factor = timePassed / speed;
            transform.localScale = Vector3.Lerp(transform.localScale, originalShape, factor);
            timePassed += Mathf.Min(Time.deltaTime, speed - timePassed);
            yield return null;
        }
    }
}
