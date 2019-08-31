using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalagmite : MonoBehaviour
{

    Rigidbody2D rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rigid.velocity = transform.up * 24;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Monster")
        {
            collision.SendMessage("Gele", 2);
            Destroy(this.gameObject);
        }
        else if (collision.tag == "Obstacle")
        {
            Destroy(this.gameObject);

        }
    }
}
