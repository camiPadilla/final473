using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public int idCheckpoint;
    public List<GameObject> karts;
    karControllerv2 kartCod;
    karControllerv3 kartCod2;

    public void Start()
    {
        kartCod = karts[0].GetComponent<karControllerv2>();
        kartCod2 = karts[1].GetComponent<karControllerv3>();
    }
    private void OnTriggerEnter(Collider other)
    {
        // ¿Este collider tiene el script del jugador 1?
        if (other.CompareTag("kart"))
        {
            print("Acaba de pasar el jugador1");
            GameManager.instance.RegistrarCheckJugador1(kartCod, idCheckpoint);
        }
        // ¿O es el del jugador 2?
        else if (other.CompareTag("kart2"))
        {
  
            print("Acaba de pasar el jugador2");
            GameManager.instance.RegistrarCheckJugador2(kartCod2, idCheckpoint);
        }
    }
}


