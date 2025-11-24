using UnityEngine;

public class ZonaVictoria : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Si lo que entró en el halo es el Jugador
        if (other.CompareTag("Player"))
        {
            // ¡Ganaste!
            GameManager.Instance.GanarNivel();
        }
    }
}
