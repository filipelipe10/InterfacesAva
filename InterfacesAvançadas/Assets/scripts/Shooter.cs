using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    // Start is called before the first frame update
    public float timer =2;
    private float time;
    public Transform firePoint;
    public Transform destination;
    public GameObject muzzle;
    public GameObject projectile;
    public float projectileSpeed = 30;

    void Start()
    {
        time = timer;   
    }

    // Update is called once per frame
    void Update()
    {

        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else 
        {
            time = timer;
            instanciateProjectile(firePoint);
        }
        
    }


    private void instanciateProjectile (Transform firePoint) 
    {
        var MuzjObj = Instantiate (muzzle, firePoint.position, Quaternion.identity) as GameObject;
        var projObj = Instantiate(projectile, firePoint.position, Quaternion.identity) as GameObject;

        float randomY = Random.Range(-0.5f,0.5f);
        Vector3 randomDirection = new Vector3 (randomY, 0.0f, 0.0f);
        Vector3 destinationRandomized = destination.position + randomDirection;
        projObj.GetComponent<Rigidbody>().velocity = (destinationRandomized-firePoint.position).normalized * projectileSpeed;
        Destroy (MuzjObj, 1);
        print(randomY);
    }
}
