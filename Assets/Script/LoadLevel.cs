using UnityEngine;
using System.Collections;
using System.IO;

public class LoadLevel : MonoBehaviour {

	public GameObject[,] m_LevelArray;

	public GameObject[] m_BlockLibrary;
	private Block m_BlockScript;
	private GameObject m_BlockInstance;
	private GameObject m_BlockPrefab;

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

		//On vide la mémoire
		m_ShortMemory = "";



		//Taille du fichier
		//On prend le premier charactere
		while ((char)sr.Peek() != ';') //On test on ne parcours pas.
		{
			m_ShortMemory += ((char)sr.Read()).ToString(); //On rajoute ce que l'on lis dans la mémoire
		}

		//On enregistre la taille de la zone
		m_LevelSize = int.Parse(m_ShortMemory);

		//On remet la mémoire à zéro
		m_ShortMemory += ((char)sr.Read()).ToString(); //On rajoute ce que l'on lis dans la mémoire
		m_ShortMemory = ""; //On rajoute ce que l'on lis dans la mémoire
		
		
		//On va parcourir tout le terrain pour le remplir
		for (int i = 0; i < m_LevelSize; i++)
		{
			for (int y = 0; y < m_LevelSize; y++)
			{
				//On récolte le nom du prefab
				while ((char)sr.Peek() != ',') 
				{
					m_ShortMemory += ((char)sr.Read()).ToString(); //On rajoute ce que l'on lis dans la mémoire
				}
				
				//On crée la tile
				CreateTile(m_ShortMemory,i,y);

				//On enleve le ,
				m_ShortMemory += ((char)sr.Read()).ToString(); //On rajoute ce que l'on lis dans la mémoire
				//m_ShortMemory = m_ShortMemory.Remove(m_ShortMemory.Length - 1);
				//On remet la mémoire à zéro
				m_ShortMemory = ""; 
				
				//On récolte la rotation
				while ((char)sr.Peek() != ';')
				{
					m_ShortMemory += ((char)sr.Read()).ToString(); //On rajoute ce que l'on lis dans la mémoire
					
				}

			
				RotateTile(int.Parse(m_ShortMemory));
				m_ShortMemory += ((char)sr.Read()).ToString(); //On rajoute ce que l'on lis dans la mémoire
				//On remet la mémoire à zéro
				m_ShortMemory = ""; //On rajoute ce que l'on lis dans la mémoire
				
			}
		}

		//On remet la mémoire à zéro
		m_ShortMemory = ""; //On rajoute ce que l'on lis dans la mémoire
	}
	

	void RotateTile(int degree)
	{
		/*
		if (m_BlockInstance!=null)
		{
			m_BlockScript = m_BlockInstance.GetComponent<Block>();
			m_BlockScript.m_Graphisme.transform.localEulerAngles += new Vector3(0, degree, 0);
		}*/
		
	}

	void CreateTile(string tileName,int i,int y)
	{
		m_BlockInstance = null;

		foreach (GameObject go in m_BlockLibrary)
		{
			
			if(go.name+"(Clone)"==tileName)
			{
				m_BlockPrefab = go;
			}
		}
		Debug.Log(m_BlockPrefab);
		if (m_BlockPrefab != null)
		{
			m_BlockInstance = Instantiate(m_BlockPrefab) as GameObject;
			m_BlockInstance.transform.position = new Vector3(i * 8, 0, y * 8);
		}
	}
}
//On enleve alors le ;
//m_ShortMemory = m_ShortMemory.Remove(m_ShortMemory.Length - 1);