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
        Collider[] objetos = Physics.OverlapSphere(transform.position, areaExplosion, capasAfectadas);

        foreach (Collider obj in objetos)
        {
            Rigidbody rbObj = obj.GetComponent<Rigidbody>();
            if (rbObj != null)
            {
                rbObj.AddExplosionForce(fuerzaExplosion, transform.position, areaExplosion);

                // Ver si es un jugador afectado
                if (obj.CompareTag("kart"))
                {
                    karControllerv2 kart = obj.GetComponent<karControllerv2>();
                    if (kart != null)
                        kart.Efecto();
                }
                else if (obj.CompareTag("kart2"))
                {
                    karControllerv3 kart = obj.GetComponent<karControllerv3>();
                    if (kart != null)
                        kart.Efecto();
                }
            }
        }

        // Podés poner aquí un efecto visual o sonido

        Destroy(gameObject);
    }

}
