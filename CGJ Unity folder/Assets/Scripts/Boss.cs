using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    }

    public static bool Occuped = false;
    bool DejaFait;

    private void Update()
    {
        if (Main.EtapeTutoriel == 3 && DejaFait == false)
        {
            StartCoroutine(AfficherParole("It's coming for us ! K-Kill those things I don’t wanna die! Here take my stuff and protect me. I don’t wanna die!", 0.01f));
            DejaFait = true;
        }
        SetSizeDialogue();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Finished == false)
            {
                //StopCoroutine(AfficherParole(TextToShow, 0.05f));
                //Bulle_Text.text = TextToShow;
            }
            else
            {
                if (Bulle_Text.text != "")
                {
                    Bulle_Text.text = "";
                    Bulle_Image.gameObject.SetActive(false);
                    Main.EtapeTutoriel++;
                    if (Main.EtapeTutoriel == 4)
                    {
                        Main.Stop = false;
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
                StartCoroutine(AfficherParole("Anyone but him ! It seems like combonations are more efficient, try hitting him with your sword then you shield.
            else if (r == 2)
            {
                StartCoroutine(AfficherParole("Have mercy! Oh God save us!", 0.05f));
                Main.Ennemy_Ring = true;

            }
        }
    }

    #region Dialogue algorithme // Trying to do aglorithm dialogue

    bool Finished;
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
            if (Parole.Length == 0)
            {
                Finished = true;
            }
        }
    }

    #endregion
}
