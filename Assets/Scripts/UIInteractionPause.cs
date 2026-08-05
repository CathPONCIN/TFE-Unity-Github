using UnityEngine;

public class UIInteractionPause : MonoBehaviour
{
    [Header("Scripts à désactiver pendant un panel")]
    public MonoBehaviour playerMovement;
    public MonoBehaviour playerLook;

    private int openedPanels = 0;

    public void OpenPanel(GameObject panel)
    {
        if (panel != null)
            panel.SetActive(true);

        openedPanels++;

        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (playerMovement != null)
            playerMovement.enabled = false;

        if (playerLook != null)
            playerLook.enabled = false;
    }

    public void ClosePanel(GameObject panel)
    {
        if (panel != null)
            panel.SetActive(false);

        openedPanels--;

        if (openedPanels <= 0)
        {
            openedPanels = 0;

            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            if (playerMovement != null)
                playerMovement.enabled = true;

            if (playerLook != null)
                playerLook.enabled = true;
        }
    }
}
