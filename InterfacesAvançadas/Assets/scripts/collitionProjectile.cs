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
            playerMovemnte.playerHp -= 10;
            Vector3 offset = new Vector3(col.contacts[0].point.x*2, 0,2);
            Vector3 spawnPoint = col.contacts[0].point + offset;
            var exploObj = Instantiate(explosion, spawnPoint, Quaternion.identity) as GameObject;
            Destroy(exploObj, 2);
            print("Player hit");

        }

        if (col.gameObject.tag == "Finish")
        {
            Destroy(gameObject);
        }

    }
}
