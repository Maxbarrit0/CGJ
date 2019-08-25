using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Sword : MonoBehaviour
{
    void Update()
    {
        if (Player_Mouvement.CurrentDirection == "D")
        {
            Gameobject_Epee.transform.position = new Vector3(transform.position.x + 1, transform.position.y, 0);
            Gameobject_Epee.transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        else if (Player_Mouvement.CurrentDirection == "G")
        {

            Gameobject_Epee.transform.position = new Vector3(transform.position.x - 1, transform.position.y, 0);
            Gameobject_Epee.transform.rotation = Quaternion.Euler(0, 0, 90);

        }
        else if (Player_Mouvement.CurrentDirection == "H")
        {

            Gameobject_Epee.transform.position = new Vector3(transform.position.x, transform.position.y + 1.3f, 0);
            Gameobject_Epee.transform.rotation = Quaternion.Euler(0, 0, 0);

        }
        else if (Player_Mouvement.CurrentDirection == "B")
        {
            Gameobject_Epee.transform.position = new Vector3(transform.position.x, transform.position.y - 1.3f, 0);
            Gameobject_Epee.transform.rotation = Quaternion.Euler(0, 0, -180);
        }
        else if (Player_Mouvement.CurrentDirection == "HD")
        {
            Gameobject_Epee.transform.position = new Vector3(transform.position.x + 1, transform.position.y + 1.3f, 0);
            Gameobject_Epee.transform.rotation = Quaternion.Euler(0, 0, -45);
        }
        else if (Player_Mouvement.CurrentDirection == "HG")
        {
            Gameobject_Epee.transform.position = new Vector3(transform.position.x - 1, transform.position.y + 1.3f, 0);
            Gameobject_Epee.transform.rotation = Quaternion.Euler(0, 0, 45);
        }
        else if (Player_Mouvement.CurrentDirection == "BG")
        {
            Gameobject_Epee.transform.position = new Vector3(transform.position.x - 1, transform.position.y - 1.3f, 0);
            Gameobject_Epee.transform.rotation = Quaternion.Euler(0, 0, -225);
        }
        else if (Player_Mouvement.CurrentDirection == "BD")
        {
            Gameobject_Epee.transform.position = new Vector3(transform.position.x + 1, transform.position.y - 1.3f, 0);
            Gameobject_Epee.transform.rotation = Quaternion.Euler(0, 0, -135);
        }

        if (Input.GetMouseButtonDown(0) && Autorization == true)
        {
            StartCoroutine(Epee());
        }

    }

    public float TimeOfAnimation;
    public GameObject Gameobject_Epee;
    bool Autorization = true;

    IEnumerator Epee()
    {
        Autorization = false;
        Gameobject_Epee.gameObject.SetActive(true);
        yield return new WaitForSeconds(TimeOfAnimation);
        Gameobject_Epee.gameObject.SetActive(false);
        Autorization = true;
    }
}
