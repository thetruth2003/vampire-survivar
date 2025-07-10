using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class megaweopenbullet : MonoBehaviour
{
    
    
    private void OnTriggerEnter2D(Collider2D collision) 
    {
                 if(collision.CompareTag("enemy") || collision.CompareTag("archer"))
         {
                
                enemy e = null;
                archer a = null;
                if(collision.TryGetComponent(out e))
                {
                    e.takedamage(5);
                    Destroy (gameObject);
                }
                
                if(collision.TryGetComponent(out a))
                {
                    a.takedamage(5);
                    Destroy (gameObject);
                }
                
         }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
