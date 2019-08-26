using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy_Combination : MonoBehaviour
{

    CircleCollider2D ThisCollider;

    public enum TypeOfMonster { Normal, Tutorial }

    public TypeOfMonster TypeOfMonstre;

    public enum TypeAttack { Smash, Protecting, None }

    public TypeAttack TypeAttackOne;
    public TypeAttack TypeAttackTwo;
    public TypeAttack TypeAttackThree;

    string CurrentState;

    Ennemy Script;

    private void Start()
    {
        ThisCollider = this.GetComponent<CircleCollider2D>();
        Script = this.GetComponent<Ennemy>();
        CurrentState = TypeAttackOne.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (TypeOfMonstre.ToString() == "Tutorial")
        {
            if (collision.gameObject.tag == "Sword") // if he is smahing he die
            {
                Main.RemainsMonster--;
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
                    if (TypeAttackTwo.ToString() == "None")
                    {
                        Main.RemainsMonster--;
                        Destroy(this.gameObject);
                    }
                    CurrentState = TypeAttackTwo.ToString();
                }
                else if (CurrentState == TypeAttackTwo.ToString())
                {
                    if (TypeAttackThree.ToString() == "None")
                    {
                        Main.RemainsMonster--;
                        Destroy(this.gameObject);
                    }
                    CurrentState = TypeAttackThree.ToString();
                }
                else if (CurrentState == TypeAttackThree.ToString())
                {
                    Main.RemainsMonster--;
                    Destroy(this.gameObject);
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
                    if (TypeAttackTwo.ToString() == "None")
                    {
                        Main.RemainsMonster--;
                        Destroy(this.gameObject);
                    }
                    CurrentState = TypeAttackTwo.ToString();
                }
                else if (CurrentState == TypeAttackTwo.ToString())
                {
                    if (TypeAttackThree.ToString() == "None")
                    {
                        Main.RemainsMonster--;
                        Destroy(this.gameObject);
                    }
                    CurrentState = TypeAttackThree.ToString();
                }
                else if (CurrentState == TypeAttackThree.ToString())
                {
                    Main.RemainsMonster--;
                    Destroy(this.gameObject);
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
