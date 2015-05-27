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

		//On vide la mémoire
		m_ShortMemory = null;



		//Taille du fichier
		//On prend le premier charactere
		while ((char)sr.Peek() != ';') //On test on ne parcours pas.
		{
			m_ShortMemory += ((char)sr.Read()).ToString(); //On rajoute ce que l'on lis dans la mémoire
		}
		m_LevelSize = int.Parse(m_ShortMemory);

		Debug.Log(m_ShortMemory);
		m_ShortMemory += ((char)sr.Read()).ToString(); //On rajoute ce que l'on lis dans la mémoire
		Debug.Log(m_ShortMemory.Length - 1);
		Debug.Log(m_ShortMemory.Remove(m_ShortMemory.Length - 1));
		m_ShortMemory.Remove(m_ShortMemory.Length-1);
		Debug.Log(m_ShortMemory);  //NON MAIS LOL


		//Placement dans le fichier
		//Tant que nous n'avons pas fini le fichier
		while((char)sr.Peek()!='}') //On test on ne parcours pas.
		{
			m_ShortMemory+=((char)sr.Read()).ToString(); //On rajoute ce que l'on lis dans la mémoire
			if(m_ShortMemory.Contains(";"))//Si on arrive à une fin d'information
			{
				//On enleve alors le ;
				m_ShortMemory.Remove(m_ShortMemory.Length - 1);
			}
			
		}
		/*
		for (int i = 0; i < m_LevelSize; i++)
		{
			for (int y = 0; y < m_LevelSize; y++)
			{

			}
		}*/
		
		 

	}
	
	
}
