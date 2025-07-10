using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exp : MonoBehaviour
{
    public int expAmount = 1; // Kaç exp verecek

    private void OnTriggerEnter2D(Collider2D other)
    {
        player playerScript = other.GetComponent<player>();
        if (playerScript != null)
        {
            playerScript.takeexp(expAmount);
            Destroy(gameObject); // Exp objesini yok et
        }
    }
}