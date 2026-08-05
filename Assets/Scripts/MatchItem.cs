using UnityEngine;
using UnityEngine.UI;

public class MatchItem : MonoBehaviour
{
    public int pairId;
    public bool isLeft;
    public Image image;

    private MatchingManager manager;
    private bool isLocked = false;

    void Start()
    {
        manager = FindObjectOfType<MatchingManager>();

        if (image == null)
            image = GetComponent<Image>();
    }

    public void SelectItem()
    {
        if (isLocked)
            return;

        if (manager != null)
            manager.Select(this);
    }

    public void SetColor(Color color)
    {
        if (image != null)
            image.color = color;
    }

    public void LockItem()
    {
        isLocked = true;
    }

    public void ResetColor()
    {
        if (!isLocked && image != null)
            image.color = Color.white;
    }

    public bool IsLocked()
    {
        return isLocked;
    }
}