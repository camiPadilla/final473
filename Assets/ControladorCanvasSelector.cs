using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorCanvasSelector : MonoBehaviour
{
    [SerializeField] Personajes[] listaPersonajes ;
    //private int personajeSeleccionado;

    public void SelectorPersonaje(int indice)
    {
        var elegido = listaPersonajes[indice];
        Debug.Log("Seleccionado: " + elegido.nombre);
        SceneManager.LoadScene(2);
    }
}

[System.Serializable]
public class Personajes
{
    public string nombre;
    public Sprite miniatura;
    public GameObject modelo3D;
}
