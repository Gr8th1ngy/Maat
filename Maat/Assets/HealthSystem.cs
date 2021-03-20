using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float maxHealth;
    public bool isDead;
    public float timeBeforeDestroy;

    public GameObject healthbarPrefab;
    public GameObject deathEffectPrefab;

    HealthBarBehaviour myHealthBar;
    float currentHealth;
    float timeUntilDestroy;

    // Start is called before the first frame update
    void Start()
    {
        GameObject healthBarObject = Instantiate(healthbarPrefab, References.canvas.transform);
        myHealthBar = healthBarObject.GetComponent<HealthBarBehaviour>();
        currentHealth = maxHealth;
        
        isDead = false;
        timeUntilDestroy = timeBeforeDestroy;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            if (timeUntilDestroy <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                timeUntilDestroy -= Time.deltaTime;
            }
        }
        else
        {
            // Make health bar reflect health
            myHealthBar.ShowHealth(currentHealth / maxHealth);

            // Health bar move to current position
            myHealthBar.transform.position = Camera.main.WorldToScreenPoint(transform.position + Vector3.up * 1 + Vector3.forward * -1);
        }
    }

    private void OnDestroy()
    {
        if (myHealthBar)
        {
            Destroy(myHealthBar.gameObject);
        }
    }

    public bool TakeDamage(float damage)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                if (deathEffectPrefab != null)
                {
                    Instantiate(deathEffectPrefab, transform.position, transform.rotation);
                }

                MarkAsDead();
                return true;
            }
        }

        return false;
    }

    public void KillMe()
    {
        TakeDamage(currentHealth);
    }

    void MarkAsDead()
    {
        isDead = true;
        gameObject.SetActive(false);
        OnDestroy();
    }
}
