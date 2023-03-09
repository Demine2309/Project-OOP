using UnityEngine;
using UnityEngine.SceneManagement;

// Nguyễn Như Cường - 20200076
public class EnemyHealth : MonoBehaviour
{
    private Animator anim;
    private Collider2D coll;
    private Rigidbody2D rb;

    private int maxHealth = 100;
    private int currentHealth;

    public HealthBar healthBar2;

    [SerializeField] private float increasedSpeed = 1f;
    [SerializeField] private int increasedDamage = 10;

    private bool isLowHealth = false;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar2.SetMaxHealth(maxHealth);

        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        anim.SetTrigger("Hurt");

        if (currentHealth <= 50 && !isLowHealth)
        {
            currentHealth += 30;
            transform.localScale = new Vector3(2.3f, 2.3f, 2.3f);

            isLowHealth = true;
            IncreaseSizeAndSpeed();
        }

        if (currentHealth <= 0)
        {
            EnemyDie();
        }

        healthBar2.SetHealth(currentHealth);
    }

    private void IncreaseSizeAndSpeed()
    {
        // Increase the speed of the enemy
        EnemyLogical enemyLogical = anim.GetBehaviour<EnemyLogical>();
        enemyLogical.speed += increasedSpeed;

        // Increase the damage of the enemy
        EnemyCombat enemyCombat = anim.GetComponent<EnemyCombat>();
        enemyCombat.attackDamage += increasedDamage;
    }

    private void EnemyDie()
    {
        Debug.Log("Enemy Die!");

        anim.SetBool("IsDead", true);

        rb.constraints = RigidbodyConstraints2D.FreezePositionY;

        coll.enabled = false;
        this.enabled = false;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
}
