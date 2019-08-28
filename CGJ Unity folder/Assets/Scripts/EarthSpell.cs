using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthSpell : MonoBehaviour
{
	public static bool EarthSpellUse = false;
	public GameObject AreaGraphique, Area;

	void Update()
	{
		if (EarthSpellUse == true)
		{
			if (Input.GetMouseButtonDown(0))
			{
				EarthSpellUse = false;
				Instantiate(Area);
			}
			Vector2 MP = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			AreaGraphique.transform.position = MP;
			Area.transform.position = (Vector2)MP;
		}
		else
		{
			AreaGraphique.transform.position = new Vector2(0, 20);
			Area.transform.position = new Vector2(0, 20);
		}
	}
}
