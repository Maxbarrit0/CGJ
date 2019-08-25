﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    //This box is here for avoid the monster to collide with the two wall collider
    BoxCollider2D BoxOfEnnemy;
    public BoxCollider2D BoxOfWallRight, BoxOfWallLeft;

    Rigidbody2D Rigid;
    public GameObject Satan;

    //The speed of the monster
    public float Speed;

    private void Start()
    {
        BoxOfEnnemy = GetComponent<BoxCollider2D>();
        Rigid = this.GetComponent<Rigidbody2D>();

        //Ignore collision between monster and the two wall
        Physics2D.IgnoreCollision(BoxOfEnnemy, BoxOfWallLeft);
        Physics2D.IgnoreCollision(BoxOfEnnemy, BoxOfWallRight);
    }

    private void Update()
    {
        //Make the gameobject look Satan
        this.transform.up = Satan.transform.position - this.transform.position;

        //Make the gameobject move into Satan
        Rigid.velocity = transform.up * Speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Satan") // if collision = Satan so the monster is destroyed
        {
            Destroy(this.gameObject);
        }
    }
}
