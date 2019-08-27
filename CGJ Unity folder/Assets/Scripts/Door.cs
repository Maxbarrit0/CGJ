using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Door : MonoBehaviour
{

    public string Direction;

    void Update()
    {
        if (Direction == "U")
        {
            if (Main.DoorOpen == true && this.transform.position.y < 4.5f)
            {
                this.transform.DOMoveY(5, 1);
            }
            else if (Main.DoorOpen == false && this.transform.position.y > 4)
            {
                this.transform.DOMoveY(3.5f, 1);
            }
        }
        else if (Direction == "D")
        {
            if (Main.DoorOpen == true && this.transform.position.y > -4.5f)
            {
                this.transform.DOMoveY(-5, 1);
            }
            else if (Main.DoorOpen == false && this.transform.position.y < -4)
            {
                this.transform.DOMoveY(-3.5f, 1);
            }
        }
    }
}
