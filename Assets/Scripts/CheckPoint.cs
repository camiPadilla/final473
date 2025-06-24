using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager GameManager;

    GameManager gamCode;
    void Start()
    {
        gamCode = GameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("kart") || other.CompareTag("kart2")) {
            print("CUENTAAA");
            gamCode.cont +=1 ;
            gamCode.ContVueltas();
        }
    }
}
