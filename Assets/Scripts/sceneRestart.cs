using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneRestart : MonoBehaviour
{
    [SerializeField]int indice;
    public void scenecharge()
    {
        SceneManager.LoadScene(indice);
        Debug.Log("scenerestart");
    }
}
