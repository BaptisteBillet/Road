using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Navigation : MonoBehaviour {

	public List<GameObject> m_BlockListNavMesh = new List<GameObject>();
	private Block m_BlockScript;


	public GameObject m_Car1;
	private Car m_Car1Script;

	public int m_BlockNumber;
	public int m_NextBlock;
	private int m_BlockNumberTotal;

	private int m_BlockNumberCheckPoint1;
	private int m_BlockNumberCheckPoint2;

	// Use this for initialization
	void Start () {
		m_BlockNumber = 0;
		m_BlockNumberTotal = m_BlockListNavMesh.Count;

		
		foreach(GameObject go in m_BlockListNavMesh)
		{
			m_BlockScript = go.GetComponent<Block>();
			m_BlockScript.m_BlockNumber = m_BlockNumber;
			m_BlockScript.m_BlockGateScript.m_GateNumber = m_BlockNumber;
			m_BlockNumber++;
		}
		m_BlockNumber = 0;

		m_BlockNumberCheckPoint1 = m_BlockNumberTotal / 3;
		m_BlockNumberCheckPoint2 = (m_BlockNumberTotal / 3) * 2;

		m_Car1Script = m_Car1.GetComponent<Car>();
		//m_Car1.transform.position = m_BlockListNavMesh[0].transform.position;
		//m_BlockScript=m_BlockListNavMesh[m_BlockNumberCheckPoint1].GetComponent<Block>();
		m_Car1Script.m_Navmesh.destination = new Vector3(m_BlockListNavMesh[m_BlockNumberCheckPoint1].transform.position.x + 4, m_BlockListNavMesh[m_BlockNumberCheckPoint1].transform.position.y, m_BlockListNavMesh[m_BlockNumberCheckPoint1].transform.position.z+4);
	}
	
	// Update is called once per frame
	void Update () {
		m_BlockNumber = m_Car1Script.m_BlockNumber;

		
		if(m_BlockNumber==m_BlockNumberTotal-1) //Retour à 0;
		{
			m_BlockScript = m_BlockListNavMesh[0].GetComponent<Block>();
			m_Car1Script.m_Navmesh.destination = m_BlockListNavMesh[0].GetComponent<Block>().m_BlockGateScript.transform.position;
				/*new Vector3(m_BlockListNavMesh[0].transform.position.x + m_BlockScript.m_BlockGateScript.m_DeltaX, m_BlockListNavMesh[0].transform.position.y, m_BlockListNavMesh[0].transform.position.z + m_BlockScript.m_BlockGateScript.m_DeltaZ);*/
		}
		else
		{
			m_BlockScript = m_BlockListNavMesh[m_BlockNumber + 1].GetComponent<Block>();
			m_Car1Script.m_Navmesh.destination = m_BlockListNavMesh[m_BlockNumber + 1].GetComponent<Block>().m_BlockGateScript.transform.position;
				/*new Vector3(m_BlockListNavMesh[m_BlockNumber + 1].transform.position.x + m_BlockScript.m_BlockGateScript.m_DeltaX, 
															m_BlockListNavMesh[m_BlockNumber + 1].transform.position.y, 
															m_BlockListNavMesh[m_BlockNumber + 1].transform.position.z + m_BlockScript.m_BlockGateScript.m_DeltaZ);*/
		}
		

		
	}
}
