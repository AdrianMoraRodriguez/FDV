using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class InkBarUI : MonoBehaviour
{
    public Image fillBar;

    void Start()
    {
        InkSystem.Instance.OnInkChanged += UpdateBar;
        UpdateBar(InkSystem.Instance.currentInk / InkSystem.Instance.maxInk);
    }

    void UpdateBar(float normalizedValue)
    {
        fillBar.fillAmount = normalizedValue;
    }

    void OnDestroy()
    {
        if (InkSystem.Instance != null)
        {
            InkSystem.Instance.OnInkChanged -= UpdateBar;
        }
    }
}