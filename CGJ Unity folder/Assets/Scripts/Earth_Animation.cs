using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth_Animation : MonoBehaviour
{
	public EarthSpellForm Script;
	public GameObject Form_1, Form_2;
	public bool Actif;
	public float CoolDown;

	private void Awake()
	{
		if (Actif == true)
		{
			int r = Random.Range(7, 12 + 1);
			while (r >= 1)
			{
				int form = Random.Range(1, 2 + 1);
				if (form == 1)
				{
					NewObject(Form_1);

				}
				else
				{
					NewObject(Form_2);
				}
				r--;
			}
		}
	}

	private void Update()
	{
		CoolDown -= 1 * Time.deltaTime;
		if (CoolDown <= 0 && Actif == true)
		{
			this.gameObject.tag = "Stop";
			if (CoolDown <= -1.5f)
			{
				Destroy(this.gameObject);
			}
		}
	}

	void NewObject(GameObject Object)
	{
		float y = Random.Range(-3, 3 + 1);
		float x = 2;
		if (y == 0)
		{
			x = Random.Range(-3, 3);
		}
		else if (y > 0)
		{
			x = -y + 4;
		}
		else
		{
			x = -y - 4;
		}
		EarthSpellForm Script = Object.GetComponent<EarthSpellForm>();
		Script.PosGeneral = y;
		Script.PosGeneralX = x;
		Script.Area = this.gameObject;
		Instantiate(Object);
	}
}
