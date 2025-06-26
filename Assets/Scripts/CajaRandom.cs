using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaRandom : MonoBehaviour
{
    public GameObject prefabCaja;              
    public ObjetosManager objetosManager;

    private void Start()
    {
        if (objetosManager == null)
        {
            objetosManager = FindObjectOfType<ObjetosManager>();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        objetosManager.SpawnearCajaDespues(transform.position);
        if (other.CompareTag("kart"))
        {
            objetosManager.RandItemJ1();
        }
        else if (other.CompareTag("kart2"))
        {

            objetosManager.RandItemJ2();
        }

        Destroy(gameObject);
    }
}
