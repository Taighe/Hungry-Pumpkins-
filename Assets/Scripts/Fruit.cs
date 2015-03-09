using UnityEngine;
using System.Collections;

public class Fruit : MonoBehaviour 
{
	public enum eFruit
	{
		CHILI,
		APPLE,
		BANNANA,
		GRAPES,
		WATERMELON,
		CARROT,
		SPINACH
	};
	
	public eFruit m_type;
	GameObject m_info;
	GameObject m_buffs;
	bool m_passive;
	GameObject m_collectedFruit;
	public GameObject m_fruitPrefab;
	public GameObject m_player;
	public float m_weight;
	public GameObject m_pointerFruit;

	// Use this for initialization
	void Start () 
	{
		m_collectedFruit = GameObject.Find ("GUI").transform.FindChild("CollectedFruit").gameObject;
		m_buffs = GameObject.Find ("GUI").transform.FindChild("Buffs").gameObject;
		m_player = GameObject.Find ("Player");

		m_info = GameObject.Find ("Info");
	}

	// Update is called once per frame
	void Update () 
	{
		transform.Rotate (0, 0.5f, 0);
	}

	public void CollectFruit()
	{
		GameObject fruit;
				
		fruit = (GameObject)Instantiate(m_fruitPrefab);
		fruit.transform.parent = m_collectedFruit.transform;
		fruit.GetComponent<Fruit> ().m_type = m_type;
		fruit.GetComponent<Fruit> ().m_weight = m_weight;
		fruit.GetComponent<Fruit>().m_player = m_player;
		fruit.transform.SetAsFirstSibling();
	}

	public void EatFruit()
	{
		m_info.GetComponent<Info> ().m_text = "Player ate a " + m_type;
		if(m_type == eFruit.CHILI)
		{

		}
		Destroy (gameObject);
	}

	public void ThrowFruit()
	{
		if(m_player.GetComponent<Player>().m_closestPumpkin != null)
		{
			m_player.GetComponent<Player>().m_closestPumpkin.GetComponent<HungryPumpkin>().Feed(m_weight);
			Destroy(gameObject);
		}
		else
		{
			m_info.GetComponent<Info> ().m_text = "Get close to a Hungry Pumpkin!";
		}

	}

	public void Passive()
	{
		if (m_passive == true) { return; }


		if(m_type == eFruit.WATERMELON)
		{
			GameObject fruit;
			fruit = (GameObject)Instantiate(m_fruitPrefab);

			fruit.transform.position = new Vector3(-1,0,0);
			fruit.transform.parent = m_buffs.transform;
			fruit.GetComponent<Fruit>().m_player = m_player;
			fruit.GetComponent<Fruit>().m_pointerFruit = this.gameObject;

		}

		m_passive = true;
	}

	public string Debuff()
	{
		string debuff;
		if(m_type == eFruit.WATERMELON)
		{
			float speed = m_player.GetComponent<CharacterMotor>().movement.maxForwardSpeed;
			speed = speed - (speed / 2);
			m_player.GetComponent<CharacterMotor>().movement.maxForwardSpeed = speed;
			
			speed = m_player.GetComponent<CharacterMotor>().movement.maxSidewaysSpeed;
			speed = speed - (speed / 2);
			m_player.GetComponent<CharacterMotor>().movement.maxSidewaysSpeed = speed;
			
			speed = m_player.GetComponent<CharacterMotor>().movement.maxBackwardsSpeed;
			speed = speed - (speed / 2);
			m_player.GetComponent<CharacterMotor>().movement.maxBackwardsSpeed = speed;
			
			return debuff = m_type + " Heavy Burden: Slowed.";
			
		}

		return null;
	}
}
