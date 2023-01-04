using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    //cambio de escenas 

    //inicio de los asteroides starworianos (ns que coño he puesto en vez de decir star wars xd)
    public void Play(){

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    //te vas a tomar por saco ^^
    public void Exit(){

        Debug.Log("Exit...");
        Application.Quit();
    }
}
