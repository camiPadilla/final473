using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controladorCanvasInicio : MonoBehaviour
{
    [SerializeField] private GameObject panelConfirmacion;
    public void JugarButton()
    {
        SceneManager.LoadScene(1);
    }

    public void OpcionesButton()
    {
        SceneManager.LoadScene(3);
    }
    public void MostrarPanelSalir()
    {      
        panelConfirmacion.SetActive(true);

        
    }

    public void SalirSi()
    {
        //detecta en que plataforma esta corriendo el ejecutable y actua dependiendo de eso
        //en este caso en el editor de unity nos saca del modo play y en cualquier otra plataforma se CIERRA        
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void SalirNo()
    {
        panelConfirmacion.SetActive(false);
    }
}
