using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzlePiece16 : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("Bonne case")]
    public RectTransform targetSlot;

    [Header("Réglages")]
    public float snapDistance = 60f;

    private RectTransform rectTransform;
    private Canvas canvas;
    private CanvasGroup canvasGroup;

    private Vector2 startPosition;
    private Transform startParent;
    private bool isPlaced = false;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();

        if (canvasGroup == null)
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
    }

    void Start()
    {
        startPosition = rectTransform.anchoredPosition;
        startParent = transform.parent;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isPlaced)
            return;

        canvasGroup.blocksRaycasts = false;
        transform.SetParent(canvas.transform);
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isPlaced)
            return;

        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isPlaced)
            return;

        canvasGroup.blocksRaycasts = true;

        float distance = Vector2.Distance(rectTransform.position, targetSlot.position);

        if (distance <= snapDistance)
        {
            transform.SetParent(targetSlot);
            rectTransform.anchoredPosition = Vector2.zero;
            isPlaced = true;

            PuzzleManager16 manager = FindObjectOfType<PuzzleManager16>();
            if (manager != null)
                manager.CheckPuzzle();
        }
        else
        {
            transform.SetParent(startParent);
            rectTransform.anchoredPosition = startPosition;
        }
    }

    public bool IsPlaced()
    {
        return isPlaced;
    }
}
