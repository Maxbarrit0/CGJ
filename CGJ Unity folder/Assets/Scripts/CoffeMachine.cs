using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeMachine : MonoBehaviour
{
    public GameObject Text, SpellDeliver;
    public bool Actif;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Actif == true)
        {
            Text.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SpellDeliver.gameObject.SetActive(true);
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
