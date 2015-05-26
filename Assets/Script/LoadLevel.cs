using UnityEngine;
using System.Collections;
using System.IO;

public class LoadLevel : MonoBehaviour {

	public GameObject[,] m_LevelArray;

	public GameObject[] m_BlockLibrary;
	private Block m_BlockScript;

	private int m_LevelSize;

	//META
	public string m_SaveName;
	private string m_SaveData;


	private string m_ShortMemory;

	// Use this for initialization
	void Start () 
	{
		m_SaveData=System.IO.File.ReadAllText(Application.dataPath + "\\SaveLevel\\" + m_SaveName + ".txt");
		System.IO.StringReader sr = new StringReader(m_SaveData);

		

		while(sr.Read().Parse!=';')
		{

		}

		for (int i = 0; i < m_LevelSize; i++)
		{
			for (int y = 0; y < m_LevelSize; y++)
			{

			}
		}

	}
	
	
}
