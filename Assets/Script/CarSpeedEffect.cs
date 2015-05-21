using UnityEngine;
using System.Collections;
using ParticlePlayground;

public class CarSpeedEffect : MonoBehaviour {

	public PlaygroundParticlesC m_ParticuleFire;
	public Car m_Car;
	// Use this for initialization
	void Start () {
		m_ParticuleFire.emit = false;
		m_ParticuleFire.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (m_Car.m_CurrentCarSpeed>40)
		{

			m_ParticuleFire.emit = true;
		}
		else
		{
			m_ParticuleFire.emit = false;
		}
	}
}
