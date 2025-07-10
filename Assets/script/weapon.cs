using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class weapon : MonoBehaviour
{
    
    
    private void OnTriggerEnter2D(Collider2D collision) 
    {
         if(collision.CompareTag("enemy") || collision.CompareTag("archer"))
         {
                
                enemy e = null;
                archer a = null;
                if(collision.TryGetComponent(out e))
                {
                    e.takedamage(1);
                  
                }
                
                if(collision.TryGetComponent(out a))
                {
                    a.takedamage(1);
                   
                }
                
         }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
