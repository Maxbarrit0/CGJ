using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is the main script of the scene

public class Main : MonoBehaviour
{
    //The time between each respawn
    float cooldownOfRespawn = 2;

    //The gameobject that will be spawn
    public GameObject Monstre;

    private void Update()
    {
        //Make the time reduce by 1 each second
        cooldownOfRespawn -= 1 * Time.deltaTime;

        //If Cooldown < 0 so it's time to summon a monster
        if (cooldownOfRespawn <= 0)
        {
            //take a value that will have a random value between 1 and 2 (In this command there is a surcharges of 1 so we need to add 1)
            int r = Random.Range(1, 2 + 1);

            //if r = 1
            if (r == 1)
            {
                //do the monster at that random pos
                Monstre.transform.position = new Vector3(-14, Random.Range(-6.5f, 6.5f + 1), 0);
            }
            else if (r == 2)
            {
                //do the monster at that random pos
                Monstre.transform.position = new Vector3(14, Random.Range(-6.5f, 6.5f + 1), 0);
            }

            //Set the time for a new monster to spawn
            cooldownOfRespawn = Random.Range(1, 2 + 1);

            //Create the monster in the scene
            Instantiate(Monstre);
        }
    }
}
