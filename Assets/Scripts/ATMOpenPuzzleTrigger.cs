using UnityEngine;
using TMPro;

public class ATMOpenPuzzleTrigger : MonoBehaviour
{
    public GameObject puzzlePanel;
    public TextMeshProUGUI interactText;
    public UIInteractionPause uiPause;

    private bool playerInRange = false;

    void Start()
    {
        if (puzzlePanel != null)
            puzzlePanel.SetActive(false);

        if (interactText != null)
            interactText.text = "";
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (uiPause != null)
                uiPause.OpenPanel(puzzlePanel);
            else if (puzzlePanel != null)
                puzzlePanel.SetActive(true);

            if (interactText != null)
                interactText.text = "";
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;

            if (interactText != null)
                interactText.text = "Appuyer sur E pour ouvrir le puzzle";
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;

            if (interactText != null)
                interactText.text = "";
        }
    }
}