using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public List<GameObject> karts; 
    public int vueltasTotales = 3;
  
    public controladorCanvas controlCanvas;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

    }
    void Start()
    {
        if (GuardaSeleccion.instancia != null)
        {
            // Eliminar modelos anteriores 
            foreach (Transform child in karts[0].transform.Find("kart"))
            {
                Destroy(child.gameObject);
            }

            foreach (Transform child in karts[1].transform.Find("kart"))
            {
                Destroy(child.gameObject);
            }

            //Instanciar modelos seleccionados como hijos
            GameObject modelo1 = Instantiate(GuardaSeleccion.instancia.PersPlayer1, karts[0].transform.Find("kart"));
            GameObject modelo2 = Instantiate(GuardaSeleccion.instancia.PersPlayer2, karts[1].transform.Find("kart"));

            //Reiniciar la posición y rotación por si acaso
            modelo1.transform.localPosition = Vector3.zero;
            modelo1.transform.localRotation = Quaternion.identity;

            modelo2.transform.localPosition = Vector3.zero;
            modelo2.transform.localRotation = Quaternion.identity;
        }
        else
        {
            Debug.LogWarning("No hay datos de selección disponibles.");
        }
    }

    private void Update()
    {
        ActualizarOrdenCarrera();
    }

    public void RegistrarCheckJugador1(karControllerv2 jugador, int idCheckpoint)
    {
        int siguiente = (jugador.cpActual + 1) % 4;

        if (idCheckpoint == siguiente)
        {
            jugador.cpActual++;

            if (jugador.cpActual >= 4)
            {
                jugador.cpActual = 0;
                jugador.vuelta++;

                print("Player1 acaba de dar una vuelta :D");

                controlCanvas.ActualizarVueltasUI(0, jugador.vuelta); // Jugador 1
            }
        }
        if (jugador.vuelta == vueltasTotales) {
            print("Juego terminado!");
            controlCanvas.MostrarFinCarrera(0);
        }
    }

    public void RegistrarCheckJugador2(karControllerv3 jugador, int idCheckpoint)
    {
        int siguiente = (jugador.cpActual + 1) % 4;

        if (idCheckpoint == siguiente)
        {
            jugador.cpActual++;

            if (jugador.cpActual >= 4)
            {
                jugador.cpActual = 0;
                jugador.vuelta++;

                print("Player2 acaba de dar una vuelta :D");

                controlCanvas.ActualizarVueltasUI(1, jugador.vuelta); // Jugador 2
            }
        }
        if (jugador.vuelta == vueltasTotales)
        {
            print("Juego terminado!");
            controlCanvas.MostrarFinCarrera(1);
        }

    }

    void ActualizarOrdenCarrera()
    {
        var j1 = karts[0].GetComponent<karControllerv2>();
        var j2 = karts[1].GetComponent<karControllerv3>();

        float prog1 = j1.ProgresoTotal(); // vuelta * 100 + cpActual
        float prog2 = j2.ProgresoTotal();

        if (prog1 > prog2)
        {
            controlCanvas.ActualizarPosicionEnCarrera(0, 0); // J1 primero
            controlCanvas.ActualizarPosicionEnCarrera(1, 1); // J2 segundo
        }
        else if (prog2 > prog1)
        {
            controlCanvas.ActualizarPosicionEnCarrera(0, 1); // J1 segundo
            controlCanvas.ActualizarPosicionEnCarrera(1, 0); // J2 primero
        }
    }

}

