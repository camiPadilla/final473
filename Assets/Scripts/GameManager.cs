using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> checkPoints;
    public List<GameObject> karts;

    public int cont;

    int vuelta = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vuelta == 4) {
            print("juego terminado");
        }
    }

    public void ContVueltas() {
        switch (cont) { 
            case 4:
                vuelta = 1; break;
            case 8:
                vuelta = 2; break;
            case 12:
                vuelta = 3; break;
            case 16:
                vuelta = 4; break;
        }
    }
    public void RegistrarCheck() { 
        
    }
}
