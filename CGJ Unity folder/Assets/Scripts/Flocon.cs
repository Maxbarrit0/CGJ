using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Flocon : MonoBehaviour
{
    void Start()
    {
        float Speed = Random.Range(0.3f, 1 + 1);
        this.transform.DOMove(new Vector3(Random.Range(-1, 1 + 1) + this.transform.position.x, Random.Range(-1, 1 + 1) + this.transform.position.y, 1), Speed);
        this.transform.DOScale(0, Speed);
        this.transform.DORotate(new Vector3(0, 0, Random.Range(-180, 180)), Speed);
    }
}
