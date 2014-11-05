using UnityEngine;
using System.Collections;

public class PopUp : MonoBehaviour 
{
	public enum Dir{Up, Right}

	public Dir Direction;
	public float Lifetime = 3;
	public float MovementSpeed = 0.1f;

	private float curAge = 0;

	void Update () 
	{
		curAge += Time.deltaTime;
		if (curAge >= Lifetime)
			Destroy (gameObject);

		if (Direction == Dir.Up)
			transform.position += new Vector3(0f, MovementSpeed, 0.1f);
		else
			transform.position += new Vector3(MovementSpeed, 0f, 0.1f);
	}
}
