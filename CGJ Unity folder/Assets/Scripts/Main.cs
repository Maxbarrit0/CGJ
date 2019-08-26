using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//This is the main script of the scene

public class Main : MonoBehaviour
{
    //The time between each respawn
    float cooldownOfRespawn = 2;

    //The gameobject that will be spawn
    public GameObject Monstre;
    Ennemy Script_Ennemy;

    public int Wave = 1;
    public static int RemainsMonster = 10, RemainsMonsterToSummon = 10;

    private void Start()
    {
        Script_Ennemy = Monstre.GetComponent<Ennemy>();
    }

    private void Update()
    {
        UI();
        if (RemainsMonster <= 0)
        {
            Wave++;
            RemainsMonster = 10 + 5 * Wave;
            RemainsMonsterToSummon = 10 + 5 * Wave;
        }

        //Make the time reduce by 1 each second
        cooldownOfRespawn -= 1 * (Wave / 10 + 1) * Time.deltaTime;

        //If Cooldown < 0 so it's time to summon a monster
        if (cooldownOfRespawn <= 0 && RemainsMonsterToSummon >= 1)
        {
            //take a value that will have a random value between 1 and 2 (In this command there is a surcharges of 1 so we need to add 1)
            int r = Random.Range(1, 2 + 1);

            //if r = 1
            if (r == 1)
            {
                Script_Ennemy.Direction = "R";
                Script_Ennemy.Speed = Wave + 5;

                //do the monster at that random pos
                Monstre.transform.position = new Vector3(-14, Random.Range(-6.5f, 6.5f + 1), 0);
            }
            else if (r == 2)
            {
                Script_Ennemy.Direction = "L";
                Script_Ennemy.Speed = Wave + 5;

                //do the monster at that random pos
                Monstre.transform.position = new Vector3(14, Random.Range(-6.5f, 6.5f + 1), 0);
            }

            //Set the time for a new monster to spawn
            cooldownOfRespawn = Random.Range(1, 2 + 1);

            RemainsMonsterToSummon--;

            //Create the monster in the scene
            Instantiate(Monstre);
        }

        // this part do thing if the boss die

        if (Boss.Life <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public Text WaveText, RemainMonster;

    void UI()
    {
        WaveText.text = "Wave : " + Wave;
        RemainMonster.text = "" + RemainsMonster + " Remains monster";
    }
}
