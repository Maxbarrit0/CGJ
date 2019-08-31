using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    //Boss life
    public static int Life = 5;

    private void Start()
    {
        SizeFilter = Bulle_Text.GetComponent<ContentSizeFitter>();
        if (Main.EtapeTutoriel == 1)
        {
            StartCoroutine(AfficherParole("HELP! Anyone?! Someone?! HELP!", 0.03f));
        }
        else
        {
            Bulle_Text.text = null;
            Bulle_Image.gameObject.SetActive(false);
        }
    }

    public static bool Occuped = false;
    public GameObject TextSpace;
    bool DejaFait;

    private void Update()
    {
        if (Occuped == true && Finished == true)
        {
            TextSpace.gameObject.SetActive(true);
        }
        else
        {
            TextSpace.gameObject.SetActive(false);
        }
        if (Life >= 10)
        {
            Life = 10;
        }

        if (Main.EtapeTutoriel == 3 && DejaFait == false)
        {
            StartCoroutine(AfficherParole("It's coming for us ! K-Kill those things I don’t wanna die! Here take my stuff and protect me. I don’t wanna die!", 0.01f));
            DejaFait = true;
        }
        else if (Main.EtapeTutoriel == 11 && DejaFait == false)
        {
            StartCoroutine(AfficherParole("Well played my pawn. You’ve played my game well. Unfortunately, your friend there died.", 0.02f));
            DejaFait = true;
        }
        else if (Main.EtapeTutoriel == 13 && DejaFait == false)
        {
            StartCoroutine(AfficherParole("Oh I’ve already showed myself already.", 0.02f));
            DejaFait = true;
        }
        else if (Main.EtapeTutoriel == 15 && DejaFait == false)
        {
            StartCoroutine(AfficherParole("Wrong! Uh what pleasure it is to play this game…", 0.02f));
            DejaFait = true;
        }
        else if (Main.EtapeTutoriel == 17 && DejaFait == false)
        {
            StartCoroutine(AfficherParole("Such a shame. I’ve been with you all along and you didn’t know me?", 0.02f));
            DejaFait = true;
        }
        else if (Main.EtapeTutoriel == 19 && DejaFait == false)
        {
            StartCoroutine(AfficherParole("YES!!! I’m that useless pathetic bastard. Sadly, I don’t have the time to explain your misery to you. I still have billions of other games to play.", 0.02f));
            DejaFait = true;
        }
        else if (Main.EtapeTutoriel == 21 && DejaFait == false)
        {
            StartCoroutine(AfficherParole("Ah yes. Your not the first one to go insane but I commend you for being the first one to survive until the end. Now my part of the bargain is fulfilled. You can go rot now. See you in hell.", 0.02f));
            DejaFait = true;
        }


        SetSizeDialogue();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Finished == true)
            {
                if (Bulle_Text.text != "")
                {
                    Bulle_Text.text = "";
                    Bulle_Image.gameObject.SetActive(false);
                    if (Main.EtapeTutoriel < 4 || Main.EtapeTutoriel >= 10)
                    {
                        Main.EtapeTutoriel++;

                    }
                    if (Main.EtapeTutoriel == 4)
                    {
                        Main.Stop = false;
                    }
                    else if (Main.EtapeTutoriel == 22)
                    {
                        SceneManager.LoadScene("Credit");
                    }
                    Occuped = false;
                    DejaFait = false;
                }

            }
        }
    }

    public void NewMonster(string Monster)
    {
        if (Monster == "DemonHead")
        {
            StartCoroutine(AfficherParole("Oh n-n-n-no-no ! He looks like his head needs to be bashed in with a shield !", 0.01f));
            Main.Ennemy_Head = true;
            Occuped = true;
        }
        else if (Monster == "RingDemon")
        {
            int r = Random.Range(1, 2 + 1);

            Occuped = true;
            if (r == 1)
            {
                StartCoroutine(AfficherParole("Have mercy! Oh God save us!", 0.05f));
            }
            else if (r == 2)
            {
                StartCoroutine(AfficherParole("Anyone but him ! It seems like combinations are more efficient, try hitting him with your Shield then Sword.", 0.01f));
                Main.Ennemy_Ring = true;
            }
            else if (r == 2)
            {
                StartCoroutine(AfficherParole("Have mercy! Oh God save us!", 0.05f));

            }
        }
        else if (Monster == "EarthGolem")
        {
            int r = Random.Range(1, 2 + 1);

            Occuped = true;
            if (r == 1)
            {
                StartCoroutine(AfficherParole("OH this one is an eath monster ! He need to be damaged by your earth spell OH GOD", 0.05f));
            }
            else if (r == 2)
            {
                StartCoroutine(AfficherParole("OH No men be careful you need to damaged him by an earth spell and then use your shield on him !", 0.01f));
                Main.EarthGolem = true;

            }
        }
        else if (Monster == "IceDemon")
        {
            int r = Random.Range(1, 2 + 1);

            Occuped = true;
            if (r == 1)
            {
                StartCoroutine(AfficherParole("OH my god this one is an ice monster ! He need to be damaged by your ice spell OH GOD", 0.01f));
            }
            else if (r == 2)
            {
                StartCoroutine(AfficherParole("Fast ! Damaged it by your ice spell and smash it !", 0.001f));
                Main.IceDemon = true;

            }
        }
    }


    #region Dialogue algorithme // Trying to do aglorithm dialogue

    public static bool Finished;
    ContentSizeFitter SizeFilter;
    public Image Bulle_Image;
    public Text Bulle_Text;

    void SetSizeDialogue()
    {
        Bulle_Image.rectTransform.sizeDelta = new Vector2(Bulle_Text.rectTransform.rect.width * Bulle_Text.rectTransform.localScale.x + 10, Bulle_Text.rectTransform.rect.height * Bulle_Text.rectTransform.localScale.y + 10);
        if (Bulle_Text.rectTransform.rect.width >= 480)
        {
            SizeFilter.horizontalFit = ContentSizeFitter.FitMode.Unconstrained;
        }
        else
        {
            SizeFilter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
        }
    }

    IEnumerator AfficherParole(string Parole, float Speed)
    {
        Bulle_Text.text = null;
        Bulle_Image.gameObject.SetActive(true);
        while (Parole.Length > 0)
        {
            yield return new WaitForSeconds(Speed);
            Bulle_Text.text += Parole[0];
            Parole = Parole.Substring(1);
            Finished = false;
            Occuped = true;
            if (Parole.Length == 0)
            {
                Finished = true;
            }
        }
    }

    #endregion
}
