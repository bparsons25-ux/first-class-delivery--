using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UI;

public class healthController : MonoBehaviour
{
    public float maxhealth = 100;
    public float currentHealth;

    public PlayerMovement pm;
    [SerializeField] private Image healthbarFill;

    [SerializeField] private PlayerMovement PlayerMovement;
    [SerializeField] public float damageAmount, healthAmount;

   public bool allowDamage = true;

    public float cooldown = 1f;

    Renderer ren;



    private void Awake()
    {
        currentHealth = maxhealth;

    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxhealth);
        if (currentHealth == 0)
        {
            PlayerMovement.Die();

        }
        UpdateHealthBar();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            if (allowDamage == true)
            {
                TakeDamage(damageAmount);
                ren = GetComponent<SpriteRenderer>();
                ren.material.color = Color.red;
                StartCoroutine(damageCooldown());
            }
            

        }

        if (collision.CompareTag("Health"))
        {
            Heal(healthAmount);
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Ground"))   
        {
            TakeDamage(damageAmount);
            ren = GetComponent<SpriteRenderer>();
            ren.material.color = Color.red;
            StartCoroutine(damageCooldown());
        }

        if (collision.CompareTag("shield"))
        {
            PlayerMovement.shield();
        }

    }

    private void Heal(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxhealth);
        UpdateHealthBar();
    }







    private void UpdateHealthBar()
    {
        healthbarFill.fillAmount = currentHealth / maxhealth;
        
    }

    IEnumerator damageCooldown()
    {
        allowDamage = false;
        
        yield return new WaitForSeconds(cooldown);
        ren.material.color = Color.white;
        allowDamage = true;
    }





}
