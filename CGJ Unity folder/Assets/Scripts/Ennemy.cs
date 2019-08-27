using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    public string Direction;

    //This box is here for avoid the monster to collide with the two wall collider
    CircleCollider2D BoxOfEnnemy;
    public BoxCollider2D BoxOfWallRight, BoxOfWallLeft_Up, BoxOfWallLeft_Down;

    public Rigidbody2D Rigid;
    public GameObject Satan, GFX;

    //The speed of the monster
    public float Speed;

    private void Start()
    {
        BoxOfEnnemy = GetComponent<CircleCollider2D>();
        Rigid = this.GetComponent<Rigidbody2D>();

        //Ignore collision between monster and the two wall
        Physics2D.IgnoreCollision(BoxOfEnnemy, BoxOfWallLeft_Up);
        Physics2D.IgnoreCollision(BoxOfEnnemy, BoxOfWallLeft_Down);
        Physics2D.IgnoreCollision(BoxOfEnnemy, BoxOfWallRight);
    }

    private void Update()
    {
        Knocked -= 1 * Time.deltaTime;

        //Make the gameobject look Satan
        this.transform.up = Satan.transform.position - this.transform.position;

        //Make the gameobject move into Satan
        if (Knocked <= 0)
        {
            Rigid.velocity = transform.up * Speed;
        }
        else
        {
            Velocity -= Pos * Durée * Time.deltaTime;
            Rigid.velocity = Velocity;
        }

        if (this.transform.position.x > 0) //If direction where is spawn is in the right so it will always look at the left
        {
            GFX.transform.rotation = Quaternion.Euler(0, 0, -this.transform.rotation.z); // To the right
        }
        else //If direction where is spawn is in the left so it will always look at the right
        {
            GFX.transform.rotation = Quaternion.Euler(0, -180, -this.transform.rotation.z); // to the left
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
        else if (collision.gameObject.tag == "Obstacle")
        {
            Knocked = 0;
        }
    }

    public float ForceWhenKnocked, Durée;
    public Vector2 Pos, Velocity;
    public float Knocked;
}
