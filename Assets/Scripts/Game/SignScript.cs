using TMPro;
using UnityEngine;

public class SignScript : MonoBehaviour
{
    public Canvas canvas; // Referencia al Canvas donde se mostrar� el mensaje
    public TextMeshProUGUI instructionText; // Objeto TextMeshPro para mostrar la instrucci�n
    public string instruction; // Texto de la instrucci�n a mostrar

    private void Awake()
    {
        instructionText.text = instruction; // Asigna el texto de la instrucci�n al TextMeshPro
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canvas.enabled = true; // Habilita el Canvas
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canvas.enabled = false; // Deshabilita el Canvas
        }
    }
}
