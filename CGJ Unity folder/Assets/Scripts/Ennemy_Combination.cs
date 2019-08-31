using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy_Combination : MonoBehaviour
{

    CircleCollider2D ThisCollider;

    public enum NameMonster { None, DemonHead, RingDemon, EarthGolem, IceDemon }

    public NameMonster Name;

    public enum TypeOfMonster { Normal, Tutorial }

    public TypeOfMonster TypeOfMonstre;

    public enum ElementMonster { None, Earth, Ice }

    public ElementMonster Element;

    public enum TypeAttack { Smash, Protecting, None }

    public TypeAttack TypeAttackOne;
    public TypeAttack TypeAttackTwo;
    public TypeAttack TypeAttackThree;

    string CurrentState;

    public bool EarthDamaged, IceDamaged;

    public GameObject BossG;
    Ennemy Script;

    private void Start()
    {
        if (Name.ToString() == "DemonHead" && Boss.Finished == true && Main.Ennemy_Head == false)
        {
            BossG.SendMessage("NewMonster", "DemonHead");
        }
        else if (Name.ToString() == "RingDemon" && Boss.Finished == true && Main.Ennemy_Ring == false)
        {
            BossG.SendMessage("NewMonster", "RingDemon");
        }
        else if (Name.ToString() == "EarthGolem" && Boss.Finished == true && Main.EarthGolem == false)
        {
            BossG.SendMessage("NewMonster", "EarthGolem");
        }
        else if (Name.ToString() == "IceDemon" && Boss.Finished == true && Main.IceDemon == false)
        {
            BossG.SendMessage("NewMonster", "IceDemon");
        }
        ThisCollider = this.GetComponent<CircleCollider2D>();
        Script = this.GetComponent<Ennemy>();
        CurrentState = TypeAttackOne.ToString();
    }

    private void Update()
    {
        if (CurrentState.ToString() == "None")
        {
            if (Element.ToString() == "None")
            {
                Main.RemainsMonster--;
                Mort.transform.position = this.transform.position;
                Instantiate(Mort);
                Destroy(this.gameObject);
            }
            else if (Element.ToString() == "Earth" && EarthDamaged == true)
            {
                Main.RemainsMonster--;
                Mort.transform.position = this.transform.position;
                Instantiate(Mort);
                Destroy(this.gameObject);
            }
            else if (Element.ToString() == "Ice" && IceDamaged == true)
            {
                Main.RemainsMonster--;
                Mort.transform.position = this.transform.position;
                Instantiate(Mort);
                Destroy(this.gameObject);
            }
        }
    }

    public GameObject Mort;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (TypeOfMonstre.ToString() == "Tutorial")
        {
            if (collision.gameObject.tag == "Sword") // if he is smahing he die
            {
                Main.RemainsMonster--;
                Mort.transform.position = this.transform.position;
                Instantiate(Mort);
                Destroy(this.gameObject);
            }
            else if (collision.gameObject.tag == "Shield")
            {
                if (Script.Knocked <= 0)
                {
                    Script.Pos = transform.position - collision.gameObject.transform.position;
                    Script.Pos.Normalize();
                    Script.Velocity = Script.Pos * Script.ForceWhenKnocked;
                    Script.Rigid.velocity = Script.Pos * Script.ForceWhenKnocked;
                    Script.Knocked = Script.Durée;
                }
            }
        }
        else
        {
            if (collision.gameObject.tag == "Sword" && CurrentState == "Smash") // if he is smahing he die
            {
                if (CurrentState == TypeAttackOne.ToString())
                {

                    CurrentState = TypeAttackTwo.ToString();
                }
                else if (CurrentState == TypeAttackTwo.ToString())
                {
                    CurrentState = TypeAttackThree.ToString();
                }
                else if (CurrentState == TypeAttackThree.ToString())
                {
                    CurrentState = "None";

                }
            }
            else if (collision.gameObject.tag == "Sword")
            {
                Physics2D.IgnoreCollision(collision.collider, ThisCollider);
            }

            if (collision.gameObject.tag == "Shield" && CurrentState == "Protecting")
            {
                if (Script.Knocked <= 0)
                {
                    Script.Pos = transform.position - collision.gameObject.transform.position;
                    Script.Pos.Normalize();
                    Script.Velocity = Script.Pos * Script.ForceWhenKnocked;
                    Script.Rigid.velocity = Script.Pos * Script.ForceWhenKnocked;
                    Script.Knocked = Script.Durée;
                }
                if (CurrentState == TypeAttackOne.ToString())
                {
                    CurrentState = TypeAttackTwo.ToString();
                }
                else if (CurrentState == TypeAttackTwo.ToString())
                {
                    CurrentState = TypeAttackThree.ToString();
                }
                else if (CurrentState == TypeAttackThree.ToString())
                {
                    CurrentState = "None";
                }
            }
            else if (collision.gameObject.tag == "Shield")
            {
                if (Script.Knocked <= 0)
                {
                    Script.Pos = transform.position - collision.gameObject.transform.position;
                    Script.Pos.Normalize();
                    Script.Velocity = Script.Pos * Script.ForceWhenKnocked;
                    Script.Rigid.velocity = Script.Pos * Script.ForceWhenKnocked;
                    Script.Knocked = Script.Durée;
                }
            }
        }
    }
}
