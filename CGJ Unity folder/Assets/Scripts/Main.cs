using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//This is the main script of the scene

public class Main : MonoBehaviour
{
    public static bool Ennemy_Head, Ennemy_Ring;
    public static bool DoorOpen;
    public GameObject BG_1, BG_2, BG_3;

    //The time between each respawn
    float cooldownOfRespawn = 2;

    //The gameobject that will be spawn

    public static int Wave = 1;
    public static int RemainsMonster = 20, RemainsMonsterToSummon = 20;
    public GameObject Button_Earth, Cadre_Earth, Icon_Earth, Player, Degat;
    public Text Degat_Text, Tuto;
    public Degat ScriptDegat;
    public static bool Stop = true;
    public static int EtapeTutoriel = 1;
    public Player_Mouvement MouvementScriptPlayer;

    private void Update()
    {
        if (EtapeTutoriel == 1)
        {
            MouvementScriptPlayer.enabled = false;
        }
        else
        {
            MouvementScriptPlayer.enabled = true;
        }
        if (Wave < 2)
        {
            if (EtapeTutoriel == 2)
            {
                Tuto.gameObject.SetActive(true);
                Tuto.text = "W,A,S, D or arrows keys for moving";
            }
            else if (EtapeTutoriel == 3)
            {
                Tuto.gameObject.SetActive(true);
                Tuto.text = "Left click for use the swords, Right click for use the shield.";
            }
            else if (EtapeTutoriel == 4)
            {
                Tuto.gameObject.SetActive(true);
                Tuto.text = "Protect this fearful guys or you will die with him. Don't let those monster kill him !";
            }
            else if (EtapeTutoriel == 5)
            {
                Tuto.gameObject.SetActive(true);
                Tuto.text = "This guys have an healt bar in the bottom of the screen, in the top you can see the nomber of wave you are and the remain monster to kill for reach the next one.";
            }
            else if (EtapeTutoriel == 6)
            {
                Tuto.gameObject.SetActive(true);
                Tuto.text = "Not all monster can be killed also easy that those. Some will need combination of attack for be killed. This guys will say you what's the combination but be careful i don't know if you can trust him.";
            }
            else
            {
                Tuto.gameObject.SetActive(false);
            }
        }
        else
        {
            Tuto.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (EtapeTutoriel == 4 || EtapeTutoriel == 5 || EtapeTutoriel == 6)
            {
                EtapeTutoriel++;
            }
        }

        if (Player.transform.position.x < 9 && EarthSpellForm.ActifEarthSpell == true && Wave == 5)
        {
            Wave++;
            RemainsMonster = 5 + Wave;
            RemainsMonsterToSummon = 5 + Wave;
            DoorOpen = false;
            cooldownOfRespawn = 1;
        }
        if (EarthSpellForm.ActifEarthSpell == true)
        {
            Button_Earth.gameObject.SetActive(true);
            Cadre_Earth.gameObject.SetActive(true);
            Icon_Earth.gameObject.SetActive(true);
        }
        else
        {
            Button_Earth.gameObject.SetActive(false);
            Cadre_Earth.gameObject.SetActive(false);
            Icon_Earth.gameObject.SetActive(false);
        }
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
                ScriptDegat.Positif = true;
                if (Boss.Life == 9)
                {
                    Boss.Life += 1;
                    Degat_Text.text = "+ 1 !!!";
                }
                else if (Boss.Life < 10)
                {
                    Boss.Life += 2;
                    Degat_Text.text = "+ 2 !!!";
                }
                ScriptDegat.Positif = false;
                DoorOpen = true;
                Instantiate(Degat);

            }
            else
            {
                Wave++;
                Degat_Text.text = "+ 2 !!!";
                ScriptDegat.Positif = true;
                Instantiate(Degat);
                ScriptDegat.Positif = false;
                if (Boss.Life == 9)
                {
                    Boss.Life += 1;
                    Degat_Text.text = "+ 1 !!!";
                }
                else if (Boss.Life < 10)
                {
                    Boss.Life += 2;
                    Degat_Text.text = "+ 2 !!!";
                }
                RemainsMonster = 5 + Wave;
                RemainsMonsterToSummon = 5 + Wave;
            }
        }

        //Make the time reduce by 1 each second
        cooldownOfRespawn -= 1 * (Wave / 10 + 1) * Time.deltaTime;

        //If Cooldown < 0 so it's time to summon a monster
        if (cooldownOfRespawn <= 0 && RemainsMonsterToSummon > 0)
        {
            if (Stop == false)
            {
                Spawning_Mob();
            }
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

        if (EtapeTutoriel >= 7)
        {
            //Set the time for a new monster to spawn
            cooldownOfRespawn = Random.Range(1, 2 + 1);
        }
        else
        {
            //Set the time for a new monster to spawn
            cooldownOfRespawn = Random.Range(5, 8 + 1);
        }

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
