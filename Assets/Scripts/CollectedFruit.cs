using UnityEngine;
using System.Collections;

public class CollectedFruit : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		for(int i = 0; i < transform.childCount; i++)
		{
			transform.GetChild(i).transform.transform.position = new Vector3(0.1f + (0.1f * i), 0.9f, 0.0f);
			transform.GetChild(i).transform.rotation = transform.rotation;
			transform.GetChild(i).GetComponent<Fruit>().Passive();
		}


		if(Input.GetButtonDown("Fire1"))
		{
			transform.GetChild(0).GetComponent<Fruit>().ThrowFruit();
		}

		if(Input.GetButtonDown("Fire2"))
		{
			transform.GetChild(0).GetComponent<Fruit>().EatFruit();
		}

	}
}
