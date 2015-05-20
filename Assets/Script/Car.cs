using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour {


	public int m_BlockNumber;

	public NavMeshAgent m_Navmesh;
	public Vector3 m_BaseRotation;

	// Use this for initialization
	void Start () {
		m_BlockNumber = 0;
		m_BaseRotation = this.transform.eulerAngles;
		m_Navmesh = GetComponent<NavMeshAgent>();
		m_Navmesh.speed = 5;

	}
	
	// Update is called once per frame
	void Update () {

		this.transform.eulerAngles = new Vector3(m_BaseRotation.x, this.transform.eulerAngles.y, m_BaseRotation.z);
		Debug.Log("Gachette Droite " + Input.GetAxis("TriggersR_1"));
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.layer==8)
		{
			m_BlockNumber = other.gameObject.GetComponent<Gate>().m_GateNumber;
		}
	}

}
