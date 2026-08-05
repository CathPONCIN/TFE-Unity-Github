using UnityEngine;
using UnityEngine.Video;
using TMPro;

public class VideoQuizManager : MonoBehaviour
{
    [SerializeField] private PuzzleAudioManager PuzzleAudioManager;

    [Header("Références vidéo")]
    public VideoPlayer videoPlayer;
    public GameObject videoScreen;
    public GameObject interactHint;

    [Header("Références quiz")]
    public GameObject quizPanel;
    public TextMeshProUGUI questionText;
    public TextMeshProUGUI feedbackText;

    [Header("Pause UI")]
    public UIInteractionPause uiPause;

    [Header("Porte")]
    public ContainerDoor door;

    [Header("Question")]
    [TextArea] public string question = "Quel est le bon indice ?";
    public int correctAnswerIndex = 2;

    private bool quizActive = false;

    void Start()
    {
        if (quizPanel != null)
            quizPanel.SetActive(false);

        if (feedbackText != null)
            feedbackText.text = "";

        if (questionText != null)
            questionText.text = question;

        if (videoPlayer != null)
            videoPlayer.loopPointReached += OnVideoFinished;
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        if (videoScreen != null)
            videoScreen.SetActive(false);

        if (feedbackText != null)
            feedbackText.text = "";

        if (uiPause != null)
            uiPause.OpenPanel(quizPanel);
        else if (quizPanel != null)
            quizPanel.SetActive(true);

        quizActive = true;
    }

    public void ChooseAnswer(int answerIndex)
    {
        if (!quizActive)
            return;

        quizActive = false;

        if (answerIndex == correctAnswerIndex)
        {
            if (feedbackText != null)
                feedbackText.text = "Bonne réponse !";

            PuzzleAudioManager.PlayPuzzleSuccessSound(1);

            if (uiPause != null)
                uiPause.ClosePanel(quizPanel);
            else if (quizPanel != null)
                quizPanel.SetActive(false);

            if (door != null)
                door.OpenDoor();
        }
        else
        {
            if (feedbackText != null)
                feedbackText.text = "Mauvaise réponse. Regarde à nouveau la vidéo.";

            if (uiPause != null)
                uiPause.ClosePanel(quizPanel);
            else if (quizPanel != null)
                quizPanel.SetActive(false);

            if (videoPlayer != null)
                videoPlayer.Stop();

            if (interactHint != null)
                interactHint.SetActive(true);
        }
    }

    void OnDestroy()
    {
        if (videoPlayer != null)
            videoPlayer.loopPointReached -= OnVideoFinished;
    }
}
