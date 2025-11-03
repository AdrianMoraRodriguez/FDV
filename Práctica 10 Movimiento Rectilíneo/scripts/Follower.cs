using UnityEngine;

public class Follower : MonoBehaviour
{
    public Transform goal;
    public float speed = 2f;
    public float speedBoost = 1f;

    void Update()
    {
        Vector3 direction = goal.position - transform.position;
        transform.LookAt(goal.position);
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            speed += speedBoost;
            Debug.Log("Nueva velocidad: " + speed);
        }
    }
}
