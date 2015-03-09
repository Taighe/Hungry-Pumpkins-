using UnityEngine;
using System.Collections;

public class Reset : MonoBehaviour 
{
	public GameObject m_player;
	public GameObject m_buffs;
	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		m_player.GetComponent<Player> ().ResetValues ();
	}
}
