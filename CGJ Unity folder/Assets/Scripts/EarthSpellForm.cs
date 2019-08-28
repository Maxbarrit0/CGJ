using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthSpellForm : MonoBehaviour
{
    public static bool ActifEarthSpell;
    public bool Destroy;
    public bool Actif = true;
    Animator Anim;
    public GameObject Area;
    public float PosGeneral, PosGeneralX;
    public float PosX, PosY;

    private void Start()
    {
        Anim = GetComponent<Animator>();
        Anim.speed = Random.Range(0.5f, 2);
        PosY = PosGeneral;
        PosX = Random.Range(-PosGeneralX, PosGeneralX);
    }

    void Update()
    {
        if (Destroy == true)
        {
            Destroy(this.gameObject);
        }
        if (Actif == true)
        {
            if (Area.gameObject.tag == "Stop")
            {
                Anim.SetInteger("State", 1);
            }
            this.transform.position = new Vector2(PosX + Area.transform.position.x, PosY + Area.transform.position.y);
        }
    }
}
