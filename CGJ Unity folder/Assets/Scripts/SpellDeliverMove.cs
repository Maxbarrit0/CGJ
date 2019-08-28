using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpellDeliverMove : MonoBehaviour
{
    float Speed;

    void Start()
    {
        Speed = Random.Range(0.5f, 0.7f + 1);
        this.transform.DOLocalMove(new Vector3(Random.Range(-1, 1), -2, 0), Speed);
        this.transform.DOScale(new Vector3(0.2f, 0.2f), Speed);
        this.transform.DORotate(new Vector3(0, 0, Random.Range(-180, 180)), Speed);
        StartCoroutine(SetActif());
    }

    public bool Actif;

    IEnumerator SetActif()
    {
        yield return new WaitForSeconds(Speed + 0.2f);
        Actif = true;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Actif == true)
        {
            this.gameObject.SetActive(false);
            EarthSpellForm.ActifEarthSpell = true;
        }
    }
}
