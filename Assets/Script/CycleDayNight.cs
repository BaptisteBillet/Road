using UnityEngine;
using System.Collections;

public class CycleDayNight : MonoBehaviour {


	public float m_RotatePerSecond;
	private float m_EulerX;
	// Use this for initialization
	void Start () {
		this.transform.eulerAngles = new Vector3(90, 0, 0);
		m_EulerX = 90;
	}
	
	// Update is called once per frame
	void Update () {
		m_EulerX += m_RotatePerSecond;
		this.transform.eulerAngles = new Vector3(m_EulerX, 0, 0);
	}
}
