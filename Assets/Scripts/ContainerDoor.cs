using UnityEngine;
public class ContainerDoor : MonoBehaviour
{
    [Header("Angles de rotation")]
    public float closedY = 90f; // Angle fermé
    public float openY = -60f; // Angle ouvert
    [Header("Vitesse")]
    public float rotationSpeed = 120f; // Vitesse de rotation
    private Quaternion targetRotation; // Rotation à atteindre
    private bool quizCompleted = false; // Le quiz est-il réussi ?

    void Start()
    {
        // Au départ, la porte est ouverte
        transform.rotation = Quaternion.Euler(0f, openY, 0f);
        targetRotation = transform.rotation;
    }
    void Update()
    {
        // Rotation progressive vers la rotation cible
        transform.rotation = Quaternion.RotateTowards(
        transform.rotation,
        targetRotation,
        rotationSpeed * Time.deltaTime
        );
    }
    void OnTriggerEnter(Collider other)
    {
        // Si le joueur entre dans la zone, on ferme la porte
        if (other.CompareTag("Player"))
{
            CloseDoor();
        }
    }
    public void CloseDoor()
    {
        targetRotation = Quaternion.Euler(0f, closedY, 0f);
    }
    public void OpenDoor()
    {
        targetRotation = Quaternion.Euler(0f, openY, 0f);
    }
    public void QuizSuccess()
    {
        // Cette fonction sera appelée quand le quiz est réussi
        quizCompleted = true;

        OpenDoor();
    }
}