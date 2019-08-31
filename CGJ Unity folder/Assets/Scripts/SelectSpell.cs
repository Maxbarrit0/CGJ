using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectSpell : MonoBehaviour
{
    public float Cooldown, MaxCooldown;
    public Image Image;

    private void Update()
    {
        if (EarthSpell.EarthSpellUse == false || IceSpell.IceSpellUse == false)
        {
            Cooldown -= 1 * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (Cooldown <= 0)
            {
                if (EarthSpellForm.ActifEarthSpell == true)
                {
                    EarthSpell.EarthSpellUse = true;
                    Cooldown = 5;
                }
                else if (IceSpell.Activation_IceSpell == true)
                {
                    IceSpell.IceSpellUse = true;
                    Cooldown = 2;
                    Vector3 Mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Stalagmite.transform.position = Player.transform.position;
                    Stalagmite.transform.up = new Vector3(Mouse.x - Stalagmite.transform.position.x, Mouse.y - Stalagmite.transform.position.y, 0);
                    Instantiate(Stalagmite);
                }
            }
        }

        if (Cooldown <= 0)
        {
            Image.fillAmount = 1;
            Image.color = new Color32(0, 255, 27, 255);
        }
        else if (EarthSpell.EarthSpellUse == true)
        {
            Image.fillAmount = 1;
            Image.color = new Color32(255, 175, 0, 255);
        }
        else if (Cooldown > 0)
        {
            if (EarthSpellForm.ActifEarthSpell == true)
            {
                Image.fillAmount = Cooldown / 5;
            }
            else if (IceSpell.Activation_IceSpell == true)
            {
                Image.fillAmount = Cooldown / 1;
            }
            Image.color = new Color32(255, 0, 0, 255);
        }
    }

    public GameObject Player, Stalagmite;

    public void Select()
    {

        if (Cooldown <= 0)
        {
            if (EarthSpellForm.ActifEarthSpell == true)
            {
                EarthSpell.EarthSpellUse = true;
                Cooldown = 5;
            }
            else if (IceSpell.Activation_IceSpell == true)
            {
                Cooldown = 1;
                Vector3 Mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Stalagmite.transform.position = Player.transform.position;
                Stalagmite.transform.up = new Vector3(Mouse.x - Stalagmite.transform.position.x, Mouse.y - Stalagmite.transform.position.y, 0);
                Instantiate(Stalagmite);

            }
        }
    }
}

//0, 255, 24 = Vert
//255, 0, 0 = Rouge
//255 175, 0 = Orange
