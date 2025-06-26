using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlladorEscenas : MonoBehaviour
{
    public static ControlladorEscenas Instancia;

    [SerializeField] private GameObject panelConfirmacion;

    [SerializeField] GameObject panelOpciones;

    private void Awake()
    {
        // Si ya hay una instancia y no somos nosotros, destruimos este clon
        if (Instancia != null && Instancia != this)
        {
            Destroy(gameObject);
            return;
        }

        Instancia = this;
        //DontDestroyOnLoad(gameObject); // Mantiene el objeto al cambiar de escena
    }

    public void CambiarEscena(int idiceEscena)
    {      
        SceneManager.LoadScene(idiceEscena);        
    }

    public void MostrarPanelSalir()
    {
        panelConfirmacion.SetActive(true);
    }

    public void MostrarOpciones()
    {
        panelOpciones.SetActive(true);
    }

    public void OcultarOpciones()
    {
        panelOpciones.SetActive(false);
    }

    public void PanelSalir(bool respuesta)
    {   
        if (respuesta)
        {
            //detecta en que plataforma esta corriendo el ejecutable y actua dependiendo de eso
            //en este caso en el editor de unity nos saca del modo play y en cualquier otra plataforma se CIERRA        
            #if UNITY_EDITOR
                        UnityEditor.EditorApplication.isPlaying = false;
            #else
                            Application.Quit();
            #endif
        }
        else if (!respuesta)
        {
            panelConfirmacion.SetActive(false);
        }
    }

}
