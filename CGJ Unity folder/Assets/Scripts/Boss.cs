﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    ContentSizeFitter SizeFilter;
    public Image Bulle_Image;
    public Text Bulle_Text;

    private void Start()
    {
        SizeFilter = Bulle_Text.GetComponent<ContentSizeFitter>();
        StartCoroutine(AfficherParole("AGROUGROU i'm a villain ! You must protect me from those monster or i will kill you! AGROUGROU be careful each monster has these power ! Ho i think this one need swords to be killed... Wait ? Ho no he need the shield i made a mistake sorry ! Or... Ho i forgot AHAHAHAHAHA !", 0.05f));
    }

    private void Update()
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
        while (Parole.Length > 0)
        {
            yield return new WaitForSeconds(Speed);
            Bulle_Text.text += Parole[0];
            Parole = Parole.Substring(1);
        }
    }
}
