using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSpell : MonoBehaviour
{
    public static bool Activation_IceSpell, IceSpellUse;
    public GameObject Stalagmite, Player;

    private void Update()
    {
        /*if (IceSpellUse == true)
        {
            Vector3 Mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Stalagmite.transform.position = Player.transform.position;
            Stalagmite.transform.up = new Vector3(Mouse.x - Stalagmite.transform.position.x, Mouse.y - Stalagmite.transform.position.y, 0);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && IceSpellUse == true)
        {
            Instantiate(Stalagmite);
        }*/
    }
}
