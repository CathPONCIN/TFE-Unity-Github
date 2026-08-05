using UnityEngine;

public class FootstepController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] footstepClips;
    [SerializeField] private float stepInterval = 2f;
    [SerializeField] private float minMoveSpeed = 0.1f;

    private float stepTimer;

    private void Reset()
    {
        audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        float moveAmount = new Vector2(Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")).magnitude;

        if (moveAmount>minMoveSpeed)
        {
            PlayFootstep();
            stepTimer = stepInterval;
        }
        else
        {
            stepTimer = 0f;
        }
    }

    private void PlayFootstep()
    {
        if (audioSource == null ||
            footstepClips == null ||
            footstepClips.Length == 0)
            return;

        int index = Random.Range(0, footstepClips.Length);

        audioSource.PlayOneShot(footstepClips[index]);
    }
}
