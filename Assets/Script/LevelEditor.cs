using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;



public class LevelEditor : MonoBehaviour {

	public GameObject[,] m_LevelArray;
	public int m_LevelSize;


	public GameObject m_BBase;
	private GameObject m_BlockInstance;

	public GameObject m_Curseur;

	private bool m_IsOKToMove;
	private float m_Delay;

	public GameObject m_Selection;

	//
	public CursorLevelEditor m_CursorScript;
	public int m_CursorPosX;
	public int m_CursorPosZ;

	private Block m_BlockScript;
	public float m_RotateMemory;

	//SAUVEGARDE
	DirectoryInfo dir = new DirectoryInfo(Application.dataPath+"\\SaveLevel");
	public string m_SaveName;
	private string m_SaveData;
	// Use this for initialization
	void Start () {

		/*
		//System.IO.FileInfo[] info = dir.GetFiles("*.*");
		int v = 0;
		foreach (FileInfo f in info)
		{
			v++;
		}

		if (v > 10)
		{
			m_SaveName = "MapEditorSave_" + v;
		}
		else
		{
			m_SaveName = "MapEditorSave_0" + v;
		}
		*/
		

		m_Curseur.transform.position = new Vector3(4, 2, 4);

		if (m_LevelSize <= 0) { m_LevelSize = 10; }
		m_LevelArray= new GameObject[m_LevelSize,m_LevelSize];

		for (int i = 0; i < m_LevelSize; i++)
		{
			for (int y = 0; y < m_LevelSize; y++)
			{
				m_BlockInstance=Instantiate(m_BBase);
				m_BlockInstance.transform.position=new Vector3(i*8,0,y*8);
				m_LevelArray[i, y] = m_BlockInstance;
			}
		}

		m_CursorPosX = 0;
		m_CursorPosZ = 0;
		m_RotateMemory = 0;
		m_IsOKToMove = true;
	}

	IEnumerator DelayMove()
	{
		yield return new WaitForSeconds(0.1f);
		m_IsOKToMove = true;
	}

	// Update is called once per frame
	void Update()
	{

		#region Curseur
		if (m_IsOKToMove)
		{
			if (Input.GetAxis("L_XAxis_1") < 0 && m_IsOKToMove)
			{
				m_Curseur.transform.position = new Vector3(m_Curseur.transform.position.x, m_Curseur.transform.position.y, m_Curseur.transform.position.z - 8);
				m_CursorPosZ--;
				m_IsOKToMove = false;
				StartCoroutine(DelayMove());

			}
			if (Input.GetAxis("L_XAxis_1") > 0 && m_IsOKToMove)
			{
				m_Curseur.transform.position = new Vector3(m_Curseur.transform.position.x, m_Curseur.transform.position.y, m_Curseur.transform.position.z + 8);
				m_CursorPosZ++;
				m_IsOKToMove = false;
				StartCoroutine(DelayMove());
			}
			if (Input.GetAxis("L_YAxis_1") < 0 && m_IsOKToMove)
			{
				m_Curseur.transform.position = new Vector3(m_Curseur.transform.position.x - 8, m_Curseur.transform.position.y, m_Curseur.transform.position.z);
				m_CursorPosX--;
				m_IsOKToMove = false;
				StartCoroutine(DelayMove());
			}
			if (Input.GetAxis("L_YAxis_1") > 0 && m_IsOKToMove)
			{
				m_Curseur.transform.position = new Vector3(m_Curseur.transform.position.x + 8, m_Curseur.transform.position.y, m_Curseur.transform.position.z);
				m_CursorPosX++;
				m_IsOKToMove = false;
				StartCoroutine(DelayMove());
			}

			if (m_Curseur.transform.position.x < 4)
			{
				m_Curseur.transform.position = new Vector3(4, m_Curseur.transform.position.y, m_Curseur.transform.position.z);
				m_CursorPosX = 0;
			}
			if (m_Curseur.transform.position.z < 4)
			{
				m_Curseur.transform.position = new Vector3(m_Curseur.transform.position.x, m_Curseur.transform.position.y, 4);
				m_CursorPosZ = 0;
			}

			if (m_Curseur.transform.position.x > ((m_LevelSize - 1) * 8)+4)
			{
				m_Curseur.transform.position = new Vector3(((m_LevelSize - 1) * 8)+4, m_Curseur.transform.position.y, m_Curseur.transform.position.z);
				m_CursorPosX = m_LevelSize - 1;
			}
			if (m_Curseur.transform.position.z > ((m_LevelSize - 1) * 8)+4)
			{
				m_Curseur.transform.position = new Vector3(m_Curseur.transform.position.x, m_Curseur.transform.position.y, ((m_LevelSize - 1) * 8)+4);
				m_CursorPosZ = m_LevelSize - 1;
			}
		}







		#endregion

		#region Pose

		if (Input.GetButton("A_1"))
		{
			Destroy(m_LevelArray[m_CursorPosX, m_CursorPosZ]);
			
			m_BlockInstance = Instantiate(m_CursorScript.m_Image_script.m_Block) as GameObject;
			m_BlockInstance.transform.position = new Vector3(m_CursorPosX * 8, 0, m_CursorPosZ * 8);
			m_LevelArray[m_CursorPosX, m_CursorPosZ] = m_BlockInstance;
			m_BlockScript = m_LevelArray[m_CursorPosX, m_CursorPosZ].GetComponent<Block>();
			m_BlockScript.m_Graphisme.transform.localEulerAngles += new Vector3(0, m_RotateMemory, 0);
		}
		if (Input.GetButton("B_1"))
		{
			if (m_LevelArray[m_CursorPosX, m_CursorPosZ]!=null)
			{
				Destroy(m_LevelArray[m_CursorPosX, m_CursorPosZ]);
			}
			
		}

		#endregion

		#region Rotation
		if (Input.GetButtonDown("X_1"))
		{
			m_BlockScript = m_LevelArray[m_CursorPosX, m_CursorPosZ].GetComponent<Block>();
			m_BlockScript.m_Graphisme.transform.localEulerAngles += new Vector3(0, 90, 0);
			m_RotateMemory += 90;
				//new Vector3(m_LevelArray[m_CursorPosX, m_CursorPosZ].transform.localEulerAngles.x+90, m_LevelArray[m_CursorPosX, m_CursorPosZ].transform.localEulerAngles.y, m_LevelArray[m_CursorPosX, m_CursorPosZ].transform.localEulerAngles.z);
		}
		if (Input.GetButtonDown("Y_1"))
		{
			m_BlockScript=m_LevelArray[m_CursorPosX, m_CursorPosZ].GetComponent<Block>();
			m_BlockScript.m_Graphisme.transform.localEulerAngles -= new Vector3(0, 90, 0);
			m_RotateMemory -= 90;
				//= new Vector3(m_LevelArray[m_CursorPosX, m_CursorPosZ].transform.localEulerAngles.x-90, m_LevelArray[m_CursorPosX, m_CursorPosZ].transform.localEulerAngles.y, m_LevelArray[m_CursorPosX, m_CursorPosZ].transform.localEulerAngles.z);

		}
		#endregion

		#region Sauvegarde
		if (Input.GetButton("Start_1") && m_IsOKToMove)
		{
			m_SaveData = m_LevelSize+";";

			for (int i = 0; i < m_LevelSize; i++)
			{
				for (int y = 0; y < m_LevelSize; y++)
				{
					m_BlockScript = m_LevelArray[i,y].GetComponent<Block>();
					m_SaveData += m_LevelArray[i, y].name + "," + m_BlockScript.m_Graphisme.transform.localEulerAngles.y+";";
				}
			}
			m_SaveData += "}";
			File.WriteAllText(Application.dataPath + "\\SaveLevel\\"+m_SaveName+".txt", m_SaveData);
		}
		#endregion

	}

}
