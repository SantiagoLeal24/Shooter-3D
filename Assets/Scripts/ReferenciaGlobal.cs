using UnityEngine;

public class ReferenciaGlobal : MonoBehaviour
{
    public static ReferenciaGlobal Instance { get; set; }

    public GameObject bulletImpactEffectPrefab;

    public GameObject bloodFX;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
}
