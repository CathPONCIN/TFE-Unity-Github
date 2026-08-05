using UnityEngine;

public class PuzzleAudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip puzzle1Success;
    [SerializeField] private AudioClip puzzle2Success;
    [SerializeField] private AudioClip puzzle3Success;
    [SerializeField] private AudioClip puzzle4Success;

    public void PlayPuzzleSuccessSound(int puzzleIndex)
    {
        if (audioSource == null)
            return;

        switch (puzzleIndex)
        {
            case 1:
                if (puzzle1Success != null) audioSource.PlayOneShot(puzzle1Success);
                break;
            case 2:
                if (puzzle2Success != null) audioSource.PlayOneShot(puzzle2Success);
                break;
            case 3:
                if (puzzle3Success != null) audioSource.PlayOneShot(puzzle3Success);
                break;
            case 4:
                if (puzzle4Success != null) audioSource.PlayOneShot(puzzle4Success);
                break;
        }
    }  
}
