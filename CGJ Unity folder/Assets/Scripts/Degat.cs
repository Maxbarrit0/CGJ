using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Degat : MonoBehaviour
{
    public bool Positif;
    Text Text;

    void Start()
    {
        Text = GetComponent<Text>();
        if (Positif == true)
        {
            Text.color = new Color32(0, 255, 24, 255);
            this.transform.DOLocalMove(new Vector3(Random.Range(-60, 60), 60 + 65, 0), 3);
            this.transform.DOScale(2, 3);
            Text.DOFade(0, 3);
        }
        else
        {
            Text.color = new Color32(255, 0, 0, 255);
            this.transform.DOLocalMove(new Vector3(Random.Range(-60, 60), 60 + 65, 0), 1);
            this.transform.DOScale(2, 1);
            Text.DOFade(0, 1);
        }
    }

}
