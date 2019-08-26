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
        Main.RemainsMonster = 10;
        Main.RemainsMonsterToSummon = 10;
        Boss.Life = 5;
    }
}
