using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using Unity.Mathematics;
using Random = UnityEngine.Random;



public class enemy : MonoBehaviour
{
    public GameObject prefab;
    [SerializeField] Transform swordtransform;    
    [SerializeField] float movespeed;
    [SerializeField] int maxhealth;
    Transform target;
	public float speed = .01f;
    public GameObject expPrefab; // Inspector'dan exp prefabını atayın

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
        if (target) {
        Vector3 forwardAxis = new Vector3 (0, 0, -1);
    	Debug.DrawLine (transform.position, target.position);
		transform.position = Vector3.MoveTowards(transform.position,target.position, 1f * Time.deltaTime);      

        } 
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
        // Exp prefabını düşür
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
