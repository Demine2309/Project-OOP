using UnityEngine;
using UnityEngine.SceneManagement;

// Nguyễn Như Cường - 20200076
public class PlayerHealth : PlayerCombat
{
    private int maxHealth = 100;
    private int currentHealth;

    public HealthBar healthBar1;

    private PlayerMovement playerMovement;
    private PlayerCombat playerCombat;
    public bool isDead = false;

    protected override void Start()
    {
        base.Start();

        currentHealth = maxHealth;
        healthBar1.SetMaxHealth(maxHealth);

        playerMovement = GetComponent<PlayerMovement>();
        playerCombat = GetComponent<PlayerCombat>();
    }

    protected override void Update()
    {
        base.Update();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        anim.SetTrigger("PlayerHurt");

        if (currentHealth <= 0)
        {
            Die();
            isDead = true;
        }

        healthBar1.SetHealth(currentHealth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Blood"))
        {
            currentHealth = Mathf.Min(currentHealth + 15, maxHealth);
            healthBar1.SetHealth(currentHealth);
            Destroy(collision.gameObject);
        }
    }

    private void Die()
    {
        Debug.Log("Player Die!");

        anim.SetBool("PlayerDead", true);

        playerMovement.enabled = false;
        playerCombat.enabled = false;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
