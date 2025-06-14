using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScenario : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Esta línea comprueba si el objeto que tocó el portal es el jugador.
        if (collision.CompareTag("Player"))
        {
            // Si es el jugador, carga la escena llamada "FinalScore".
            // No importa en qué nivel estés, siempre irá a la pantalla final.
            // Es la forma más directa de hacerlo.
            SceneManager.LoadScene("FinalScore");
        }
    }
}