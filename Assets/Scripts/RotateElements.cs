using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class rotate : MonoBehaviour
{
    [SerializeField] float velocity;
    [SerializeField] List<GameObject> Points = new List<GameObject>();
    [SerializeField] int contador;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Points[contador].transform.rotation, velocity + Time.deltaTime);
        if (transform.rotation == Points[contador].transform.rotation)
        {
            contador++;
        }
        if (contador == Points.Count)
        {
            contador = 0;
        }
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, rotacionAc.transform.rotation, velocity);
        //if (transform.rotation == rotacionAc.transform.rotation)
        //{
        //    rotacionAc = rotacionAc == objetivoA ? ObjetivoB : objetivoA;
        //}
    }
}

