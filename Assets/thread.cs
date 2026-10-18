using UnityEngine;

public class thread : MonoBehaviour

{
    [Header("Movement Settings")]
    public Transform startPoint;       // Starting position
    public Transform endPoint;         // Ending position
    public float moveDuration = 2f;    // Time to move from start to end
    public AnimationCurve smoothCurve; // Controls easing (e.g., ease-in-out)

    private float timer;
    private bool movingForward = true;

    void Update()
    {
        if (startPoint == null || endPoint == null)
            return; // Safety check

        // Update timer
        timer += Time.deltaTime / moveDuration;

        // Reverse direction when reaching end
        if (timer >= 1f)
        {
            timer = 0f;
            movingForward = !movingForward;
        }

        // Apply smooth curve for fluid motion
        float t = smoothCurve.Evaluate(timer);

        // Lerp position
        transform.position = Vector3.Lerp(
            movingForward ? startPoint.position : endPoint.position,
            movingForward ? endPoint.position : startPoint.position,
            t
        );
    }
}

