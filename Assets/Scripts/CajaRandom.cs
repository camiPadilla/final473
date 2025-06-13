using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaRandom : MonoBehaviour
{
    public GameObject prefabCaja;              
    public ObjetosManager objetosManager;

    private void Start()
    {
        // Si no se asignó manualmente el manager, buscarlo automáticamente
        if (objetosManager == null)
            objetosManager = FindObjectOfType<ObjetosManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("kart")) // asegurate de que el jugador tenga este tag
        {
            // Pido al mi ObjetosManager que spawnee la nueva caja 
            objetosManager.SpawnearCajaDespues(transform.position);
            objetosManager.RandItem();
            Destroy(gameObject);
        }
    }
}
