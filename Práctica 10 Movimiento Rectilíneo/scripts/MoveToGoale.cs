using UnityEngine;

public class MoveToGoale : MonoBehaviour
{
    public Transform goal;
    void Start()
    {
        goal.position = new Vector3(goal.position.x * 2, goal.position.y * 2, goal.position.z * 2);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(goal.position);
    }
}