using UnityEngine;
using System.Collections;

public class HungryPumpkin : MonoBehaviour 
{
	Vector3 m_scale;
	float m_size;
	Vector3 m_growth;
	// Use this for initialization
	void Start () 
	{
		m_size = 100;
		m_scale = transform.localScale;
		m_growth = m_scale;
	}
	
	// Update is called once per frame
	void Update () 
	{
		float dt = Time.deltaTime;

		if(m_growth.x > m_scale.x)
		{
			m_scale = new Vector3(m_scale.x + 1 * dt, m_scale.y + 1 * dt, m_scale.z + 1 * dt);

		}


		transform.localScale = m_scale;
	}

	void OnTriggerEnter(Collider a_other)
	{
		
		if(a_other.tag == "Player")
		{
			print ("Feed me!");
		}				
		
	} 

	public void Feed(float a_weight)
	{
		float growthRate = a_weight / 10;
		m_growth = new Vector3(m_scale.x + growthRate, m_scale.y + growthRate, m_scale.z + growthRate);
	}
}
