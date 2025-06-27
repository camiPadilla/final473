using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dinamita : MonoBehaviour
{
    public float areaExplosion = 5f;
    public float fuerzaExplosion = 50f;  // puedes bajarla si no quieres que vuelen tanto
    public LayerMask capasAfectadas;

    private bool haExplotado = false;

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
                rbObj.AddExplosionForce(fuerzaExplosion, transform.position, areaExplosion);

            // Ver si es un jugador afectado
            if (obj.CompareTag("kart"))
            {
                var kart = obj.GetComponent<karControllerv2>();
                if (kart != null && !kart.invulnerable)
                    kart.Efecto();
            }
            else if (obj.CompareTag("kart2"))
            {
                var kart = obj.GetComponent<karControllerv3>();
                if (kart != null && !kart.invulnerable)
                    kart.Efecto();
            }
        }

        Destroy(gameObject);
    }
}
