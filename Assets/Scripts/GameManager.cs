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
        
    }

    public void ContVueltas() {
        switch (cont) { 
            case 1:
                vuelta = 1; break;
            case 2:
                vuelta = 2; break;
            case 3:
                vuelta = 3; break;
            case 4:
                vuelta = 4; 
                   print("juego terminado");break;
        }
    }
}
