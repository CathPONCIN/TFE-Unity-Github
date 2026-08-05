using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string gameSceneName = "HangarScene"; // Nom exact de la scène à ouvrir

    public void PlayGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game"); // Utile dans l'éditeur, car Application.Quit ne ferme pas le Play Mode
    }
}
