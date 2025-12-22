using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class ZombieHand : MonoBehaviour

{
    [SerializeField]
    private int damageBase = 10;
    private Enemy enemyScript;



    void Start()
    {
        enemyScript = GetComponent<Enemy>();
    }

    public int HandDamage
    {
        get
        {
            if (enemyScript != null && enemyScript.isDead)
            {
                return 0;
            }
            return damageBase;

        }


    }
}

