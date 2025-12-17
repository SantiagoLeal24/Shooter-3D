using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public int HP = 100;
    public GameObject HurtScreen;

    public Slider barraDeSalud;

    private void Start()
    {
        if (barraDeSalud != null)
        {
            barraDeSalud.maxValue = HP;
            barraDeSalud.value = HP;
        }
    }

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;

        if (barraDeSalud != null)
        {
            barraDeSalud.value = HP;

        }
        if (HP <= 0)
        {
            print("Tai muerto");

            GameManager.Instance.FinDelJuego();
            
        }
        else
        {
            StartCoroutine(HurtFX());
        }
    }

  

    private IEnumerator HurtFX()
    {
        if (HurtScreen.activeInHierarchy == false)
        {
            HurtScreen.SetActive(true);
        }

        yield return new WaitForSeconds(1.5f);

        if (HurtScreen.activeInHierarchy)
        {
            HurtScreen.SetActive(false);
        }
                
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AttackHand"))
        {
            TakeDamage(other.gameObject.GetComponent<ZombieHand>().HandDamage);
        }
    }
}
