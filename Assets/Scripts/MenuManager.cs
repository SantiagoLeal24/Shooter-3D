using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [Header("Paneles")]
    public GameObject panelMenu;
    public GameObject panelRecords;

    [Header("Texto Récord")]
    public TextMeshProUGUI textoMejorPuntaje;

    public void Jugar()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void AbrirRecords()
    { 

        panelMenu.SetActive(false);
        panelRecords.SetActive(true);

        int record = PlayerPrefs.GetInt("MejorPuntaje", 0);
        textoMejorPuntaje.text = "MEJOR PUNTAJE:\n" + record.ToString();
    }

    public void VolverAlMenu()
    {
        panelRecords.SetActive(false);
        panelMenu.SetActive(true);
    }

    public void Salir()
    {
        Application.Quit();

        Debug.Log("Saliendo");
    }
}
