using UnityEngine;
using System.Collections;

public class ButtonClick : MonoBehaviour 
{
	public Material unClicked;
	public Material clicked;

	public float ClickedLifetime = 0.2f;
	
	private MeshRenderer myRenderer;

	private float curAge = Mathf.Infinity;

	void Start () 
	{
		myRenderer = GetComponent<MeshRenderer> ();
	}

	public void Click()
	{
		curAge = 0f;
		myRenderer.material = clicked;
	}

	void Update () 
	{
		curAge += Time.deltaTime;
		if (curAge >= ClickedLifetime)
			myRenderer.material = unClicked;
	}
}
