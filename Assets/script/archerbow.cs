using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class archerbow : MonoBehaviour
{
    [SerializeField] GameObject BulletPrefab;
    [SerializeField] float BulletSpeed;

    [SerializeField] int ammo;
    [SerializeField] int cooldown;
    [SerializeField] bool stopfire;

    [SerializeField] private player _player;

     void Start()
    {
        if(GameObject.FindWithTag ("Player"))
        {
             _player = GameObject.FindWithTag ("Player").GetComponent<player>();
        }
        InvokeRepeating(nameof(fire) ,0f, 1f);
    }
 
    void Update()
    {
        
        if (ammo >= 20 && !stopfire)
        {
            Invoke(nameof(wait), 1f);
            stopfire = true;
        }
        

    }

    void wait()
    {
        stopfire = false;
        ammo = 0 ;
    }

    void fire()
    {
            Vector3 direction = _player.transform.position - transform.position;

            float angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg) - 90f;

            transform.rotation = Quaternion.Euler(0, 0, angle);  

            direction.Normalize();

            GameObject bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
            ammo += 1;
            
            bullet.transform.up = direction;
            bullet.GetComponent<Rigidbody2D>().velocity = direction * BulletSpeed;

             StartCoroutine(destroybullet(bullet));
    }
    IEnumerator destroybullet(GameObject bulletref)
    {
        yield return new WaitForSeconds(2);
        Destroy(bulletref);
    }
}
