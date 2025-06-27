using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardaSeleccion : MonoBehaviour
{
    public static GuardaSeleccion instancia;

    public GameObject PersPlayer1;
    public GameObject PersPlayer2;

    // Start is called before the first frame update
    private void Awake()
    {
        if (instancia != null && instancia != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
    }

        // Update is called once per frame
        void Update()
    {
        
    }
}
