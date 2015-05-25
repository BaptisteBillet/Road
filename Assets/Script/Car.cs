using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour {

	public int m_PlayerNumber;
	public int m_BlockNumber;

	public NavMeshAgent m_Navmesh;
	public Vector3 m_BaseRotation;

	public float m_CarSpeed;
	public float m_CarAcceleration;
	public float m_CarDesceleration;
	public float m_CurrentCarSpeed;

	public bool m_CanMove;
	public bool m_IsCarIsInACorner;
	
	public GameObject m_CarMesh;
	public float m_CarMeshRotateInCorner;
	// Use this for initialization
	void Start () {
		m_BlockNumber = 0;
		m_CurrentCarSpeed = 0;
		m_BaseRotation = this.transform.eulerAngles;
		m_Navmesh = GetComponent<NavMeshAgent>();
		m_CanMove = true;

	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(Input.GetAxis("TriggersR_1"));
		switch(m_PlayerNumber)
		{
			case 1:
				if (m_CanMove)
				{
					this.transform.eulerAngles = new Vector3(m_BaseRotation.x, this.transform.eulerAngles.y, m_BaseRotation.z);
					
					if (Input.GetAxis("TriggersR_1") > 0)
					{
						m_CurrentCarSpeed += m_CarAcceleration; 
					}
					if (m_CurrentCarSpeed > m_CarSpeed)
					{
						m_CurrentCarSpeed = m_CarSpeed; 
					}

					if (Input.GetAxis("TriggersR_1") <= 0)
					{
						m_CurrentCarSpeed -= m_CarDesceleration; 
					}
					if (Input.GetButton("B_1"))
					{
						m_CurrentCarSpeed -= m_CarDesceleration * 3;
					}
					if (m_CurrentCarSpeed < 0)
					{
						m_CurrentCarSpeed = 0;
					}
					m_Navmesh.speed = Input.GetAxis("TriggersR_1") * m_CurrentCarSpeed;
				}
				break;
			case 2:
				if (m_CanMove)
				{
					this.transform.eulerAngles = new Vector3(m_BaseRotation.x, this.transform.eulerAngles.y, m_BaseRotation.z);

					if (Input.GetAxis("TriggersR_2") > 0)
					{
						m_CurrentCarSpeed += m_CarAcceleration;
					}
					if (m_CurrentCarSpeed > m_CarSpeed)
					{
						m_CurrentCarSpeed = m_CarSpeed;
					}

					if (Input.GetAxis("TriggersR_2") <= 0)
					{
						m_CurrentCarSpeed -= m_CarDesceleration;
					}
					if (Input.GetButton("B_2"))
					{
						m_CurrentCarSpeed -= m_CarDesceleration * 3;
					}
					if (m_CurrentCarSpeed < 0)
					{
						m_CurrentCarSpeed = 0;
					}
					m_Navmesh.speed = Input.GetAxis("TriggersR_2") * m_CurrentCarSpeed;
				}
				break;




		}


		}

		

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.layer==8)
		{
			m_BlockNumber = other.gameObject.GetComponent<Gate>().m_GateNumber;
			/*
			if(other.gameObject.transform.parent.transform.parent.GetComponent<Block>().m_BlockType=="straight")
			{
				m_IsCarIsInACorner = false;
				m_CarMesh.transform.localEulerAngles = new Vector3(m_CarMesh.transform.localEulerAngles.x, m_CarMesh.transform.localEulerAngles.y, 0);
			}
			if (other.gameObject.transform.parent.transform.parent.GetComponent<Block>().m_BlockType == "corner")
			{
				m_IsCarIsInACorner = true;
				m_CarMesh.transform.localEulerAngles = new Vector3(m_CarMesh.transform.localEulerAngles.x, m_CarMesh.transform.localEulerAngles.y, m_CarMeshRotateInCorner);
			}
			*/

		}



	}

	

}
