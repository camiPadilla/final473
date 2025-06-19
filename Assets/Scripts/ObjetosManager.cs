using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ObjetosManager : MonoBehaviour
{
    public GameObject kart;
    public GameObject cajaPrefab;
    public List<GameObject> items;

    Rigidbody kartR;
    karControllerv2 kartCod;

    public void Start()
    {
        kartR = kart.GetComponent<Rigidbody>();
        kartCod = kart.GetComponent<karControllerv2>();
    }
    public void SpawnearCajaDespues( Vector3 posicion)
    {
        StartCoroutine(RespawnCaja(cajaPrefab, posicion));
    }

    private IEnumerator RespawnCaja(GameObject prefab, Vector3 posicion)
    {
        yield return new WaitForSeconds(10f);

        // Instancia la caja en la misma posición
        Instantiate(prefab, posicion, Quaternion.identity);
    }
    public void RandItem() {
        int aleatorio = Random.Range(0, 4);
        switch (aleatorio) {
            case 0: //dinamita
                print("dinamita");
                kartCod.RecItem(items[0]); 
                break;
            case 1: //pilfrut
                print("pilfrut");
                kartCod.RecItem(items[1]);
                break;
            case 2: //coca
                print("coca");
                //guardar en kart
                kartCod.RecItem(items[2]);
                break;
            case 3: //MAS
                print("MAS IPSP");
                kartCod.RecItem(items[3]);
                break;
        }
    }
}
