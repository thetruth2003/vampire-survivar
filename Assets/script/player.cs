using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    [SerializeField] Transform swordtransform;
    [SerializeField] Transform orbiter;
    [SerializeField] float movespeed;
    [SerializeField] float orbitradius;
    [SerializeField] float orbiterspeed;
    [SerializeField] int xp;
    float xAxis = 0;
    float yAxis = 0;

    public int maxHealth = 100;  // Maksimum sağlık
    public int currentHealth;    // Şu anki sağlık
    public int level = 1;
    public int expToLevelUp = 10;
    public GameObject levelUpPanel; // Inspector'dan atayın
    public GameObject pausePanel; // Inspector'dan atayın
    public Button powerUpButton1; // Inspector'dan atayın
    public Button powerUpButton2; // Inspector'dan atayın
    public Image healthBar;      // UI Sağlık Barı
    public Image death;      // UI Sağlık Barı
    public Text expText; // Inspector'dan atayın

    void Start()
    {
        currentHealth = maxHealth;  // Oyunun başında maksimum sağlıkla başlar
        UpdateHealthBar();
        UpdateExpText(); // Başlangıçta güncelle
            // Butonlara fonksiyon bağla
    if (powerUpButton1 != null)
        powerUpButton1.onClick.AddListener(PowerUp1);
    if (powerUpButton2 != null)
        powerUpButton2.onClick.AddListener(PowerUp2);
    }

    // Update is called once per frame
        void Update()
    {
        xAxis = Input.GetAxis("Horizontal");
        yAxis = Input.GetAxis("Vertical");

        Vector3 Velocity = Vector2.ClampMagnitude(new Vector2(xAxis, yAxis), 1);
        transform.position += Velocity * movespeed * Time.deltaTime;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        Vector2 sworddirection = mousePos - transform.position;

        swordtransform.up = sworddirection.normalized;
        orbitermovemnt();

        // ESC ile oyunu durdur/başlat
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausePanel != null)
            {
                bool isActive = pausePanel.activeSelf;
                pausePanel.SetActive(!isActive);
                Time.timeScale = isActive ? 1f : 0f;
            }
        }
    }
    void orbitermovemnt()
    {
        Vector3 orbitpos = new Vector3(Mathf.Cos(Time.time * orbiterspeed), Mathf.Sin(Time.time * orbiterspeed), 0) * orbitradius;

        orbiter.position = transform.position + orbitpos;

    }
    public void takedamage(int somedamage)
    {
        currentHealth -= somedamage;

        Debug.Log(currentHealth);

        if (currentHealth <= 0)
            deadth();
    }
    void deadth()
    {
        Debug.Log("player died");
        death.gameObject.SetActive(true);
        Time.timeScale = 0f;
        gameObject.SetActive(false);
    }

    public void heal(int someheal)
    {
        currentHealth += someheal;
        Debug.Log(currentHealth);
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        // Sağlık barını güncelle (oran: currentHealth / maxHealth)
        healthBar.fillAmount = (float)currentHealth / (float)maxHealth;
    }
    public void takeexp(int someexp)
    {
        xp += someexp;
        UpdateExpText(); // Her exp aldığında güncelle
        if (xp >= expToLevelUp)
        {
            LevelUp();
        }
    }
    void LevelUp()
    {
        xp = 0;
        level++;
        UpdateExpText(); // Level up olduğunda güncelle
        Time.timeScale = 0f;
        levelUpPanel.SetActive(true);
    }
    void PowerUp1()
    {
        movespeed += 2f; // Örnek güçlendirme
        CloseLevelUpPanel();
    }
    
    void UpdateExpText()
    {
        if (expText != null)
            expText.text = "Level: " + level + "   " + xp + "/" + expToLevelUp;
    }
    void PowerUp2()
    {
        maxHealth += 20; // Örnek güçlendirme
        currentHealth = maxHealth;
        UpdateHealthBar();
        CloseLevelUpPanel();
    }

    void CloseLevelUpPanel()
    {
        levelUpPanel.SetActive(false);
        Time.timeScale = 1f; // Oyunu devam ettir
    }
}

