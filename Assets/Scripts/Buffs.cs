using UnityEngine;
using System.Collections;

struct Buff
{
	public GameObject m_fruit;
	public int m_stack;
	public string m_info;
}

public class Buffs : MonoBehaviour 
{
	Buff[] m_buffs;
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		m_buffs = new Buff[10];
		for(int i = 0; i < transform.childCount; i++)
		{
			m_buffs[i].m_fruit = transform.GetChild(i).gameObject;
			m_buffs[i].m_info = transform.GetChild(i).GetComponent<Fruit>().Debuff();
			m_buffs[i].m_stack = transform.GetChild(i).childCount + 1;

			for(int j = 0; j < transform.GetChild(i).childCount; j++)
			{
				transform.GetChild(i).GetChild(j).GetComponent<Fruit>().Debuff();
				if(transform.GetChild(i).GetChild(j).GetComponent<Fruit>().m_pointerFruit == null) 
				{ 
					Destroy (transform.GetChild(i).GetChild(j).gameObject); 
				}
			}
			if(transform.GetChild(i).GetComponent<Fruit>().m_pointerFruit == null) 
			{ 
				Destroy (transform.GetChild(i).gameObject); 
			}
			 
		}

		for(int i = 0; i < transform.childCount; i++)
		{

			for(int j = i + 1; j < transform.childCount; i++)
			{
				if((string)m_buffs[i].m_info == (string)m_buffs[j].m_info)
				{
					transform.GetChild(j).parent = transform.GetChild(i).transform;
				}				
			}

		}
	}

	void OnGUI()
	{
		for(int i = 0; i < transform.childCount; i++)
		{
			GUI.Label (new Rect(Screen.width - 200, Screen.height / 2, 200, 100),  
			           m_buffs[i].m_info.ToString() + " x " + m_buffs[i].m_stack.ToString());
		}
	}

	public void Clear()
	{
		for(int i = 0; i < transform.childCount; i++)
		{
			Destroy(transform.GetChild(i).gameObject);
		}
	}
}
