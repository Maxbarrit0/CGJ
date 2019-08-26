using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Sword : MonoBehaviour
{
    void Update()
    {
        if (Player_Mouvement.CurrentDirection == "R") //If the player'dirction is the right so give him that position and transform
        {
            //The swords will be at the right
            Gameobject_Sword.transform.position = new Vector3(transform.position.x + 1, transform.position.y, 0);

            //The rotation of the gameobject will look at the right
            Gameobject_Sword.transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        else if (Player_Mouvement.CurrentDirection == "L")
        {

            Gameobject_Sword.transform.position = new Vector3(transform.position.x - 1, transform.position.y, 0);
            Gameobject_Sword.transform.rotation = Quaternion.Euler(0, 0, 90);

        }
        else if (Player_Mouvement.CurrentDirection == "U")
        {

            Gameobject_Sword.transform.position = new Vector3(transform.position.x, transform.position.y + 1.3f, 0);
            Gameobject_Sword.transform.rotation = Quaternion.Euler(0, 0, 0);

        }
        else if (Player_Mouvement.CurrentDirection == "D")
        {
            Gameobject_Sword.transform.position = new Vector3(transform.position.x, transform.position.y - 1.3f, 0);
            Gameobject_Sword.transform.rotation = Quaternion.Euler(0, 0, -180);
        }
        else if (Player_Mouvement.CurrentDirection == "UR")
        {
            Gameobject_Sword.transform.position = new Vector3(transform.position.x + 1, transform.position.y + 1.3f, 0);
            Gameobject_Sword.transform.rotation = Quaternion.Euler(0, 0, -45);
        }
        else if (Player_Mouvement.CurrentDirection == "UL")
        {
            Gameobject_Sword.transform.position = new Vector3(transform.position.x - 1, transform.position.y + 1.3f, 0);
            Gameobject_Sword.transform.rotation = Quaternion.Euler(0, 0, 45);
        }
        else if (Player_Mouvement.CurrentDirection == "DL")
        {
            Gameobject_Sword.transform.position = new Vector3(transform.position.x - 1, transform.position.y - 1.3f, 0);
            Gameobject_Sword.transform.rotation = Quaternion.Euler(0, 0, -225);
        }
        else if (Player_Mouvement.CurrentDirection == "DR")
        {
            Gameobject_Sword.transform.position = new Vector3(transform.position.x + 1, transform.position.y - 1.3f, 0);
            Gameobject_Sword.transform.rotation = Quaternion.Euler(0, 0, -135);
        }

        //If autorization is true so that's means 
        if (Input.GetMouseButtonDown(0) && Autorization == true)
        {
            StartCoroutine(Smashing());
        }

    }

    public float TimeOfAnimation;
    public GameObject Gameobject_Sword;
    bool Autorization = true;

    IEnumerator Smashing()
    {
        Autorization = false;
        Gameobject_Sword.gameObject.SetActive(true);
        yield return new WaitForSeconds(TimeOfAnimation);
        Gameobject_Sword.gameObject.SetActive(false);
        Autorization = true;
    }
}
