using System.Collections;
using UnityEngine;
using TMPro;

public class MatchingManager : MonoBehaviour
{
    public MatchItem selectedLeft;
    public MatchItem selectedRight;

    public Color normalColor = Color.white;
    public Color correctColor = Color.green;
    public Color wrongColor = Color.red;
    public Color selectedColor = Color.yellow;

    public TextMeshProUGUI resultText;
    public GameObject matchingPanel;
    public UIInteractionPause uiPause;

    [SerializeField] private PuzzleAudioManager PuzzleAudioManager;

    public void Select(MatchItem item)
    {
        if (item.isLeft)
        {
            if (selectedLeft != null && selectedLeft != item)
                selectedLeft.ResetColor();

            selectedLeft = item;
            selectedLeft.SetColor(selectedColor);
        }
        else
        {
            if (selectedRight != null && selectedRight != item)
                selectedRight.ResetColor();

            selectedRight = item;
            selectedRight.SetColor(selectedColor);
        }

        if (selectedLeft != null && selectedRight != null)
        {
            CheckMatch();
        }
    }

    void CheckMatch()
    {
        if (selectedLeft.pairId == selectedRight.pairId)
        {
            selectedLeft.SetColor(correctColor);
            selectedRight.SetColor(correctColor);

            selectedLeft.LockItem();
            selectedRight.LockItem();

            if (resultText != null)
                resultText.text = "Bonne association";

            CheckIfAllMatched();
        }
        else
        {
            selectedLeft.SetColor(wrongColor);
            selectedRight.SetColor(wrongColor);

            if (resultText != null)
                resultText.text = "Mauvaise association";

            StartCoroutine(ResetWrongSelection());
        }

        selectedLeft = null;
        selectedRight = null;
    }

    IEnumerator ResetWrongSelection()
    {
        yield return new WaitForSecondsRealtime(1f);

        MatchItem[] allItems = FindObjectsOfType<MatchItem>();
        for (int i = 0; i < allItems.Length; i++)
        {
            allItems[i].ResetColor();
        }

        if (resultText != null)
            resultText.text = "";
    }

    void CheckIfAllMatched()
    {
        MatchItem[] allItems = FindObjectsOfType<MatchItem>();

        for (int i = 0; i < allItems.Length; i++)
        {
            if (!allItems[i].IsLocked())
                return;
        }

        if (resultText != null)
            resultText.text = "Toutes les associations sont correctes !";

        PuzzleAudioManager.PlayPuzzleSuccessSound(3);
        StartCoroutine(ClosePanelAfterDelay());
    }

    IEnumerator ClosePanelAfterDelay()
    {
        yield return new WaitForSecondsRealtime(1f);
        CloseMatchingPanel();
    }

    public void CloseMatchingPanel()
    {
        if (uiPause != null)
            uiPause.ClosePanel(matchingPanel);
        else if (matchingPanel != null)
            matchingPanel.SetActive(false);
    }
}