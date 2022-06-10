using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    // Start is called before the first frame update
    public float timer = 3;
    private float time;

    public Transform firePoint;
    public Transform destination;
    public GameObject muzzle;
    public GameObject projectile;
    public float projectileSpeed = 30;
    public float waitTimer = 5;
    private float waitTime;

    void Start()
    {
        time = timer;
        waitTime = waitTimer;
    }

    // Update is called once per frame
    void Update()
    {

        

        if (waitTime > 0)
        {
            waitTime -= Time.deltaTime;
        }
        else
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
            }
            else
            {
                if (timer > 0.5f)
                {
                    timer *= 0.95f;
                }

                time = timer;


                instanciateProjectile(firePoint);
            }

        }




    }


    private void instanciateProjectile(Transform firePoint)
    {
        var MuzjObj = Instantiate(muzzle, firePoint.position, Quaternion.identity) as GameObject;
        var projObj = Instantiate(projectile, firePoint.position, Quaternion.identity) as GameObject;

        float randomY = Random.Range(-1f, 1f);
        Vector3 randomDirection = new Vector3(randomY, 0.0f, 0.0f);
        Vector3 destinationRandomized = destination.position + randomDirection;
        projObj.GetComponent<Rigidbody>().velocity = (destinationRandomized - firePoint.position).normalized * projectileSpeed;
        Destroy(MuzjObj, 1);
        print(randomY);
    }
}
