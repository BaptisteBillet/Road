using UnityEngine;
using System.Collections;

public class CarHeadLight : MonoBehaviour {
	//LIGHT

	public bool m_Light;

	public GameObject m_FrontLight1;
	public GameObject m_FrontLight2;
	public GameObject m_SpotLight1;
	public GameObject m_SpotLight2;

	public GameObject m_BackLight1;
	public GameObject m_BackLight2;
	public GameObject m_BackRedLight1;
	public GameObject m_BackRedLight2;

	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("X_1"))
		{
			m_Light = !m_Light;

			m_FrontLight1.SetActive(m_Light);
			m_FrontLight2.SetActive(m_Light);
			m_SpotLight1.SetActive(m_Light);
			m_SpotLight2.SetActive(m_Light);

			m_BackLight1.SetActive(m_Light);
			m_BackLight2.SetActive(m_Light);



		}
	}
}
