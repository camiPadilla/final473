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
    [SerializeField] Image posicionUI_J1;
    [SerializeField] Image posicionUI_J2;
    [SerializeField] List<Sprite> posiciones;
    //variables para num Vuelta
    [SerializeField] TextMeshProUGUI vueltaUI;
    //variables para itemrandom
    [SerializeField] Image itemUI;
    [SerializeField] List<Sprite> items;
    private Coroutine ruletaVisual;
    [Range(0.75f, 1.5f)][SerializeField] float duracionRuleta = 1f;
    [Range(0.04f, 0.1f)][SerializeField] float intervaloVisual = 0.05f;
    //WaitForSeconds intervaloRandom = new WaitForSeconds(0.01f);
    //variables para posicion grafica
    [SerializeField] List<Transform> miniaturasPersonajes;
    public ObjetosManager objMan;
    public GameManager gameManager;
    public controladorCanvas canvas;




    public void IniciarCorrutinaItems()
    {
        if (ruletaVisual != null)
            StopCoroutine(ruletaVisual);

        ruletaVisual = StartCoroutine(RuletaVisual());
    }


    private IEnumerator RuletaVisual()
    {
        float tiempo = 0f;

        while (tiempo < duracionRuleta)
        {
            int index = Random.Range(0, items.Count);
            itemUI.sprite = items[index];

            yield return new WaitForSeconds(intervaloVisual);
            tiempo += intervaloVisual;
        }

        // Se queda en uno al azar al final
        int final = Random.Range(0, items.Count); ;
        itemUI.sprite = items[final];
    }


    public void MostrarItemEnUI(int item)
    {
            itemUI.sprite = items[item];
    }
    // Start is called before the first frame update
    void Start()
    {
        int vuelta = 0;
        vueltaUI.text = $"{vuelta}";

        // Posición inicial
        if (posiciones.Count >= 2)
        {
            posicionUI_J1.sprite = posiciones[0]; // 1er
            posicionUI_J2.sprite = posiciones[1]; // 2do
        }
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

    public void ActualizarVueltasUI(int nuevaVuelta)
    {
        vueltaUI.text = $"{nuevaVuelta}";
    }

    public void ActualizarPosicionEnCarrera(int jugadorID, int lugar)
    {
        int indice = Mathf.Clamp(lugar, 0, posiciones.Count - 1);

        if (jugadorID == 0)
            posicionUI_J1.sprite = posiciones[indice];
        
        else if (jugadorID == 1)
            posicionUI_J2.sprite = posiciones[indice];
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
        //ActualizarVueltas();
        ActivarRandom();
        Opciones();
        //CambiarPosicionesGrafico();
    }
   
}
