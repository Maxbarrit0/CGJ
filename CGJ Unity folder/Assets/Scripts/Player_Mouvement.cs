﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Mouvement : MonoBehaviour
{
    Rigidbody2D Body;

    private void Start()
    {
        //Set "Body" the rigidbody attached to this gamobject
        Body = this.GetComponent<Rigidbody2D>();
    }

    //The X and Y velocity that rigidbody will have every frame
    public float X_Velocity, Y_Velocity;

    //The max speed that x and y velocity cannot reach. Also determine the acceleration
    public float MaxSpeed;

    private void Update()
    {

        //Check if the user have pressed the touch Z 

        if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.UpArrow))
        {
            if (Y_Velocity < 0)
            {
                // if Y velocity is < 0 then it will accelerate more 

                Y_Velocity += MaxSpeed * 4 * Time.deltaTime;
            }
            else
            {
                // if Y velocity is > 0 then it will accelerate normally

                Y_Velocity += MaxSpeed * Time.deltaTime;
            }
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            if (Y_Velocity > 0)
            {
                // if Y velocity is < 0 then it will deccelerate more 

                Y_Velocity -= MaxSpeed * 4 * Time.deltaTime;
            }
            else
            {
                // if Y velocity is > 0 then it will deccelerate normally

                Y_Velocity -= MaxSpeed * Time.deltaTime;
            }
        }
        else
        {
            if (Y_Velocity >= -0.1f && Y_Velocity <= 0.1f) // If Y velocity is approching 0 so Y velocity equals 0
            {
                Y_Velocity = 0;
            }
            else
            {
                if (Y_Velocity > 0.1f) // If Y Velocity > 0.1f Velocity deccelerate for approching 0 then stop
                {
                    Y_Velocity -= MaxSpeed * 1.5f * Time.deltaTime;
                }
                else // If Y Velocity < 0.1f Velocity accelerate for approching 0 then stop
                {
                    Y_Velocity += MaxSpeed * 1.5f * Time.deltaTime;
                }
            }
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (X_Velocity < 0)
            {
                // if X velocity is < 0 then it will accelerate more 

                X_Velocity += MaxSpeed * 4 * Time.deltaTime;
            }
            else
            {
                // if X velocity is > 0 then it will accelerate normally

                X_Velocity += MaxSpeed * Time.deltaTime;
            }
        }
        else if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (X_Velocity > 0)
            {
                // if X velocity is > 0 then it will deccelerate more 

                X_Velocity -= MaxSpeed * 4 * Time.deltaTime;
            }
            else
            {
                // if X velocity is < 0 then it will deccelerate normally

                X_Velocity -= MaxSpeed * Time.deltaTime;
            }
        }
        else
        {
            if (X_Velocity >= -0.3f && X_Velocity <= 0.3f) // If X velocity is approching 0 so X Velocity equals 0
            {
                X_Velocity = 0;
            }
            else
            {
                if (X_Velocity > 0.1f)
                {
                    // If X Velocity > 0.1f Velocity deccelerate for approching 0 then stop

                    X_Velocity -= MaxSpeed * 1.5f * Time.deltaTime;
                }
                else
                {
                    // If X Velocity < 0.1f Velocity deccelerate for approching 0 then stop

                    X_Velocity += MaxSpeed * 1.5f * Time.deltaTime;
                }
            }
        }

        if (X_Velocity >= MaxSpeed) // if X Velocity is > at the higgest speed autorised so X Velocity equal to max speed
        {
            X_Velocity = MaxSpeed;
        }
        else if (X_Velocity <= -MaxSpeed) // if X Velocity is < at the lowest speed autorised so X Velocity equal to lowest speed
        {
            X_Velocity = -MaxSpeed;
        }

        if (Y_Velocity >= MaxSpeed) // if Y Velocity is > at the higgest speed autorised so Y Velocity equal to max speed
        {
            Y_Velocity = MaxSpeed;
        }
        else if (Y_Velocity <= -MaxSpeed) // if Y Velocity is < at the higgest speed autorised so Y Velocity equal to lowest speed
        {
            Y_Velocity = -MaxSpeed;
        }

        //Applie the velocity to the rigidbody

        Body.velocity = new Vector2(X_Velocity, Y_Velocity);
    }

    //A function that will be trigger every time the gameobject will be on collision with gameobject
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle") // if the tag's gameobject is equals to "Obstacle"
        {
            //Get the position of the collision point
            Vector2 positionOfCollision = collision.contacts[0].point;

            //Get the position have a magnitude of 1
            positionOfCollision.Normalize();

            //If the collider was hit in his right or in his left 
            if (positionOfCollision.y >= 0.5f || positionOfCollision.y <= -0.5f)
            {
                //Reboundish
                Y_Velocity *= -0.75f;
            }
            else if (positionOfCollision.x >= 0.9f || positionOfCollision.x <= -0.9f)   //If the collider was hit in his up or in his bottom
            {
                //Reboundish
                X_Velocity *= -0.75f;
            }
        }
    }
}
