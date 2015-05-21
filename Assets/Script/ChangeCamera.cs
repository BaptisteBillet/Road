using UnityEngine;
using System.Collections;

public class ChangeCamera : MonoBehaviour {

	public Camera m_TopCamera;
	public Camera m_FrontCamera;

	public bool IsFrontCameraRendering;
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown("Y_1"))
		{
			IsFrontCameraRendering = !IsFrontCameraRendering;

			m_TopCamera.enabled = !IsFrontCameraRendering;
			m_FrontCamera.enabled = IsFrontCameraRendering;
			
		}
	}
}
