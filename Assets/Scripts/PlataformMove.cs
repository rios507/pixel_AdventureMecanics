using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class plataformmove : MonoBehaviour
{
	public GameObject objectmove;

	public Transform StartPoint;
	public Transform EndPoint;

	public float Speed;

	private Vector3 MoveIn;
	// Start is called before the first frame update
	void Start()
	{
		MoveIn = EndPoint.position;
	}

	// Update is called once per frame
	void Update()
	{
		objectmove.transform.position = Vector3.MoveTowards(objectmove.transform.position, MoveIn, Speed * Time.deltaTime);

		if (objectmove.transform.position == EndPoint.position)
		{
			MoveIn = StartPoint.position;
		}
		if (objectmove.transform.position == StartPoint.position)
		{
			MoveIn = EndPoint.position;
		}
	}

}