using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLookAt : MonoBehaviour
{
    [SerializeField] private player _player;
    [SerializeField] private enemysword _enemysword;

    // Update is called once per frame

    private void Awake() {
        if( GameObject.FindGameObjectWithTag("Player"))
        {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
       }
    }
    void Update()
    {
        if(_player)
        {
        Vector3 direction = _player.transform.position - transform.position;

            float angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg) - 90f;

            transform.rotation = Quaternion.Euler(0, 0, angle);  
        }
    }
}
