using UnityEngine;
using System.Collections;

public class yaranaika : MonoBehaviour 
{
	public GameObject General;

	public float Lifetime = 0.2f;

	private float curAge = 0f;

	public void Activate()
	{
		curAge = 0f;
		gameObject.GetComponent<MeshRenderer> ().enabled = true;
		General.GetComponent<MeshRenderer> ().enabled = false;
	}

	public void Update()
	{
		curAge += Time.deltaTime;
		if (curAge >= Lifetime) 
		{
			gameObject.GetComponent<MeshRenderer> ().enabled = false;
			General.GetComponent<MeshRenderer> ().enabled = true;
		}
	}
}
