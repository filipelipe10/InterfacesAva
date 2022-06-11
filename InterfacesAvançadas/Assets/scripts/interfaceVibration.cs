using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class interfaceVibration : MonoBehaviour
{
    // Start is called before the first frame update
   

    public Image centerImg;
    public Image rightImg;
    public Image leftImg;


    public bool centerHit = false;
    public bool leftHit = false;
    public bool rightHit = false;


    public float timeCenter = 1.5f;
    public float timeLeft = 1.5f;
    public float timeRight = 1.5f;

    public float vibrationDuration = 1.5f;

    public Color hitColor;
    public Color normalColor;


    void Start()
    {
        timeCenter = vibrationDuration;
        timeRight = vibrationDuration;
        timeLeft = vibrationDuration;

        centerImg.color = normalColor;
        rightImg.color = normalColor;
        leftImg.color = normalColor;
    }

    // Update is called once per frame
    void Update()
    {

        
        if (centerHit)
        {
            centerImg.color = hitColor;
            if (timeCenter > 0)
            {
                timeCenter -= Time.deltaTime;
            }
            else
            {
                centerImg.color = normalColor;
                centerHit = false;
                timeCenter = vibrationDuration;
            }
        }

        if (rightHit)
        {
            rightImg.color = hitColor;
            if (timeRight > 0)
            {
                timeRight -= Time.deltaTime;
            }
            else
            {
                rightImg.color = normalColor;
                rightHit = false;
                timeCenter = vibrationDuration;
            }
        }

        if (leftHit)
        {
            leftImg.color = hitColor;
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
            }
            else
            {
                leftImg.color = normalColor;
                leftHit = false;
                timeLeft = vibrationDuration;
            }
        }
    }
}
