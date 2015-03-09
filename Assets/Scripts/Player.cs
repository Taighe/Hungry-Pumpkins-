using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	public GameObject m_closestPumpkin;
	public float test;
	// Use this for initialization
	void Start () 
	{

	}

	void OnTriggerEnter(Collider a_other)
	{

		if(a_other.tag == "Fruit")
		{
			a_other.GetComponent<Fruit>().CollectFruit();
			Destroy(a_other.gameObject);
		}

		if(a_other.name == "Hungry Pumpkin")
		{
			m_closestPumpkin = a_other.gameObject;
		}

	}

	void OnTriggerExit(Collider a_other)
	{		
		if(a_other.name == "Hungry Pumpkin")
		{
			m_closestPumpkin = null;
		}

	}
	// Update is called once per frame
	void Update () 
	{

	}

	public void ResetValues()
	{
		GetComponent<CharacterMotor> ().movement.maxForwardSpeed = GetComponent<CharacterMotor> ().movement.o_maxForwardSpeed;
		GetComponent<CharacterMotor> ().movement.maxSidewaysSpeed = GetComponent<CharacterMotor> ().movement.o_maxSidewaysSpeed;
		GetComponent<CharacterMotor> ().movement.maxBackwardsSpeed = GetComponent<CharacterMotor> ().movement.o_maxBackwardsSpeed;
	}
}
