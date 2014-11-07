using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public const int MAX_KILL_COUNT = 1000000;

	public GameObject ContinueButton;
	public GameObject Page1;
	public GameObject Page2;
	public GameObject Page3;
	public GameObject Weapon;
	public Transform PopUpPosition;
	public GameObject PopUpPrefab;
	public GameObject Yaranaika;
	public Camera MainCamera;

	public int Money = 0;
	public int Kills = 0;
	public int Killrate = 0;

	public int MoneyPerWeapon = 50;
	public int KillratePerWeapon = 2;

	private bool alreadyClicked = false;

	void Update () 
	{
		Kills += Killrate;

		if (Kills >= MAX_KILL_COUNT) 
		{
			Killrate = 0;
			Money = 0;
			Kills = 0;

			Weapon.SetActive(false);
			Page3.SetActive(true);
			ContinueButton.SetActive(true);
		}

		alreadyClicked = alreadyClicked ? !Input.GetMouseButtonUp (0) : alreadyClicked;

		if(Input.GetMouseButtonDown(0))
		{
			alreadyClicked = true;

			RaycastHit hit;
			if(Physics.Raycast(MainCamera.ScreenToWorldPoint(Input.mousePosition), Vector3.forward, out hit))
			{
				if(hit.collider == ContinueButton.GetComponent<MeshCollider>())
				{
					if(Page1.activeSelf)
					{
						Page1.SetActive(false);
						Page2.SetActive(true);
						return;
					}
					if(Page2.activeSelf)
					{
						Page2.SetActive(false);
						ContinueButton.SetActive(false);
						Weapon.SetActive(true);
						return;
					}
					if(Page3.activeSelf)
					{
						Page3.SetActive(false);
						Page1.SetActive(true);
						return;
					}
				}

				if(hit.collider == Weapon.GetComponent<MeshCollider>())
				{
					Killrate += KillratePerWeapon;
					Money += MoneyPerWeapon;
					Instantiate(PopUpPrefab, PopUpPosition.position, PopUpPosition.rotation);
					Yaranaika.GetComponent<yaranaika>().Activate();
					Weapon.GetComponent<ButtonClick>().Click();
				}
			}

		}
	}
}