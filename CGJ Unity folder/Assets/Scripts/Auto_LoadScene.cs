using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Auto_LoadScene : MonoBehaviour
{

    public string SceneToLoad;

    public void Load()
    {
        SceneManager.LoadScene(SceneToLoad);
    }
}
