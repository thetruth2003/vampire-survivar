using System.Collections;
using UnityEngine;

public class enemysword : MonoBehaviour
{
    [SerializeField] private float attackDuration = 1f;
    private bool isDamaging = false; // Coroutine'in çalışıp çalışmadığını kontrol etmek için

    private void OnTriggerStay2D(Collider2D collision) 
    {
        if (collision.CompareTag("Player") && !isDamaging) // Eğer çarpışma oyuncu ile ve coroutine çalışmıyorsa
        {
            StartCoroutine(DamagePlayer(collision)); // Coroutine başlat
        }
    }

    private IEnumerator DamagePlayer(Collider2D player)
    {
        isDamaging = true;
        
        player e = null;
        if (player.TryGetComponent(out e))
        {
            Debug.Log("sikti");
            e.takedamage(1); // Oyuncuya hasar ver
        }

        yield return new WaitForSeconds(attackDuration); // 2 saniye bekle

        isDamaging = false; // Coroutine'in yeniden çalıştırılabilmesi için false yap
    }
}
