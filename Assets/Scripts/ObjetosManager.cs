using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ObjetosManager : MonoBehaviour
{
    public GameObject cajaPrefab;
    public List<GameObject> items;
    public List<GameObject> karts;
    karControllerv2 kartCod;
    karControllerv3 kartCod2;
    public  controladorCanvas controlUI;
    int aleatorio;


    
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
    
    
    public void RandItemJ1()
    {
        aleatorio = Random.Range(0, 4);
        switch (aleatorio)
        {
            case 0: //dinamita
                print("dinamita");
                kartCod.RecItem(items[0]);

                controlUI.IniciarRuletaVisual(0, aleatorio);
                break;
            case 1: //pilfrut
                print("pilfrut");
                kartCod.RecItem(items[1]);
                controlUI.IniciarRuletaVisual(0, aleatorio);
                break;
            case 2: //coca
                print("coca");
                //guardar en kart
                kartCod.RecItem(items[2]);
                controlUI.IniciarRuletaVisual(0, aleatorio);
                break;
            case 3: //MAS
                print("MAS IPSP");
                kartCod.RecItem(items[3]);
                controlUI.IniciarRuletaVisual(0, aleatorio);
                break;
        }
    }
    //No quisiera usar mas codigo pero bueh....
   public void RandItemJ2(){
        aleatorio = Random.Range(0, 4);
        switch (aleatorio)
        {
            case 0: //dinamita
                print("dinamita");
                kartCod2.RecItem2(items[0]);
                controlUI.IniciarRuletaVisual(1, aleatorio);
                break;
            case 1: //pilfrut
                print("pilfrut");
                kartCod2.RecItem2(items[1]);
                controlUI.IniciarRuletaVisual(1, aleatorio);
                break;
            case 2: //coca
                print("coca");
                //guardar en kart
                kartCod2.RecItem2(items[2]);
                controlUI.IniciarRuletaVisual(1, aleatorio);
                break;
            case 3: //MAS
                print("MAS IPSP");
                kartCod2.RecItem2(items[3]);
                controlUI.IniciarRuletaVisual(1, aleatorio);
                break;
        }
    }
    
}
