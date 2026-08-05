using System.Collections;
using UnityEngine;
using UnityEngine.Video;
using TMPro;

public class ATMVideoInteract : MonoBehaviour
{
    [Header("Références")]
    public GameObject screenObject;
    public VideoPlayer videoPlayer;
    public TextMeshProUGUI interactText;

    [Header("Réglages")]
    public float delayBeforePlay = 2f;
    public string message = "Appuyer sur E pour lancer l'indice";

    private bool playerInRange = false;
    private bool isBusy = false;

    private void Start()
    {
        if (screenObject != null)
            screenObject.SetActive(false);

        if (interactText != null)
            interactText.text = "";

        if (videoPlayer != null)
            videoPlayer.isLooping = false;

        if (videoPlayer != null)
            videoPlayer.loopPointReached += OnVideoFinished;
    }

    private void Update()
    {
        if (playerInRange && !isBusy && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(ShowScreenThenPlayVideo());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;

            if (!isBusy && interactText != null)
                interactText.text = message;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;

            if (interactText != null)
                interactText.text = "";
        }
    }

    private IEnumerator ShowScreenThenPlayVideo()
    {
        isBusy = true;

        if (interactText != null)
            interactText.text = "";

        if (screenObject != null)
            screenObject.SetActive(true);

        if (videoPlayer != null)
            videoPlayer.Stop();

        yield return new WaitForSeconds(delayBeforePlay);

        if (videoPlayer != null)
            videoPlayer.Play();
    }

    void OnVideoFinished(VideoPlayer vp)
    {
    if (screenObject != null)
        screenObject.SetActive(false);

    if (videoPlayer != null)
        videoPlayer.Stop();

    isBusy = false;

    if (playerInRange && interactText != null)
        interactText.text = message;
    }

    void OnDestroy()
    {
        if (videoPlayer != null)
            videoPlayer.loopPointReached -= OnVideoFinished;
    }
}
