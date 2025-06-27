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
            StartCoroutine(Explotar()); 
            haExplotado = true;
        }
    }

    IEnumerator Explotar()
    {
        Collider[] objetos = Physics.OverlapSphere(transform.position, areaExplosion, capasAfectadas);

        foreach (Collider obj in objetos)
        {
            if (obj.TryGetComponent<Rigidbody>(out Rigidbody rbObj))
            {
                rbObj.AddExplosionForce(fuerzaExplosion, transform.position, areaExplosion);

                // Ver si es un kart
                if (obj.CompareTag("kart"))
                {
                    if (obj.TryGetComponent<karControllerv2>(out var kart))
                        kart.Efecto();  // Congelar
                }
                else if (obj.CompareTag("kart2"))
                {
                    if (obj.TryGetComponent<karControllerv3>(out var kart2))
                        kart2.Efecto();  // Congelar
                }
            }
        }


        yield return new WaitForSeconds(0.2f);  
        Destroy(gameObject);
    }
}
