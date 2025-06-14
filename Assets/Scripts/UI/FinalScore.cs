using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class FinalScore : MonoBehaviour
{
    private PlayerSettings playerSettings; // Referencia a la configuraci�n del jugador
    public TextMeshProUGUI scoreText; // Puntuaci�n del jugador

    private void Awake()
    {
        playerSettings = Resources.Load<PlayerSettings>("PlayerSettings");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = playerSettings.score + ""; // Muestra la puntuaci�n del jugador en el UI
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
