using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [Header("Movimiento y rotación")]
    public float speed = 3f;
    public float rotationSpeed = 5f;
    public float accuracy = 0.5f;

    [Header("Waypoints")]
    private GameObject[] waypoints;
    private int currentWaypoint = 0;

    void Start()
    {
        waypoints = GameObject.FindGameObjectsWithTag("waypoint");
    }

    void Update()
    {
        if (waypoints == null || waypoints.Length == 0) return;
        GameObject current = waypoints[currentWaypoint];
        Vector3 direction = current.transform.position - transform.position;
        if (direction.magnitude < accuracy)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
            return;
        }
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Debug.DrawLine(transform.position, current.transform.position, Color.cyan);
    }
}
