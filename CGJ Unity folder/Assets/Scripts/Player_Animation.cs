using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animation : MonoBehaviour
{
    Animator Anim;

    private void Start()
    {
        Anim = GetComponent<Animator>();
    }

    void Update()
    {

        Anim.SetInteger("State", 0);
    }
}

//State, 0 = idle
//State, 1 = run
