using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int HP = 100;
    public GameObject HurtScreen;
    
   public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
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
