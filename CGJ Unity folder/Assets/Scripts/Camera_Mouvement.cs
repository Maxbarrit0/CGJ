using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Camera_Mouvement : MonoBehaviour
{
    public GameObject Player;

    void Update()
    {
        if (Player.transform.position.x >= 12.5f)
        {
            this.transform.DOMoveX(25, 0.5f);
        }
        else
        {
            this.transform.DOMoveX(0, 0.5f);
        }

    }
}
