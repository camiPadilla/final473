using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class controladorCanvas : MonoBehaviour
{
    [Header("Cronómetro")]
    [SerializeField] TextMeshProUGUI cronometroUI;
    float tiempo = 0f;
    bool activo = true;

    [Header("Posición en carrera")]
    [SerializeField] Image posicionUI_J1;
    [SerializeField] Image posicionUI_J2;
    [SerializeField] List<Sprite> posiciones; // 0 = 1er lugar, 1 = 2do lugar

    [Header("Vueltas")]
    [SerializeField] TextMeshProUGUI vueltaUI_J1;
    [SerializeField] TextMeshProUGUI vueltaUI_J2;

    [Header("Items")]
    [SerializeField] Image itemUIJ1;
    [SerializeField] Image itemUIJ2;
    [SerializeField] List<Sprite> items;

    [Header("Paneles Fin de Carrera")]
    [SerializeField] GameObject fondo;
    [SerializeField] GameObject panelGanadorJ1;
    [SerializeField] GameObject FraseGanadorJ1;
    [SerializeField] GameObject panelPerdedorJ2;
    [SerializeField] GameObject FrasePerdedorJ2;
    [SerializeField] GameObject panelGanadorJ2;
    [SerializeField] GameObject FraseGanadorJ2;
    [SerializeField] GameObject panelPerdedorJ1;
    [SerializeField] GameObject FrasePerdedorJ1;
    [SerializeField] GameObject botonReiniciar;

    Coroutine ruletaVisualJ1;
    Coroutine ruletaVisualJ2;
    [Range(0.75f, 1.5f)][SerializeField] float duracionRuleta = 1f;
    [Range(0.04f, 0.1f)][SerializeField] float intervaloVisual = 0.05f;

    void Start()
    {
        vueltaUI_J1.text = "0";
        vueltaUI_J2.text = "0";

        if (posiciones.Count >= 2)
        {
            posicionUI_J1.sprite = posiciones[0]; // J1 empieza 1ro
            posicionUI_J2.sprite = posiciones[1]; // J2 empieza 2do
        }
    }

    void Update()
    {
        ActivarCronometro();
        Opciones();
    }

    public void ActivarCronometro()
    {
        if (!activo) return;

        tiempo += Time.deltaTime;
        int minutos = Mathf.FloorToInt(tiempo / 60);
        int segundos = Mathf.FloorToInt(tiempo % 60);
        int milesimas = Mathf.FloorToInt((tiempo * 100) % 100);

        cronometroUI.text = $"{minutos:00}:{segundos:00}:{milesimas:00}";
    }

    public void ActualizarVueltasUI(int jugadorID, int nuevaVuelta)
    {
        if (jugadorID == 0)
            vueltaUI_J1.text = $"{nuevaVuelta}";
        else if (jugadorID == 1)
            vueltaUI_J2.text = $"{nuevaVuelta}";
    }

    public void ActualizarPosicionEnCarrera(int jugadorID, int lugar)
    {
        Sprite spriteLugar = posiciones[Mathf.Clamp(lugar, 0, posiciones.Count - 1)];

        if (jugadorID == 0)
            posicionUI_J1.sprite = spriteLugar;
        else if (jugadorID == 1)
            posicionUI_J2.sprite = spriteLugar;
    }

    public void IniciarRuletaVisual(int jugadorID, int itemFinalIndex)
    {
        if (jugadorID == 0)
        {
            if (ruletaVisualJ1 != null) StopCoroutine(ruletaVisualJ1);
            ruletaVisualJ1 = StartCoroutine(RuletaVisual(itemUIJ1, itemFinalIndex));
        }
        else if (jugadorID == 1)
        {
            if (ruletaVisualJ2 != null) StopCoroutine(ruletaVisualJ2);
            ruletaVisualJ2 = StartCoroutine(RuletaVisual(itemUIJ2, itemFinalIndex));
        }
    }

    IEnumerator RuletaVisual(Image itemUI, int itemFinalIndex)
    {
        float t = 0f;
        while (t < duracionRuleta)
        {
            int index = Random.Range(0, items.Count);
            itemUI.sprite = items[index];
            yield return new WaitForSeconds(intervaloVisual);
            t += intervaloVisual;
        }
        itemUI.sprite = items[itemFinalIndex];
    }

    public void MostrarItemEnUI(int jugadorID, int itemIndex)
    {
        if (itemIndex < 0 || itemIndex >= items.Count) return;

        if (jugadorID == 0)
            itemUIJ1.sprite = items[itemIndex];
        else if (jugadorID == 1)
            itemUIJ2.sprite = items[itemIndex];
    }

    void Opciones()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            ControlladorEscenas.Instancia.MostrarOpciones();
        }
        else if (Input.GetKeyUp(KeyCode.Escape))
        {
            Time.timeScale = 1f;
            ControlladorEscenas.Instancia.OcultarOpciones();
        }
    }
    public void MostrarFinCarrera(int jugadorID)
    {
        if (jugadorID == 0)
        {
            panelGanadorJ1.SetActive(true);
            FraseGanadorJ1.SetActive(true);
            panelPerdedorJ2.SetActive(true);
            FrasePerdedorJ2.SetActive(true);
            fondo.SetActive(true);
        }
        else
        {
            panelGanadorJ2.SetActive(true);
            FraseGanadorJ2.SetActive(true);
            panelPerdedorJ1.SetActive(true);
            FrasePerdedorJ1.SetActive(true);
            fondo.SetActive(true);
        }

        botonReiniciar.SetActive(true);
    }
}

