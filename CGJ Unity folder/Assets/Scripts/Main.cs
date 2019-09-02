using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//This is the main script of the scene

public class Main : MonoBehaviour
{
    public static bool Ennemy_Head, Ennemy_Ring, EarthGolem, IceDemon;
    public static bool DoorOpen;
    public GameObject BG_1, BG_2, BG_3;

    //The time between each respawn
    float cooldownOfRespawn = 2;

    //The gameobject that will be spawn

    public static int Wave = 1;
    public static int RemainsMonster = 4, RemainsMonsterToSummon = 4;
    public GameObject Player, Degat;
    public RectTransform Button_Ice, Cadre_Ice, Icon_Ice, Button_Earth, Cadre_Earth, Icon_Earth;
    public Text Degat_Text, Tuto;
    public Degat ScriptDegat;
    public static bool Stop = true;
    public static int EtapeTutoriel = 1;
    public Player_Mouvement MouvementScriptPlayer;

    private void Update()
    {
        if (EarthSpellForm.ActifEarthSpell == true && IceSpell.Activation_IceSpell == false)
        {
            Button_Earth.anchoredPosition = new Vector3(0, 55.3999f, 0);
            Cadre_Earth.anchoredPosition = new Vector3(0, 53.04004f, 0);
            Icon_Earth.anchoredPosition = new Vector3(0, 58.47412f, 0);

        }
        else if (EarthSpellForm.ActifEarthSpell == false && IceSpell.Activation_IceSpell == true)
        {
            Button_Ice.anchoredPosition = new Vector3(0, 55.3999f, 0);
            Cadre_Ice.anchoredPosition = new Vector3(0, 53.04004f, 0);
            Icon_Ice.anchoredPosition = new Vector3(0, 58.47412f, 0);
        }
        else if (EarthSpellForm.ActifEarthSpell == true && IceSpell.Activation_IceSpell == true)
        {
            Button_Ice.anchoredPosition = new Vector3(-18, 55.3999f, 0);
            Cadre_Ice.anchoredPosition = new Vector3(-18, 53.04004f, 0);
            Icon_Ice.anchoredPosition = new Vector3(-18, 58.47412f, 0);
            Button_Earth.anchoredPosition = new Vector3(18, 55.3999f, 0);
            Cadre_Earth.anchoredPosition = new Vector3(18, 53.04004f, 0);
            Icon_Earth.anchoredPosition = new Vector3(18, 58.47412f, 0);
        }
        if (Wave >= 20 && Stop == false)
        {
            EtapeTutoriel = 10;
            Stop = true;
        }
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
                Tuto.text = "Use W, A, S, D or the arrow keys to move around.";
            }
            else if (EtapeTutoriel == 3)
            {
                Tuto.gameObject.SetActive(true);
                Tuto.text = "Use your left mouse button to swing your sword Use the right mouse button to block with your shield.";
            }
            else if (EtapeTutoriel == 4)
            {
                Tuto.gameObject.SetActive(true);
                Tuto.text = "Your goal is to defend your old boss from these abommination";

            }
            else if (EtapeTutoriel == 5)
            {
                Tuto.gameObject.SetActive(true);
                Tuto.text = "Don't let the healt bar at the bottom drain otherwise it will result in a game over. kill all the monster in the wave to move on to the next wave";

            }
            else if (EtapeTutoriel == 6)
            {
                Tuto.gameObject.SetActive(true);
                Tuto.text = "";
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
        if (Wave == 5)
        {
            if (Player.transform.position.x < 9 && (EarthSpellForm.ActifEarthSpell == true || IceSpell.Activation_IceSpell == true))
            {
                Wave++;
                RemainsMonster = 5 + Wave;
                RemainsMonsterToSummon = 5 + Wave;
                DoorOpen = false;
                cooldownOfRespawn = 1;
            }
        }
        else if (Wave == 10)
        {
            if (Player.transform.position.x < 9 && EarthSpellForm.ActifEarthSpell == true && IceSpell.Activation_IceSpell == true)
            {
                Wave++;
                RemainsMonster = 5 + Wave;
                RemainsMonsterToSummon = 5 + Wave;
                DoorOpen = false;
                cooldownOfRespawn = 1;
            }
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

        if (IceSpell.Activation_IceSpell == true)
        {
            Cadre_Ice.gameObject.SetActive(true);
            Button_Ice.gameObject.SetActive(true);
            Icon_Ice.gameObject.SetActive(true);
        }
        else
        {
            Cadre_Ice.gameObject.SetActive(false);
            Button_Ice.gameObject.SetActive(false);
            Icon_Ice.gameObject.SetActive(false);
        }

        if (Wave >= 10)
        {
            BG_1.gameObject.SetActive(false);
            BG_2.gameObject.SetActive(false);
            BG_3.gameObject.SetActive(true);
            Red.gameObject.SetActive(true);
            Green.SetActive(false);
            Grey.SetActive(false);
        }
        else if (Wave >= 5)
        {
            BG_1.gameObject.SetActive(false);
            BG_2.gameObject.SetActive(true);
            BG_3.gameObject.SetActive(false);
            Red.gameObject.SetActive(false);
            Green.SetActive(false);
            Grey.SetActive(true);
        }
        else if (Wave < 5)
        {
            BG_1.gameObject.SetActive(true);
            BG_2.gameObject.SetActive(false);
            BG_3.gameObject.SetActive(false);
            Red.gameObject.SetActive(false);
            Green.SetActive(true);
            Grey.SetActive(false);
        }

        UI();
        if (RemainsMonster <= 0 && DoorOpen == false)
        {
            if (Wave == 4 || Wave == 9)
            {
                Wave++;
                ScriptDegat.Positif = true;
                Boss.Life += 2;
                Degat_Text.text = "+ 2 !!!";
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
                Boss.Life += 2;
                Degat_Text.text = "+ 2 !!!";
                RemainsMonster = 2 + Wave;
                RemainsMonsterToSummon = 2 + Wave;
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
        if (DoorOpen == true)
        {
            RemainMonster.text = "A door is opened";
        }
        else
        {
            RemainMonster.text = "" + RemainsMonster + " Monsters Remain";

        }
    }

    public GameObject Runners, DemonHead, RingDemon, EarthGolemG, IceDemonG;

    void Spawning_Mob()
    {
        int MonsterChoosing = 1;
        if (EarthSpellForm.ActifEarthSpell == true || IceSpell.Activation_IceSpell == true)
        {
            MonsterChoosing = Random.Range(1, 4 + 1);

        }
        else if (Wave > 2)
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
        else if (MonsterChoosing == 3 && (EarthSpellForm.ActifEarthSpell == true || IceSpell.Activation_IceSpell == true))
        {
            if (EarthSpellForm.ActifEarthSpell == true)
            {
                MonsterSpawn(EarthGolemG);
            }
            else if (IceSpell.Activation_IceSpell == true)
            {
                MonsterSpawn(IceDemonG);
            }
        }
        else
        {
            MonsterSpawn(RingDemon);
        }

        if (EtapeTutoriel >= 6)
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

    public GameObject Green, Grey, Red;
}
