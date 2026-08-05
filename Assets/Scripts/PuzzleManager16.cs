using System.Collections;
using UnityEngine;
using TMPro;

public class PuzzleManager16 : MonoBehaviour
{
    public PuzzlePiece16[] pieces;
    public GameObject puzzlePanel;
    public TextMeshProUGUI resultText;
    public GameObject nextObjectToUnlock;
    public UIInteractionPause uiPause;

    [SerializeField] private PuzzleAudioManager PuzzleAudioManager;

    void Start()
    {
        if (resultText != null)
            resultText.text = "";
    }

    public void CheckPuzzle()
    {
        for (int i = 0; i < pieces.Length; i++)
        {
            if (pieces[i] == null || !pieces[i].IsPlaced())
                return;
        }

        if (resultText != null)
            resultText.text = "Puzzle réussi !";

        Debug.Log("Puzzle terminé");

        if (nextObjectToUnlock != null)
            nextObjectToUnlock.SetActive(true);

        PuzzleAudioManager.PlayPuzzleSuccessSound(2);
        StartCoroutine(ClosePuzzleAfterDelay());
    }

    IEnumerator ClosePuzzleAfterDelay()
    {
        yield return new WaitForSecondsRealtime(1f);
        ClosePuzzle();
    }

    public void ClosePuzzle()
    {
        if (uiPause != null)
            uiPause.ClosePanel(puzzlePanel);
        else if (puzzlePanel != null)
            puzzlePanel.SetActive(false);
    }
}