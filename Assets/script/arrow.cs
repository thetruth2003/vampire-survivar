using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) 
    {
         if(collision.CompareTag("Player"))
         {
                
                player e = null;
                if(collision.TryGetComponent(out e))
                {
                e.takedamage(1);
                Destroy (gameObject);
                }
                
         }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
