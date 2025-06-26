using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class controladorCanvas : MonoBehaviour
{
    //variables para cronometroUI
    [SerializeField] TextMeshProUGUI cronometroUI;
    float tiempo = 0f;
    bool activo = true;
    //variables para posicion
    [SerializeField] Image posicionUI;
    [SerializeField] List<Sprite> posiciones;
    int LugarVariable = 1;
    //variables para num Vuelta
    [SerializeField] TextMeshProUGUI vueltaUI;
    int vuelta = 1;
    //variables para itemrandom
    [SerializeField] Image itemUI;
    [SerializeField] List<Sprite> items;
    private Coroutine ruletaItems;
    [Range(0.75f,1f)]
    [SerializeField] float tiempoTotal;
    [Range(0.045f, 0.085f)]
    [SerializeField] float intervalo;
    //WaitForSeconds intervaloRandom = new WaitForSeconds(0.01f);
    //variables para posicion grafica
    [SerializeField] List<Transform> miniaturasPersonajes;
    public ObjetosManager objMan;
    public GameManager gameManager;
    public controladorCanvas canvas;


    public void IniciarCorrutinaItems(System.Action<int> callback)
    {
        if (ruletaItems != null)
            StopCoroutine(ruletaItems);

        ruletaItems = StartCoroutine(RandomizarItems(callback));
    }


    public IEnumerator RandomizarItems(System.Action<int> callback)
    {
        float tiempoTranscurrido = 0f;
        int indexItemFinal = 0;

        while (tiempoTranscurrido < tiempoTotal)
        {
            int indexItem = Random.Range(0, items.Count);
            itemUI.sprite = items[indexItem];
            yield return new WaitForSeconds(intervalo);
            tiempoTranscurrido += intervalo;
        }

        indexItemFinal = Random.Range(0, items.Count);
        itemUI.sprite = items[indexItemFinal];

        callback(indexItemFinal); // devuelve el ítem real
    }

    public void MostrarItemEnUI(int item)
    {
        if (item >= 0 && item < items.Count)
        {
            itemUI.sprite = items[item];
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //que haga el get component del objeto manager
        //cronometroUI.text = "modificado";
        vueltaUI.text = $"{vuelta}";
        posicionUI.sprite = posiciones[0];
    }

    public void ActivarCronometro()
    {
        if (activo)
        {
            tiempo += Time.deltaTime;
            ActualizarCronometro();
        }
    }

    void ActualizarCronometro()
    {
        int minutos = Mathf.FloorToInt(tiempo / 60);
        int segundos = Mathf.FloorToInt(tiempo % 60);
        int milesimas = Mathf.FloorToInt((tiempo * 100) % 100);

        cronometroUI.text = $"{minutos:00}:{segundos:00}:{milesimas:00}";
    }

    void ActualizarVueltas()
    {
        //Cambiar para que se vea las vueltas
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            vuelta++;
            if (vuelta > 3)
            {
                vuelta = 3;
                
            }
            vueltaUI.text = $"{vuelta}";
        }
    }

    void ActualizarPosicionNumerica()
    {
        int limite = posiciones.Count - 1;
        //cambiar segun la posicion sin introducir botones
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (LugarVariable < limite)
            {
                LugarVariable++;
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (LugarVariable > 0)
            {
                LugarVariable--;
            }
        }
        if (LugarVariable >= 0 && LugarVariable <= limite)
        {
           posicionUI.sprite = posiciones[LugarVariable];
        }
    }

    void ActivarRandom()
    {
        //cambiar eso para que se relacione con el objetos manager
        if (Input.GetKeyDown(KeyCode.P))
        {
           
            Debug.Log("funca");
        }
    }
    void Opciones()
    {
        bool apretado = Input.GetKeyDown(KeyCode.Escape);
        if (apretado)
        {
            Time.timeScale = 0f;
            ControlladorEscenas.Instancia.MostrarOpciones();
        }
        else if (!apretado)
        {
            Time.timeScale = 1f;
            ControlladorEscenas.Instancia.OcultarOpciones();
        }
    }

    //void CambiarPosicionesGrafico()
    //{
    //    if (Input.GetKeyDown(KeyCode.O))
    //    {
    //        //posicion
    //        Vector3 temp = miniaturasPersonajes[1].localPosition;

    //        miniaturasPersonajes[1].localPosition = miniaturasPersonajes[2].localPosition;
    //        miniaturasPersonajes[2].localPosition = temp;
    //    }
    //}
    // Update is called once per frame
    void Update()
    {
        ActivarCronometro();
        ActualizarVueltas();
        ActualizarPosicionNumerica();
        ActivarRandom();
        Opciones();
        //CambiarPosicionesGrafico();
    }
   
}
