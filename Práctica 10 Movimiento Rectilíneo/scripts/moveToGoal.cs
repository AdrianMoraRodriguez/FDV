using UnityEngine;

public class moveToGoal : MonoBehaviour
{
    public Transform goal;
    void Start()
    {
      transform.Translate(goal.position);
    }
}
