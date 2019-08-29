using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Mouvement : MonoBehaviour
{
    float Knocked, Cooldown;
    public BoxCollider2D ThisBox;
    public CircleCollider2D BossBOX;
    Animator Anim;
    Rigidbody2D Body;
    public GameObject GFX, GFX_Sleep;

    private void Start()
    {
        SizeFilter = Bulle_Text.GetComponent<ContentSizeFitter>();
        if (Main.EtapeTutoriel == 1)
        {
            GFX_Sleep.gameObject.SetActive(true);
            GFX.gameObject.SetActive(false);
        }
        else
        {
            GFX_Sleep.gameObject.SetActive(false);
            GFX.gameObject.SetActive(true);
        }

        Physics2D.IgnoreCollision(ThisBox, BossBOX);

        Anim = GFX.GetComponent<Animator>();

        //Set "Body" the rigidbody attached to this gamobject
        Body = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Mouvement();
        Animation();
        Text();
    }

    #region Text
    bool DejaFait;

    void Text()
    {
        if (Main.EtapeTutoriel == 2 && DejaFait == false)
        {
            Bulle_Image.gameObject.SetActive(true);
            Bulle_Text.gameObject.SetActive(true);
            StartCoroutine(AfficherParole("What !? What i'm doing here !", 0.05f));
            DejaFait = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Finished == false)
            {
                //StopCoroutine(AfficherParole(TextToShow, 0.05f));
                //Bulle_Text.text = TextToShow;
            }
            else
            {
                if (Bulle_Text.text != "")
                {
                    Bulle_Text.text = "";
                    Bulle_Image.gameObject.SetActive(false);
                    Main.EtapeTutoriel++;
                    DejaFait = false;
                }

            }
        }

        Bulle_Image.rectTransform.sizeDelta = new Vector2(Bulle_Text.rectTransform.rect.width * Bulle_Text.rectTransform.localScale.x + 10, Bulle_Text.rectTransform.rect.height * Bulle_Text.rectTransform.localScale.y + 10);
        if (Bulle_Text.rectTransform.rect.width >= 480)
        {
            SizeFilter.horizontalFit = ContentSizeFitter.FitMode.Unconstrained;
        }
        else
        {
            SizeFilter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
        }
    }

    public Image Bulle_Image;
    public Text Bulle_Text;
    ContentSizeFitter SizeFilter;
    bool Finished;

    IEnumerator AfficherParole(string Parole, float Speed)
    {
        Bulle_Text.text = null;
        while (Parole.Length > 0)
        {
            yield return new WaitForSeconds(Speed);
            Bulle_Text.text += Parole[0];
            Parole = Parole.Substring(1);
            Finished = false;
            if (Parole.Length == 0)
            {
                Finished = true;
            }
        }
    }

    #endregion

    //this do all the player animation

    #region Animation

    void Animation()
    {
        if (Main.EtapeTutoriel == 1)
        {
            GFX_Sleep.gameObject.SetActive(true);
            GFX.gameObject.SetActive(false);
        }
        else
        {
            GFX_Sleep.gameObject.SetActive(false);
            GFX.gameObject.SetActive(true);
        }
        if (Knocked <= 0)
        {
            if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && Player_Sword.Shield == false)
            {
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && Player_Sword.Shield == false)
            {
                this.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && Player_Sword.Shield == false)
            {
                Anim.SetInteger("State", 3);
            }
            else if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && Player_Sword.Shield == false)
            {
                Anim.SetInteger("State", 2);
            }
            else if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) && Player_Sword.Shield == false)
            {
                Anim.SetInteger("State", 1);
            }
            else
            {
                Anim.SetInteger("State", 0);
            }
        }
    }

    //State (0) = idle
    //State (1) = run
    //State (2) = run down
    //State (3) = run up

    #endregion

    //this do the player mouvement

    #region Mouvement  

    //The X and Y velocity that rigidbody will have every frame
    public float X_Velocity, Y_Velocity;

    //The max speed that x and y velocity cannot reach. Also determine the acceleration
    public float MaxSpeed, Acceleration;
    public float Decceleration;

    public static string CurrentDirection;
    public static bool X_Plus, X_Moin, Y_Plus, Y_Moins;

    private void Mouvement()
    {
        Knocked -= 1 * Time.deltaTime;
        Cooldown -= 1 * Time.deltaTime;

        if (Knocked <= 0)
        {
            ThisBox.enabled = true;
            if (Main.EtapeTutoriel != 1)
            {
                GFX.active = true;
            }

            //Check if the user have pressed the touch Z 
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                if (Y_Velocity < 0)
                {
                    // if Y velocity is < 0 then it will accelerate more 

                    Y_Velocity += MaxSpeed * 4 * Time.deltaTime;
                }
                else
                {
                    // if Y velocity is > 0 then it will accelerate normally

                    Y_Velocity += MaxSpeed * Acceleration * Time.deltaTime;
                }
                Y_Plus = true;
                Y_Moins = false;
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

                    Y_Velocity -= MaxSpeed * Acceleration * Time.deltaTime;
                }
                Y_Moins = true;
                Y_Plus = false;
            }
            else
            {
                Y_Moins = false;
                Y_Plus = false;
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

                    X_Velocity += MaxSpeed * Acceleration * Time.deltaTime;
                }
                X_Plus = true;
                X_Moin = false;

            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                if (X_Velocity > 0)
                {
                    // if X velocity is > 0 then it will deccelerate more 

                    X_Velocity -= MaxSpeed * 4 * Time.deltaTime;
                }
                else
                {
                    // if X velocity is < 0 then it will deccelerate normally

                    X_Velocity -= MaxSpeed * Acceleration * Time.deltaTime;
                }
                X_Moin = true;
                X_Plus = false;
            }
            else
            {
                X_Moin = false;
                X_Plus = false;
            }
        }
        else
        {
            ThisBox.enabled = false;
            if (Cooldown <= 0 && Main.EtapeTutoriel != 1)
            {
                if (GFX.active == true)
                {
                    GFX.active = false;
                }
                else
                {
                    GFX.active = true;
                }
                Cooldown = 0.2f;
            }
            X_Moin = false;
            X_Plus = false;
            Y_Moins = false;
            Y_Plus = false;
        }


        if (X_Moin == false && X_Plus == false)
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

                    X_Velocity -= MaxSpeed * Decceleration * Time.deltaTime;
                }
                else
                {
                    // If X Velocity < 0.1f Velocity deccelerate for approching 0 then stop

                    X_Velocity += MaxSpeed * Decceleration * Time.deltaTime;
                }
            }
        }

        if (Y_Moins == false && Y_Plus == false)
        {
            if (Y_Velocity >= -0.1f && Y_Velocity <= 0.1f) // If Y velocity is approching 0 so Y velocity equals 0
            {
                Y_Velocity = 0;
            }
            else
            {
                if (Y_Velocity > 0.1f) // If Y Velocity > 0.1f Velocity deccelerate for approching 0 then stop
                {
                    Y_Velocity -= MaxSpeed * Decceleration * Time.deltaTime;
                }
                else // If Y Velocity < 0.1f Velocity accelerate for approching 0 then stop
                {
                    Y_Velocity += MaxSpeed * Decceleration * Time.deltaTime;
                }
            }
        }

        //This will check in which direction the player are looking

        if (X_Plus == true)
        {
            if (Y_Plus == true)
            {
                CurrentDirection = "UR"; // UP down
            }
            else if (Y_Moins == true)
            {
                CurrentDirection = "DR"; // Down right
            }
            else
            {
                CurrentDirection = "R"; // R
            }
        }
        else if (X_Moin == true)
        {
            if (Y_Plus == true)
            {
                CurrentDirection = "UL"; // Up Left
            }
            else if (Y_Moins == true)
            {
                CurrentDirection = "DL"; // Down Left
            }
            else
            {
                CurrentDirection = "L"; // Left
            }
        }
        else if (Y_Plus == true)
        {
            CurrentDirection = "U"; // UP
        }
        else if (Y_Moins == true)
        {
            CurrentDirection = "D"; //Down
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
        else if (collision.gameObject.tag == "Monster")
        {
            if (Knocked <= 0)
            {
                Knocked = 1;
            }
        }
    }

    #endregion
}
