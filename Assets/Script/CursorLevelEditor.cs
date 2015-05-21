using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CursorLevelEditor : MonoBehaviour {

	public int m_SelectionNumber=0;

	private bool m_IsOKToMove=true;
	private int m_NumberOfImage;


	public List<GameObject> Image = new List<GameObject>();
	public ImageEditorSelection m_Image_script;

	// Use this for initialization
	void Start () 
	{
		m_Image_script = Image[m_SelectionNumber].GetComponent<ImageEditorSelection>();
		m_NumberOfImage = Image.Count;
		m_IsOKToMove=true;
	}
	
	IEnumerator DelayMove()
	{
		yield return new WaitForSeconds(0.3f);
		m_IsOKToMove = true;
	}

	// Update is called once per frame
	void Update () {
	

		#region Curseur
		if (m_IsOKToMove)
		{

			if (Input.GetAxis("TriggersL_1") > 0 && m_IsOKToMove)
			{
				if (m_SelectionNumber > 0)
				{
					Image[m_SelectionNumber].transform.localScale = new Vector3(1f, 1f, 1f);
					m_SelectionNumber--;
					m_IsOKToMove = false;
					StartCoroutine(DelayMove());
					m_Image_script = Image[m_SelectionNumber].GetComponent<ImageEditorSelection>();
				}
				
			}
			if (Input.GetAxis("TriggersR_1") > 0 && m_IsOKToMove)
			{
				if (m_SelectionNumber < m_NumberOfImage-1)
				{
					Image[m_SelectionNumber].transform.localScale = new Vector3(1f, 1f, 1f);
					m_SelectionNumber++;
					m_IsOKToMove = false;
					StartCoroutine(DelayMove());
					m_Image_script = Image[m_SelectionNumber].GetComponent<ImageEditorSelection>();
				}
			}


		}

		Image[m_SelectionNumber].transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);

	}
		#endregion

	}

