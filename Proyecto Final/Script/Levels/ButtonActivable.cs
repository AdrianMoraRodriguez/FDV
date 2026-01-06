using UnityEngine;

public class DestructiveButton : MonoBehaviour
{
    public enum ButtonMode
    {
        Permanent,
        Hold
    }

    [Header("Mode")]
    public ButtonMode mode = ButtonMode.Permanent;

    [Header("Target")]
    public GameObject target;

    [Header("Visuals")]
    public Sprite idleSprite;
    public Sprite pressedSprite;

    SpriteRenderer sr;

    int pressCount = 0;
    bool activated = false;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        SetIdleVisual();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!IsValidPresser(collision.gameObject))
            return;

        pressCount++;

        if (mode == ButtonMode.Permanent && !activated)
        {
            ActivatePermanent();
        }
        else if (mode == ButtonMode.Hold)
        {
            ActivateHold();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (!IsValidPresser(collision.gameObject))
            return;

        pressCount--;

        if (mode == ButtonMode.Hold && pressCount <= 0)
        {
            DeactivateHold();
        }
    }

    bool IsValidPresser(GameObject obj)
    {
        return obj.CompareTag("Player") ||
               obj.layer == LayerMask.NameToLayer("Ground");
    }

    void ActivatePermanent()
    {
        activated = true;

        SetPressedVisual();

        if (target != null)
            target.SetActive(false);
    }

    void ActivateHold()
    {
        SetPressedVisual();

        if (target != null)
            target.SetActive(false);
    }

    void DeactivateHold()
    {
        SetIdleVisual();

        if (target != null)
            target.SetActive(true);
    }

    void SetIdleVisual()
    {
        if (sr != null && idleSprite != null)
            sr.sprite = idleSprite;
    }

    void SetPressedVisual()
    {
        if (sr != null && pressedSprite != null)
            sr.sprite = pressedSprite;
    }
}
