using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public List<GameObject> karts; // 0 = Jugador 1, 1 = Jugador 2
    public int vueltasTotales = 3;

    public controladorCanvas controlCanvas;

    private void Awake()
    {
        instance = this;
        
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

                Debug.Log($"Jugador 1 completó vuelta {jugador.vuelta}");

                controlCanvas.ActualizarVueltasUI(jugador.vuelta); // 0 = Jugador 1
            }
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

                Debug.Log($"Jugador 2 completó vuelta {jugador.vuelta}");

            }
        }
    }

    void ActualizarOrdenCarrera()
    {
        karControllerv2 j1 = karts[0].GetComponent<karControllerv2>();
        karControllerv3 j2 = karts[1].GetComponent<karControllerv3>();

        float prog1 = j1.ProgresoTotal();
        float prog2 = j2.ProgresoTotal();

        if (prog2 > prog1)
        {
            // Intercambiar visualmente
            controlCanvas.ActualizarPosicionEnCarrera(1, 0); // Jugador 2 va primero
            controlCanvas.ActualizarPosicionEnCarrera(0, 1); // Jugador 1 va segundo
        }
        else
        {
            controlCanvas.ActualizarPosicionEnCarrera(0, 0); // Jugador 1 va primero
            controlCanvas.ActualizarPosicionEnCarrera(1, 1); // Jugador 2 va segundo
        }
    }
}

