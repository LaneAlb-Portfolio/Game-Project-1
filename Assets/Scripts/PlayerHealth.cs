using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerHealth : MonoBehaviour
{
    public Slider healthbar;
    public Image deadScreen;
    public Image damageImage;
    public ParticleSystem healthRestore;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    public Text healthCount;
    public AudioClip healClip;
    public AudioSource hurtClip;
    

    public float Health = 100f;
    private bool isDead;
    public float _currentHealth;
    private bool damaged;
    public float flashSpeed = 5f;
    public int counter = 3;
    public float damageCounter;

    private float damageTick = 1.0f;
    private float damageCooldown;

    //private IEnumerator coroutine;

    private void Start()
    {
        _currentHealth = Health;
        isDead = false;
        UpdateGUI();
        healthRestore.Stop();
    }

    void Update()
    {
        healthbar.value = _currentHealth;
        counter = Mathf.Clamp(counter, 0, 10);
        Health = Mathf.Clamp(Health, 0, 100);
        damageCounter = Mathf.Clamp(damageCounter, 0, 100);

        if (Input.GetKeyDown(KeyCode.F))
        {
            RestoreHealth(damageCounter);
            damageCounter = 0;
        }

        if (damaged)
        {
            hurtClip.Play();
            // ... set the colour of the damageImage to the flash colour.
            damageImage.color = flashColour;

            //Debug.Log("flash");
        }
        // Otherwise...
        else
        {
            // ... transition the colour back to clear.
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        // Reset the damaged flag.
        damaged = false;

        healthCount.text = counter.ToString();
        //SetCountText();


    }

    void UpdateGUI()
    {
        deadScreen.gameObject.SetActive(isDead);
    }

    void CheckDead()
    {
        if (isDead)
        {
            return;
        }
        if (_currentHealth <= 0)
        {
            Debug.Log("Dead!");
            isDead = true;
            GetComponent<FirstPersonController>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            hurtClip.mute = true;
            
        }
    }

    public void TakeDamage(float damage)
    {
        //_currentHealth -= damage;
        //healthbar.value = _currentHealth;
        //damaged = true;
        if (damageCooldown <= 0.0f)
        {
            damageCooldown = damageTick;
            _currentHealth -= damage;
            healthbar.value = _currentHealth;
            damaged = true;
            damageCounter += damage;

        }
        else
        {
            damageCooldown -= Time.deltaTime;
        }

        CheckDead();
        UpdateGUI();
    }

    public void RestoreHealth(float health)
    {
        if (_currentHealth < 100 && counter > 0)
        {
            AudioSource.PlayClipAtPoint(healClip, transform.position);
            counter--;
            _currentHealth += health;
            healthRestore.Play();
        }
        CheckDead();
        UpdateGUI();
    }
}

