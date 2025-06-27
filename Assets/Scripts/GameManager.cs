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

                print("Player1 acaba de dar una vuelta :D");

                controlCanvas.ActualizarVueltasUI(0, jugador.vuelta); // Jugador 1
            }
        }
        if (jugador.vuelta == vueltasTotales) {
            print("Juego terminado!");
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

