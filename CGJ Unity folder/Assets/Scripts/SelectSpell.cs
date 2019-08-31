using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectSpell : MonoBehaviour
{
    public string Type;
    public float Cooldown, MaxCooldown;
    public Image Image;

    private void Update()
    {

        if (Type == "Ice" && Input.GetKeyDown(KeyCode.Q))
        {
            if (Cooldown <= 0)
            {

                if (IceSpell.Activation_IceSpell == true)
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
        if (Type == "Earth" && Input.GetKeyDown(KeyCode.E))
        {
            if (Cooldown <= 0)
            {

                if (EarthSpellForm.ActifEarthSpell == true)
                {
                    EarthSpell.EarthSpellUse = true;
                    Cooldown = 5;
                }

            }

        }

        Cooldown -= 1 * Time.deltaTime;

        if (Type == "Ice")
        {
            if (Cooldown <= 0)
            {
                Image.fillAmount = 1;
                Image.color = new Color32(0, 255, 27, 255);
            }
            else if (Cooldown > 0)
            {
                if (IceSpell.Activation_IceSpell == true)
                {
                    Image.fillAmount = Cooldown / 1;
                }
                Image.color = new Color32(255, 0, 0, 255);
            }
        }
        else
        {
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
                Image.color = new Color32(255, 0, 0, 255);
            }
        }
    }

    public GameObject Player, Stalagmite;

    public void Select()
    {

        if (Cooldown <= 0)
        {
            if (Type == "Earth")
            {
                if (EarthSpellForm.ActifEarthSpell == true)
                {
                    EarthSpell.EarthSpellUse = true;
                    Cooldown = 5;
                }
            }
            else if (Type == "Ice")
            {
                if (IceSpell.Activation_IceSpell == true)
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
    }
}

//0, 255, 24 = Vert
//255, 0, 0 = Rouge
//255 175, 0 = Orange
