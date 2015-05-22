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
		}
	}

	

}
