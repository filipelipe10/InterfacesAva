using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    // Start is called before the first frame update
    public float timer = 3;
    private float time;
    private float timerPre = 2.7f;
    private float timePre;

    public Transform firePoint;
    public Transform destination;
    public GameObject muzzle;
    public GameObject projectile;
    public GameObject preMuzzle;
    public float projectileSpeed = 30;
    public float waitTimer = 5;
    private float waitTime;
    public PlayerMovemnte playerMovemnte;

    void Start()
    {
        time = timer;
        waitTime = waitTimer;
        timePre = timerPre;
    }

    // Update is called once per frame
    void Update()
    {


        if (playerMovemnte.playerDead == false)
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
                    if (timePre > 0)
                    {
                        timePre -= Time.deltaTime;
                    }
                    else
                    {
                        var preMuz = Instantiate(preMuzzle, firePoint.position, Quaternion.identity) as GameObject;
                        Destroy(preMuz, 2);
                        timePre = time+1; //valor ao calhas

                    }
                }
                else
                {

                    if (timer > 0.5f)
                    {
                        timer *= 0.95f;
                        timerPre *= 0.95f;
                    }
                   

                    time = timer;
                    timePre = timerPre;

                    instanciateProjectile(firePoint);
                }




            }

        }

        else
        {
            waitTime = waitTimer;
            time = timer;
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
    }
}
