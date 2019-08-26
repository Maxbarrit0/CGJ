using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    public string Direction;

    //This box is here for avoid the monster to collide with the two wall collider
    CircleCollider2D BoxOfEnnemy;
    public BoxCollider2D BoxOfWallRight, BoxOfWallLeft;

    Rigidbody2D Rigid;
    public GameObject Satan, GFX;

    //The speed of the monster
    public float Speed;

    private void Start()
    {
        BoxOfEnnemy = GetComponent<CircleCollider2D>();
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

        if (Direction == "R") //If direction where is spawn is in the right so it will always look at the left
        {
            GFX.transform.rotation = Quaternion.Euler(0, 0, -this.transform.rotation.z);
        }
        else //If direction where is spawn is in the left so it will always look at the right
        {
            GFX.transform.rotation = Quaternion.Euler(0, -180, -this.transform.rotation.z);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Satan") // if collision = Satan so the monster is destroyed
        {
            Boss.Life--;
            Main.RemainsMonster--;
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Sword") // if he is smahing he die
        {
            Main.RemainsMonster--;
            Destroy(this.gameObject);
        }
    }
}
