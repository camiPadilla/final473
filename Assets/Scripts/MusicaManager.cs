using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicaManager : MonoBehaviour
{
    public static MusicaManager instance;
    public AudioSource musica;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            VeriEscena();
        }
        else { 
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void VeriEscena()
    {
        string nomEscena = SceneManager.GetActiveScene().name;
        if (nomEscena != "00menuInicio" || nomEscena != "01interfazSeleccion") { 
            Destroy(gameObject);
        }
    }
}
