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
        if (EarthSpell.EarthSpellUse == false)
        {
            Cooldown -= 1 * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (Cooldown <= 0)
            {
                EarthSpell.EarthSpellUse = true;
                Cooldown = MaxCooldown;
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
            Image.fillAmount = Cooldown / MaxCooldown;
            Image.color = new Color32(255, 0, 0, 255);
        }
    }

    public void Select()
    {

        if (Cooldown <= 0)
        {
            EarthSpell.EarthSpellUse = true;
            Cooldown = MaxCooldown;
        }
    }
}

//0, 255, 24 = Vert
//255, 0, 0 = Rouge
//255 175, 0 = Orange
