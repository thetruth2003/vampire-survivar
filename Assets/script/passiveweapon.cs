using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class passiveweapon : MonoBehaviour
{
    float nextattack = 0;
    private void OnTriggerStay2D(Collider2D collision)
    {
            if(collision.CompareTag("enemy"))
         
                nextattack += Time.deltaTime;

            if(nextattack >= 1)

            {
                enemy e = null;

                if(collision.TryGetComponent(out e))
                {
                    e.takedamage(1);
                }
                    nextattack = 0;
            }
    }
    
}
