using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameExit : MonoBehaviour {

    /**
     * Por alguna razon no se detecta 
     * 
     */
    public void SalirJuego () {
            Debug.Log("Saliendo del juego...");
            Application.Quit();
    }

}
