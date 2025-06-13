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
    GameObject item;
    kart kartCod;

    public void Start()
    {
        kartR = kart.GetComponent<Rigidbody>();
        kartCod = kart.GetComponent<kart>();
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
            case 0: //DINAMITA
                print("dinamita");
                item = items[0];
                kartCod.RecItem(item); 
                break;
            case 1: //pilfrut
                print("pilfrut");
                item = items[1];
                kartCod.RecItem(item);
                break;
            case 2: //coca
                print("coca");
                //guardar en kart
                item = items[2];
                kartCod.RecItem(item);
                break;
            case 3: //MAS
                print("MAS IPSP");
                item = items[3];
                kartCod.RecItem(item);
                break;
        }
    }
}
