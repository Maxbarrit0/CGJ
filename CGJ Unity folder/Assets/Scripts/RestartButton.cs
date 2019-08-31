using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{

    public void Restart()
    {
        SceneManager.LoadScene("Room");
        Main.Wave = 1;
        Main.RemainsMonster = 5;
        Main.RemainsMonsterToSummon = 5;
        EarthSpellForm.ActifEarthSpell = false;
        IceSpell.Activation_IceSpell = false;
        Boss.Life = 5;
    }
}
