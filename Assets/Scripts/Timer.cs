using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour 
{
	public float m_startTime;
	float m_time;
	// Use this for initialization
	void Start () 
	{
		m_time = m_startTime;
	}
	
	// Update is called once per frame
	void Update () 
	{
		m_time -= Time.deltaTime;

	}

	void OnGUI()
	{
		int t = (int)m_time;
		GUI.Label(new Rect(Screen.width - 100, 0, 50, 80),"TIME " + t.ToString());
	}
}
