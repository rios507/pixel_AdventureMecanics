using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Move_Plataform : MonoBehaviour
{
    [SerializeField] float velocity;
    [SerializeField] List<Transform> Points;
    [SerializeField] int counter;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform item in Points)
        {
            item.SetParent(null);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Points[counter].transform.position, velocity * Time.deltaTime);
        if (transform.position == Points[counter].transform.position)
        {
            counter++;
        }
        if (counter == Points.Count)
        {
            counter = 0;
        }
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, rotacionAc.transform.rotation, velocity);
        //if (transform.rotation == rotacionAc.transform.rotation)
        //{
        //    rotacionAc = rotacionAc == objetivoA ? ObjetivoB : objetivoA;
        //}
    }
}
