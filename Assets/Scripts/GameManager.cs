using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 

    public GameObject pantallaFinal; 

    private void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void FinDelJuego() 
    {
        // 1. Activar el panel de UI
        pantallaFinal.SetActive(true);

        // 2. Pausar el tiempo
        Time.timeScale = 0f;

        // 3. Desbloquear el mouse 
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public GameObject panelVictoria;

    

    public void GanarNivel()
    {
        
        panelVictoria.SetActive(true);

        
        Time.timeScale = 0f;

        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ReiniciarNivel() 
    {
       
        Time.timeScale = 1f;

        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
