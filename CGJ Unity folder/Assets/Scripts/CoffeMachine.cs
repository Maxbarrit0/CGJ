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

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Actif == true)
        {
            Text.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SpellDeliver.gameObject.SetActive(true);
                int r = Random.Range(1, 2 + 1);

                if (r == 1)
                {
                    SpellDeliverRender.sprite = Earth;
                    SpellDeliver.SendMessage("SetSpell", "Earth");
                }
                else
                {
                    SpellDeliverRender.sprite = Ice;
                    SpellDeliver.SendMessage("SetSpell", "Ice");

                }

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
