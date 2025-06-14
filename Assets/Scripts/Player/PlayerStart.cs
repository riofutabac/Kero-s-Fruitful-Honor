using Unity.Cinemachine;
using UnityEngine;

public class PlayerStart : MonoBehaviour
{
    public CinemachineCamera cinemachineCamera; // Referencia a la c�mara virtual de Cinemachine

    private void Start()
    {
        int playerIndex = PlayerPrefs.GetInt("CharacterIndex"); // Obtiene el �ndice del personaje seleccionado desde PlayerPrefs
        GameObject player = Instantiate(
            GameManager.instance.characters[playerIndex].characterSelected,
            transform.position,
            Quaternion.identity,
            this.transform // Hace que el jugador sea hijo de PlayerStart
        );

        if (cinemachineCamera != null)
        {
            cinemachineCamera.Follow = player.transform; // Asigna el jugador a la c�mara virtual de Cinemachine
        }
        else
        {
            Debug.LogWarning("VirtualCamera no asignada en PlayerStart.");
        }

    }
}
