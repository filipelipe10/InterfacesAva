using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonStart : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerMovemnte playerMovemnte;
    public Button start;
    public GameObject motorInterface;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerMovemnte.playerDead == true)
        {
            start.gameObject.SetActive(true);
            motorInterface.SetActive(false);
        }
        else
        {
            start.gameObject.SetActive(false);
            motorInterface.SetActive(true);
        }
    }

    public void buttonStarst()
    {
        playerMovemnte.playerDead = false;

    }
}
