using UnityEngine;
using System.Collections;

public class MoveCameraEditorMode : MonoBehaviour {

	private Camera m_Camera;

	// Use this for initialization
	void Start () {

		m_Camera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButton("X_1"))
		{
			m_Camera.fieldOfView--;
		}
		if (Input.GetButton("Y_1"))
		{
			m_Camera.fieldOfView++;
		}

		if (m_Camera.fieldOfView > 60) { m_Camera.fieldOfView = 60; }
		if (m_Camera.fieldOfView < 5) { m_Camera.fieldOfView = 5; }

		if (Input.GetAxis("R_XAxis_1") < 0)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z-1);
		}
		if (Input.GetAxis("R_XAxis_1") > 0)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
		}
		if (Input.GetAxis("R_YAxis_1") < 0)
		{
			transform.position = new Vector3(transform.position.x-1, transform.position.y, transform.position.z);
		}
		if (Input.GetAxis("R_YAxis_1") > 0)
		{
			transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
		}

		/*
		if(transform.position.x>100)
		{
			transform.position = new Vector3(100, transform.position.y, transform.position.z);
		}
		*/
		if (transform.position.x < 0)
		{
			transform.position = new Vector3(0, transform.position.y, transform.position.z);
		}
		/*
		if (transform.position.z > 32)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y, 32);
		}*/


	}
}

/* BUTTON
if (Input.GetButtonDown("A_1"))
{
	Debug.Log("A");
}
if (Input.GetButtonDown("B_1"))
{
	Debug.Log("B");
}
if (Input.GetButtonDown("X_1"))
{
	Debug.Log("X");
}
if (Input.GetButtonDown("Y_1"))
{
	Debug.Log("Y");
}
if (Input.GetButtonDown("Start_1"))
{
	Debug.Log("Start");
}
if (Input.GetButtonDown("Back_1"))
{
	Debug.Log("Select");
}
if (Input.GetButtonDown("LB_1"))
{
	Debug.Log("LB");
}
if (Input.GetButtonDown("RB_1"))
{
	Debug.Log("RB");
}

if (Input.GetAxis("DPad_XAxis_1")>0)
{
	Debug.Log("Pad droit");
}
if (Input.GetAxis("DPad_XAxis_1") < 0)
{
	Debug.Log("Pad gauche");
}

if (Input.GetAxis("L_XAxis_1") < 0)
{
	Debug.Log("Stick Gauche Gauche");
}
if (Input.GetAxis("L_XAxis_1") > 0)
{
	Debug.Log("Stick Gauche Droit");
}
if (Input.GetAxis("L_YAxis_1") < 0)
{
	Debug.Log("Stick Gauche Haut");
}
if (Input.GetAxis("L_YAxis_1") > 0)
{
	Debug.Log("Stick Gauche Bas");
}



if (Input.GetAxis("R_XAxis_1") < 0)
{
	Debug.Log("Stick Droit Gauche");
}
if (Input.GetAxis("R_XAxis_1") > 0)
{
	Debug.Log("Stick Droit Droit");
}
if (Input.GetAxis("R_YAxis_1") < 0)
{
	Debug.Log("Stick Droit Haut");
}
if (Input.GetAxis("R_YAxis_1") > 0)
{
	Debug.Log("Stick Droit Bas");
}
 
Debug.Log("Gachette Droite "+Input.GetAxis("TriggersR_1"));

Debug.Log("Gachette Gauche " + Input.GetAxis("TriggersL_1"));

*/