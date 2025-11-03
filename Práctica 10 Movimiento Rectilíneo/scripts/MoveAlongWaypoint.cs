using UnityEngine;
using UnityStandardAssets.Utility;

[RequireComponent(typeof(WaypointProgressTracker))]
public class MoveAlongWaypoint : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 5f;
    public float stopDistance = 0.5f;

    private WaypointProgressTracker tracker;

    void Start()
    {
        tracker = GetComponent<WaypointProgressTracker>();
    }

    void Update()
    {
        if (tracker == null || tracker.target == null)
            return;
        Vector3 direction = tracker.target.position - transform.position;
        if (direction.magnitude > stopDistance)
        {
            Quaternion targetRot = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotationSpeed * Time.deltaTime);
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }
}
