using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public AudioClip zombieDeath;
    public AudioClip zombieHurt;
    public bool isDead;

    [SerializeField] private int HP = 100;

    public GameObject chip;

    public float alturaDrop = 2f;

    private Animator animator;

    private NavMeshAgent navAgent;
    private void Start()
    {
        animator = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();

    }

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;

        if (HP <= 0)
        {
            animator.SetTrigger("DIE");
            Destroy(gameObject, 4f);

            SoltarObjeto();

            isDead = true;
        }
        else
        {
            animator.SetTrigger("DAMAGE");
        }


    }

    void SoltarObjeto()
    {
        if (chip != null)
        {
            Vector3 posicionDrop = transform.position + (Vector3.up * alturaDrop);
            Instantiate(chip, posicionDrop, Quaternion.identity);
        }
    }
}