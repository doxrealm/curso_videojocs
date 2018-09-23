using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PartidaNueva : MonoBehaviour {

    public void CargarPartidaNueva() {
        Debug.Log("Cargando Partida Nueva");
        SceneManager.LoadScene("Partida Nueva");
    }

}
