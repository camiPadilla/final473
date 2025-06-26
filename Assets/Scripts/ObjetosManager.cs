using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ObjetosManager : MonoBehaviour
{
    public GameObject cajaPrefab;
    public List<GameObject> items;
    public List<GameObject> karts;
    public controladorCanvas ControlUI;
    karControllerv2 kartCod;
    karControllerv3 kartCod2;
    controladorCanvas controlUI;

    public void Start()
    {
        kartCod = karts[0].GetComponent<karControllerv2>();
        kartCod2 = karts[1].GetComponent<karControllerv3>();
        


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
    public void DarItemConRuleta(int id){
        controlUI.IniciarCorrutinaItems((indexItemFinal) =>
        {
            if (id == 1)
            {
                kartCod.RecItem(items[indexItemFinal]);
            }
            if (id == 2)
            {
                kartCod2.RecItem2(items[indexItemFinal]);
            }
        });
    }
    /*
    public void RandItemJ1()
    {
        controlUI.IniciarCorrutinaItems();
        int aleatorio = Random.Range(0, 4);
        switch (aleatorio)
        {
            case 0: //dinamita
                print("dinamita");
                kartCod.RecItem(items[0]);
                controlUI.MostrarItemIU(aleatorio);
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
    //No quisiera usar mas codigo pero bueh....
   public void RandItemJ2(){
        int aleatorio = Random.Range(0, 4);
        switch (aleatorio)
        {
            case 0: //dinamita
                print("dinamita");
                kartCod2.RecItem2(items[0]);
                break;
            case 1: //pilfrut
                print("pilfrut");
                kartCod2.RecItem2(items[1]);
                break;
            case 2: //coca
                print("coca");
                //guardar en kart
                kartCod2.RecItem2(items[2]);
                break;
            case 3: //MAS
                print("MAS IPSP");
                kartCod2.RecItem2(items[3]);
                break;
        }
    }
    */
}
