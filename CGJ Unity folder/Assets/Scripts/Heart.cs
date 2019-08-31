using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This do the heart show system

public class Heart : MonoBehaviour
{

    //The image represent the render of One single heart
    Image Render;

    private void Start()
    {
        transformRect = GetComponent<RectTransform>();
        Render = GetComponent<Image>();
    }

    //The designated nomber that the heart will be showing
    public float Selection;

    //The sprite that will take "Render" when the boss as enough life depending on the boss life
    public Sprite HeartSprite;

    //the transform of the image
    RectTransform transformRect;

    private void Update()
    {
        //set the position depending of the selection and the boss
        transformRect.anchoredPosition = new Vector3(40 * (Selection - 1) - (20 * (Boss.Life - 1)), 10, 0);
        if (Boss.Life >= Selection)
        {
            Render.enabled = true;
        }
        else
        {
            Render.enabled = false;
        }
    }
}
