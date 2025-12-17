using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coleccionable : MonoBehaviour
{
    public int chipKills;

    private Collider collider;

    private Rigidbody rb;

    private void Start()
    {
        collider = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();

        StartCoroutine(Caida());

    }

    IEnumerator Caida()
    {
        collider.isTrigger = false;
        rb.useGravity = true;
        rb.isKinematic = false;

        yield return new WaitForSeconds(1.5f);

        collider.isTrigger = true;
        rb.useGravity = false;
        rb.isKinematic = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.SumarPuntos(chipKills);
            Destroy(gameObject);
        }
    }
}
