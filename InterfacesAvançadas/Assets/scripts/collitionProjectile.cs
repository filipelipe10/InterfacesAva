using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collitionProjectile : MonoBehaviour
{
    // Start is called before the first frame update

    public PlayerMovemnte playerMovemnte;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            playerMovemnte.playerHp -= 10;
            print("Player hit");

        }

        if (col.gameObject.tag == "Finish")
        {
            Destroy(gameObject);
        }

    }
}
