using UnityEngine;
using System.Collections;

public class CarCollision : MonoBehaviour {

	public Car m_CarScript;
	public float m_DelayRapatriement;
	private bool m_IsRapatriement;

	private GameObject m_Navigation;
	private Navigation m_NavigationScript;

	public int m_CarSpeedOut;


	// Use this for initialization
	void Start () {
		m_Navigation = GameObject.Find("NavDirector");
		m_NavigationScript = m_Navigation.GetComponent<Navigation>();
		m_IsRapatriement = false;
		m_CarScript = GetComponent<Car>();
	}


	IEnumerator Rapatriement()
	{
		m_CarScript.m_CurrentCarSpeed = 0;
		yield return new WaitForSeconds(1);
		GetComponent<Rigidbody>().useGravity = true;

		yield return new WaitForSeconds(m_DelayRapatriement);
		//this.transform.position=m_CarScript.m_BlockNumber
		GetComponent<Rigidbody>().velocity *= 0;
		this.transform.position = m_NavigationScript.m_BlockListNavMesh[m_CarScript.m_BlockNumber].GetComponent<Block>().m_BlockGateScript.transform.position;
		m_CarScript.m_Navmesh.enabled = true;
		//GetComponent<Rigidbody>().useGravity = true;
		m_IsRapatriement = false;
		m_CarScript.m_CanMove = true;
	}

	void OnCollisionEnter(Collision other)
	{

		if (other.gameObject.layer == 10 && m_IsRapatriement == false && m_CarScript.m_CurrentCarSpeed>=m_CarSpeedOut)
		{
			GetComponent<Rigidbody>().velocity = new Vector3(1, 1, 1);
			GetComponent<Rigidbody>().velocity *= 5;
			m_CarScript.m_CanMove = false;
			m_IsRapatriement = true;
			m_CarScript.m_CurrentCarSpeed = 200;
			m_CarScript.m_Navmesh.enabled = false;
			GetComponent<Rigidbody>().useGravity = false;
			StartCoroutine(Rapatriement());
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
