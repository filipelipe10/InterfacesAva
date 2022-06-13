using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class collitionProjectile : MonoBehaviour
{
    // Start is called before the first frame update

    public PlayerMovemnte playerMovemnte;
    public interfaceVibration interfaceVibration;
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
            float margin = 0.2f;
            ArduinoController arduinoController = col.gameObject.GetComponent<ArduinoController>();
            if (collisionVector.x > playerPosition.x + margin)
            {
                interfaceVibration.rightHit = true;
                interfaceVibration.timeRight = interfaceVibration.vibrationDuration;
                arduinoController.HitRight();
            }
            else
            {
                if (collisionVector.x < playerPosition.x - margin)
                {
                    interfaceVibration.leftHit = true;
                    interfaceVibration.timeLeft = interfaceVibration.vibrationDuration;
                    arduinoController.HitLeft();
                }
                else
                {
                    interfaceVibration.centerHit = true;
                    interfaceVibration.timeCenter = interfaceVibration.vibrationDuration;
                    arduinoController.HitMiddle();
                }
            }
        }



        if (col.gameObject.tag == "Finish")
        {
            Destroy(gameObject);
        }

    }
}
