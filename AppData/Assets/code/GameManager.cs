using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public const int MONEY_TO_GET = 1000000;
	public const int WEAPONS_PER_CLICK = 10;
	public const int MIN_MONEY_PER_WEAPON = 50;
	public const int MAX_MONEY_PER_WEAPON = 500;
	public const int MIN_KILL_PER_WEAPON = 1;
	public const int MAX_KILL_PER_WEAPON = 3;
	public const double KILL_TIMER = 2;

	public GameObject Weapon;
	public GameObject Factory;
	public Transform PopUpPosition;
	public GameObject PopUpPrefab;
	public Camera MainCamera;
	public tk2dTextMesh TextMoney;
	public tk2dTextMesh TextWeapons;
	//public tk2dTextMesh TextWeaponsProduction;

	public float curTime;
	public float timePast;

	public int money = 0;
	public int kills = 0;
	public int weaponsSold = 0;
	public int weapons = 0;
	public int weaponsProduction = 0;

	private bool alreadyClicked = false;

	void Start()
	{
		Weapon.SetActive(false);
	}

	void Update () 
	{
		curTime = Time.deltaTime;
		timePast += curTime;
		if (timePast >= KILL_TIMER)
		{
			timePast = 0;
			kills += Random.Range(MIN_KILL_PER_WEAPON, MAX_KILL_PER_WEAPON) * weaponsSold;
		}

		TextMoney.text = money.ToString();
		TextWeapons.text = weapons.ToString();
		//TextWeaponsProduction.text = weaponsProduction.ToString();

		alreadyClicked = alreadyClicked ? !Input.GetMouseButtonUp (0) : alreadyClicked;

		if(Input.GetMouseButtonDown(0))
		{
			alreadyClicked = true;

			RaycastHit hit;
			if(Physics.Raycast(MainCamera.ScreenToWorldPoint(Input.mousePosition), Vector3.forward, out hit))
			{
				if(hit.collider == Weapon.GetComponent<MeshCollider>())
				{
					money += Random.Range(MIN_MONEY_PER_WEAPON, MAX_MONEY_PER_WEAPON) * weapons;
					weaponsSold += weapons;
					weapons = 0;
					Instantiate(PopUpPrefab, PopUpPosition.position, PopUpPosition.rotation);
					Weapon.GetComponent<ButtonClick>().Click();
					Weapon.SetActive(false);
				}
			}

			if (Physics.Raycast(MainCamera.ScreenToWorldPoint(Input.mousePosition), Vector3.forward, out hit))
			{
				if (hit.collider == Factory.GetComponent<MeshCollider>())
				{
					weapons += WEAPONS_PER_CLICK;
					Weapon.SetActive(true);
				}
			}
		}
	}
}