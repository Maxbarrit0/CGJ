using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeMachine : MonoBehaviour
{
    public GameObject Text, SpellDeliver;
    SpriteRenderer SpellDeliverRender;
    public bool Actif;
    public Sprite Earth, Ice;

    private void Start()
    {
        SpellDeliverRender = SpellDeliver.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Main.DoorOpen == false)
        {
            Actif = true;
        }
    }

    public SpellDeliverMove Scripts;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Actif == true)
        {
            Text.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Actif = false;
                int r = 1;

                if (r == 1)
                {
                    SpellDeliverRender.sprite = Earth;
                    Scripts.CurrentSpell = "Earth";
                }
                else
                {
                    SpellDeliverRender.sprite = Ice;
                    Scripts.CurrentSpell = "Ice";
                }
                Instantiate(SpellDeliverRender);
            }
        }
        else
        {
            Text.gameObject.SetActive(false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Text.gameObject.SetActive(false);
    }
}
