using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorCanvasSelector : MonoBehaviour
{
    int jugadorAct = 1;
    [SerializeField] Personajes[] listaPersonajes;
    //private int personajeSeleccionado;

    public void SelectorPersonaje(int indice)
    {
        var elegido = listaPersonajes[indice];

        if (jugadorAct == 1)
        {
            print("Jugador 1 eligió a: " + elegido.nombre);
            GuardaSeleccion.instancia.PersPlayer1 = elegido.modelo3D;
            jugadorAct = 2;
        }
        else if (jugadorAct == 2)
        {
            print("Jugador 2 eligió a: " + elegido.nombre);
            GuardaSeleccion.instancia.PersPlayer2 = elegido.modelo3D;

            // Ambos jugadores han elegido, cargar escena
            SceneManager.LoadScene(2);
        }
    }
}

    [System.Serializable]
public class Personajes
{
    public string nombre;
    public Sprite miniatura;
    public GameObject modelo3D;
}
