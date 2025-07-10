using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using Unity.Mathematics;
using Random = UnityEngine.Random;


public class archer : MonoBehaviour
{
    public GameObject prefab;
    [SerializeField] Transform swordtransform;    
    [SerializeField] float movespeed;
    [SerializeField] int maxhealth;
    public GameObject expPrefab; // Inspector'dan exp prefabını atayın
    Transform target;
	public float speed = .01f;


    int health;
    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.FindWithTag ("Player"))
        {
             target = GameObject.FindWithTag ("Player").transform;
        }
        health = maxhealth;
    }

    // Update is called once per frame
    void FixedUpdate() { 
  
    }
    public void takedamage(int somedamage)
    {
        health -= somedamage;

        Debug.Log(health);

        if (health <= 0) Death();
    }
    void Death()
    {
        Debug.Log("Enemy died");
        if (expPrefab != null)
        {
            Instantiate(expPrefab, transform.position, Quaternion.identity);
        }
        // Destroy the current enemy
        Destroy(gameObject);

        // Spawn the new enemy prefab at a specific location
        Vector3 spawnPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z); // Same position or any other position
        Instantiate(prefab, spawnPoint, quaternion.identity);
    }
}
