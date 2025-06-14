using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScenario : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Esta l�nea comprueba si el objeto que toc� el portal es el jugador.
        if (collision.CompareTag("Player"))
        {
            // Si es el jugador, carga la escena llamada "FinalScore".
            // No importa en qu� nivel est�s, siempre ir� a la pantalla final.
            // Es la forma m�s directa de hacerlo.
            SceneManager.LoadScene("FinalScore");
        }
    }
}