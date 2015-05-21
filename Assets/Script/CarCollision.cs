using UnityEngine;
using System.Collections;

public class CarCollision : MonoBehaviour {

	public Car m_CarScript;

	// Use this for initialization
	void Start () {

		m_CarScript = transform.parent.GetComponent<Car>();
	}

	
	void OnCollisionEnter(Collision other)
	{
		Debug.Log("collide");
		if (other.gameObject.layer == 9)
		{
			Debug.Log("collide");
			m_CarScript.m_CanMove = false;
			m_CarScript.m_CarSpeed = 200;
			m_CarScript.m_Navmesh.enabled = false;
			m_CarScript.GetComponent<Rigidbody>().useGravity = false;
			GetComponent<Rigidbody>().useGravity = false;
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
