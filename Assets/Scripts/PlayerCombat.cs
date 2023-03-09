using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

// Nguyễn Như Cường - 20200076
public class PlayerCombat : PlayerAnimation
{
    // Các biến để quản lý tấn công của người chơi
    [SerializeField] private Transform attackPoint; // Vị trí tấn công
    [SerializeField] private LayerMask enemyLayers;// Lớp chứa đối thủ

    [SerializeField] private float attackRange = 0.5f; // Phạm vi tấn công
    [SerializeField] private int attackDamage1 = 5; // Sát thương tấn công 1
    [SerializeField] private int attackDamage2 = 10; // Sát thương tấn công 2

    [SerializeField] float attackRate1 = 0.6f; // Thời gian chờ hồi 1
    [SerializeField] float attackRate2 = 2f; // Thời gian chờ hồi 2
    private float nextAttack1Time = 0f, nextAttack2Time = 0f;

    protected override void Update()
    {
        base.Update();

        // Kiểm tra xem đã có thể sử dụng chém bằng A chưa
        if (Time.time >= nextAttack1Time)
        {
            // Nếu nhấn phím A thì gọi hàm attack1()
            if (Input.GetKeyDown("a"))
            {
                Attack1();
                nextAttack1Time = Time.time + attackRate1;
            }
        }

        // Kiểm tra xem đã có thể sử dụng chém bằng S chưa
        if (Time.time >= nextAttack2Time)
        {
            // Nếu nhấn phím S thì gọi hàm attack2()
            if (Input.GetKeyDown("s"))
            {
                Attack2();
                nextAttack2Time = Time.time + attackRate2;
            }
        }
    }

    // Phát hiện và tấn công đối thủ trong phạm vi tấn công
    public void Attack1()
    {
        anim.SetTrigger("Attack1");// Chạy animation "Attack1"

        // Lấy danh sách tất cả đối thủ trong phạm vi tấn công
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Tấn công tất cả đối thủ trong danh sách
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage1);
        }
    }

    public void Attack2()
    {
        anim.SetTrigger("Attack2"); 

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage2);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        // Hiển thị bán kính vùng được chọn
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
