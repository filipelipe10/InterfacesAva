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
            Vector3 collisionVector = col.contacts[0].point;
            var exploObj = Instantiate(explosion, collisionVector, Quaternion.identity) as GameObject; //explosao aparece à frente da camera pq o colider do character controlor esta offseted para a frente
            Destroy(exploObj, 2);

            if (playerMovemnte.playerDead == false)
            {
                playerMovemnte.playerHp -= 10;
            }

            Vector3 playerPosition = playerMovemnte.transform.position;
            float margin = 0.3f;
            if (collisionVector.x > playerPosition.x + margin)
            {
                print("RightHit");
            }
            else
            {
                if (collisionVector.x < playerPosition.x - margin)
                {
                    print("LeftHit");
                }
                else
                {
                    print("CenterHit");
                }
            }
        }



        if (col.gameObject.tag == "Finish")
        {
            Destroy(gameObject);
        }

    }
}
