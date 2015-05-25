using UnityEngine;
using System.Collections;
using System.IO;


public class HubScript : MonoBehaviour {

	//Detection des manettes
	public GameObject m_Manette1;
	public GameObject m_Manette2;
	public GameObject m_Manette3;
	public GameObject m_Manette4;


	// Use this for initializationEasyJSONExample
	void Start () {
		//System.IO.File.WriteAllText("C:\\Users\\Baptiste.B-FIXE\\Documents\\GitHub\\Road\\Assets\\texte.txt", "aaa");
		System.IO.File.WriteAllText(Application.dataPath+"\\SaveLevel\\texte.txt", "aaa");

	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
