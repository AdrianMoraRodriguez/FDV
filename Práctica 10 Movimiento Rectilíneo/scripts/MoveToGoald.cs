using UnityEngine;

public class MoveToGoald : MonoBehaviour
{
    public Transform goal;
    void Start()
    {
        goal.position = new Vector3(goal.position.x, 2, goal.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(goal.position);
    }
}
