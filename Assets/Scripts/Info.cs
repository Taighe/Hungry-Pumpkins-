using UnityEngine;
using System.Collections;

public class Info : MonoBehaviour 
{
	public string m_text; 
	// Use this for initialization
	void Start () 
	{
		m_text = "Hello World";
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	void OnGUI()
	{
		GUI.Label (new Rect (0, 50, 500, 50), m_text);
	}
}
