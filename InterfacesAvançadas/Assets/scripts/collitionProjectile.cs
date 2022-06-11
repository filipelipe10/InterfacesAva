using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collitionProjectile : MonoBehaviour
{
    // Start is called before the first frame update

    public PlayerMovemnte playerMovemnte;
    public GameObject explosion;
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
            var exploObj = Instantiate(explosion, col.contacts[0].point, Quaternion.identity) as GameObject; //explosao aparece à frente da camera pq o colider do character controlor esta offseted para a frente
            Destroy(exploObj, 2);
            print("Player hit");

            if(playerMovemnte.playerDead == false)
            {
                playerMovemnte.playerHp -= 10;
            }

        }

        if (col.gameObject.tag == "Finish")
        {
            Destroy(gameObject);
        }

    }
}
