using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;  // Eğer TextMeshPro kullanıyorsanız

public class Megagun : MonoBehaviour
{
    [SerializeField] GameObject megaBulletPrefab;
    [SerializeField] float megaBulletSpeed;
    [SerializeField] int cooldown;
    [SerializeField] bool stopfire;
    public int maxAmmo = 20;  
    public int currentAmmo; 
    [SerializeField] public TMP_Text ammoText;  // UI Text bileşeni
    // Eğer TextMeshPro kullanıyorsanız:
    // [SerializeField] public TMP_Text ammoText;

    void Start()
    {
        currentAmmo = maxAmmo;  
        UpdateAmmoText();  // İsimlendirmeyi düzelttik
    }

    void Update()
    {
        if (currentAmmo <= 0 && !stopfire)
        {
            StartCoroutine(WaitBeforeRecharging());  // Coroutine kullanımı
            stopfire = true;
        }

        if (Input.GetMouseButtonDown(1) && currentAmmo > 0 && !stopfire)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 megaBulletDirection = mousePos - (Vector2)transform.position;
            megaBulletDirection.Normalize();

            GameObject megaBullet = Instantiate(megaBulletPrefab, transform.position, Quaternion.identity);
            megaBullet.transform.up = megaBulletDirection;
            megaBullet.GetComponent<Rigidbody2D>().velocity = megaBulletDirection * megaBulletSpeed;
            
            currentAmmo -= 1;
            UpdateAmmoText();
            StartCoroutine(DestroyMegaBullet(megaBullet));
        }
    }

    IEnumerator WaitBeforeRecharging()
    {
        yield return new WaitForSeconds(6f);  // Bekleme süresi
        currentAmmo = maxAmmo;  // Mermileri yeniden doldur
        UpdateAmmoText();
        stopfire = false;
    }

    void UpdateAmmoText()
    {
        if (ammoText != null)
        {
            ammoText.text = "Ammo: " + currentAmmo.ToString() + "/" + maxAmmo.ToString();
        }
    }

    IEnumerator DestroyMegaBullet(GameObject megaBulletRef)
    {
        yield return new WaitForSeconds(2f);
        Destroy(megaBulletRef);
    }
}
