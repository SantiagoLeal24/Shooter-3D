using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 

    public GameObject pantallaFinal;

    public TextMeshProUGUI textoPuntaje;
    private int puntajeTotal = 0;

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

    private void Start()
    {
       ActualizarTextoPuntaje();
    }

     public void SumarPuntos(int cantidad)
    {
        puntajeTotal += cantidad;
        ActualizarTextoPuntaje();

    }

    private void ActualizarTextoPuntaje()
    {
        if (textoPuntaje != null)
        {
            textoPuntaje.text = "Kill Credits: " + puntajeTotal.ToString();
        }
    }

    public void FinDelJuego() 
    {

        GuardarPuntaje();
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
        GuardarPuntaje();

        panelVictoria.SetActive(true);

        
        Time.timeScale = 0f;

        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void GuardarPuntaje()
    {
        int recordActual = PlayerPrefs.GetInt("MejorPuntaje", 0);

        if (puntajeTotal > recordActual)
        {
            PlayerPrefs.SetInt("MejorPuntaje", puntajeTotal);
            PlayerPrefs.Save();
            Debug.Log("Nuevo Récord: " +  puntajeTotal + "!");
        }
    }

    public void ReiniciarNivel() 
    {
       
        Time.timeScale = 1f;

        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
