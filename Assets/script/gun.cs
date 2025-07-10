using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject BulletPrefab;
    [SerializeField] float BulletSpeed;
    [SerializeField] int cooldown;
    [SerializeField] bool stopfire;
    public int maxAmmo = 20;  // Maksimum sağlık
    public int currentAmmo;    // Şu anki sağlık
    
    [SerializeField] public UnityEngine.UI.Image ammoBar;   // UI Sağlık Barı
    void Start()
    {
        currentAmmo = maxAmmo;  // Oyunun başında maksimum sağlıkla başlar
        UpdateAmmoBar();
    }
    void Update()
    {
        if (currentAmmo <= 0 && !stopfire)
        {
            Invoke(nameof(wait), 3f);
            stopfire = true;
            UpdateAmmoBar();
        }
        
        if (Input.GetMouseButtonDown(0) && !stopfire)
        {
            //input.mousePosition - mouse position in screenspace

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //mousePos.z = 0; 

            Vector3 bulletDirection = mousePos - (Vector2)transform.position;

            bulletDirection.Normalize();

            GameObject bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
            currentAmmo -= 1;
            UpdateAmmoBar();
            bullet.transform.up = bulletDirection;
            bullet.GetComponent<Rigidbody2D>().velocity = bulletDirection * BulletSpeed;

               StartCoroutine(destroybullet(bullet));
            
            }
       

    }
      public void takedamage()
    {
        currentAmmo -= 1;

        Debug.Log(currentAmmo);
    }
    void UpdateAmmoBar()
    {
           if (ammoBar != null)
        {
            // Sağlık barının doluluk oranını güncelle
            ammoBar.fillAmount = (float)currentAmmo / (float)maxAmmo;
        }
    }
    void wait()
    {
        stopfire = false;
        currentAmmo = 20 ;
        UpdateAmmoBar();
    }

    IEnumerator destroybullet(GameObject bulletref)
    {
        yield return new WaitForSeconds(2);
        Destroy(bulletref);
    }
}
