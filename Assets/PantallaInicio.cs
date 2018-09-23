using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PantallaInicio : MonoBehaviour {

    public void CargarMenuInicio()
    {
        Debug.Log("De vuelta a pantalla inicial");
        SceneManager.LoadScene("Partida Inicial");
    }
}
