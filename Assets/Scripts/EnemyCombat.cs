using UnityEngine;

// Nguyễn Như Cường - 20200076
public class EnemyCombat : MonoBehaviour
{
    [SerializeField] private Transform eAttackPoint;
    [SerializeField] private LayerMask playerLayers;

    [SerializeField] public float attackRange = 1.8f;
    [SerializeField] public int attackDamage = 30;

    public void Attack()
    {
        // Detect player in range of attack
        Collider2D[] hitplayer = Physics2D.OverlapCircleAll(eAttackPoint.position, attackRange, playerLayers);

        foreach (Collider2D enemy in hitplayer)
        {
            enemy.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (eAttackPoint == null)
        {
            return;
        }
        // Display the explosion radius when selected
        Gizmos.DrawWireSphere(eAttackPoint.position, attackRange);
    }
}
