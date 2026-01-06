using UnityEngine;
using Unity.Cinemachine;

public class CameraGroupManager : MonoBehaviour
{
    public CinemachineTargetGroup targetGroup;

    void OnEnable()
    {
        GameEvents.OnTartaCollected += OnTartaCollected;
        GameEvents.OnLevelFinished += OnLevelFinished;
    }

    void OnDisable()
    {
        GameEvents.OnTartaCollected -= OnTartaCollected;
        GameEvents.OnLevelFinished -= OnLevelFinished;
    }

    void OnTartaCollected(int levelID, int tartaIndex, Transform tarta)
    {
        targetGroup.AddMember(tarta, 0f, 1.5f);
    }

    void OnLevelFinished()
    {
        FocusOnTartas();
    }

    void FocusOnTartas()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        if (player != null && targetGroup.Targets.Count > 1)
        {
            targetGroup.RemoveMember(player.transform);
        }

        for (int i = 0; i < targetGroup.Targets.Count; i++)
        {
            var t = targetGroup.Targets[i];
            t.Weight = 1.5f;
            t.Radius = 2f;
            targetGroup.Targets[i] = t;
        }
    }
}
