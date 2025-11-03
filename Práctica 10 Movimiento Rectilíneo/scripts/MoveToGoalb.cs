using UnityEngine;

public class MoveToGoalb : MonoBehaviour
{
    public Transform goal;

    void Start()
    {
        goal.position = new Vector3(goal.position.x, 0, goal.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(goal.position);
    }
}
