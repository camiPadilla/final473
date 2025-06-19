using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dinamita : MonoBehaviour
{
    public float areaExplosion = 5f;
    public float fuerzaExplosion = 70f;
    public LayerMask capasAfectadas;  // Para filtrar qu� objetos afectan la explosi�n

    private Rigidbody rb;
    private bool haExplotado = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!haExplotado)
        {
            Explotar();
            haExplotado = true;
        }
    }

    void Explotar()
    {
        // Detectar objetos cercanos
        Collider[] objetos = Physics.OverlapSphere(transform.position, areaExplosion, capasAfectadas);

        foreach (Collider obj in objetos)
        {
            Rigidbody rbObj = obj.GetComponent<Rigidbody>();
            if (rbObj != null)
            {
                // Aplicar fuerza de explosi�n
                rbObj.AddExplosionForce(fuerzaExplosion, transform.position, areaExplosion);
            }

            // Aqu� pod�s agregar l�gica para da�o, efectos, etc.
        }

        // Aqu� pod�s agregar efectos visuales o sonido de explosi�n

        // Destruir la dinamita despu�s de explotar
        Destroy(gameObject);
    }
}
