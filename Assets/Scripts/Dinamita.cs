using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dinamita : MonoBehaviour
{
    public float areaExplosion = 5f;
    public float fuerzaExplosion = 70f;
    public LayerMask capasAfectadas;  

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
                // Aplicar fuerza de explosión
                rbObj.AddExplosionForce(fuerzaExplosion, transform.position, areaExplosion);
                rbObj.isKinematic = true;
            }

            // Aquí podés agregar lógica para daño, efectos, etc.
            rbObj.velocity = Vector3.zero;
            rbObj.isKinematic = false;
        }

        // Aquí podés agregar efectos visuales o sonido de explosión

        // Destruir la dinamita después de explotar
        Destroy(gameObject);
    }
}
