using UnityEngine;

public class moveToGoalA : MonoBehaviour
{
    public Transform goal;
    void Start()
    {
      goal.position = goal.position * 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
      transform.Translate(goal.position);
    }
}
