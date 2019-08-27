using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//This is the main script of the scene

public class Main : MonoBehaviour
{
    public static bool DoorOpen;
    public GameObject BG_1, BG_2, BG_3;

    //The time between each respawn
    float cooldownOfRespawn = 2;

    //The gameobject that will be spawn

    public static int Wave = 1;
    public static int RemainsMonster = 5, RemainsMonsterToSummon = 5;

    private void Update()
    {
        if (Wave >= 10)
        {
            BG_1.gameObject.SetActive(false);
            BG_2.gameObject.SetActive(false);
            BG_3.gameObject.SetActive(true);
        }
        else if (Wave >= 5)
        {
            BG_1.gameObject.SetActive(false);
            BG_2.gameObject.SetActive(true);
            BG_3.gameObject.SetActive(false);
        }
        else
        {
            BG_1.gameObject.SetActive(true);
            BG_2.gameObject.SetActive(false);
            BG_3.gameObject.SetActive(false);
        }
        UI();
        if (RemainsMonster <= 0 && DoorOpen == false)
        {
            if (Wave == 4)
            {
                Wave++;
                DoorOpen = true;
            }
            else
            {
                Wave++;
                RemainsMonster = 5 + Wave;
                RemainsMonsterToSummon = 5 + Wave;
            }
        }

        //Make the time reduce by 1 each second
        cooldownOfRespawn -= 1 * (Wave / 10 + 1) * Time.deltaTime;

        //If Cooldown < 0 so it's time to summon a monster
        if (cooldownOfRespawn <= 0 && RemainsMonsterToSummon > 0)
        {

            Spawning_Mob();
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

    public GameObject Runners, DemonHead, RingDemon;

    void Spawning_Mob()
    {
        int MonsterChoosing = 1;
        if (Wave > 2)
        {
            MonsterChoosing = Random.Range(1, 3 + 1);
        }
        else if (Wave > 1)
        {
            MonsterChoosing = Random.Range(1, 2 + 1);
        }
        else
        {
            MonsterChoosing = 1;
        }

        if (MonsterChoosing == 1) // It's the running one
        {
            MonsterSpawn(Runners);
        }
        else if (MonsterChoosing == 2)
        {
            MonsterSpawn(DemonHead);
        }
        else
        {
            MonsterSpawn(RingDemon);
        }

        //Set the time for a new monster to spawn
        cooldownOfRespawn = Random.Range(1, 2 + 1);

        RemainsMonsterToSummon--;
    }

    void MonsterSpawn(GameObject Monster)
    {
        int r = Random.Range(1, 2 + 1);

        //if r = 1
        if (r == 1)
        {

            //do the monster at that random pos
            Monster.transform.position = new Vector3(-14, Random.Range(-5f, 5f + 1), 0);
        }
        else if (r == 2)
        {

            //do the monster at that random pos
            Monster.transform.position = new Vector3(14, Random.Range(-5f, 5f + 1), 0);
        }


        //Create the monster in the scene
        Instantiate(Monster);
    }
}
