using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorBotones : MonoBehaviour
{
    public void Volver(int indiceVolver)
    {
        ControlladorEscenas.Instancia.CambiarEscena(indiceVolver);
    }
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            ControlladorEscenas.Instancia.CambiarEscena(3);
        }
    }    
}
