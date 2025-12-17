using UnityEngine;

public class Vacío : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.FinDelJuego();
        }
    }
}
