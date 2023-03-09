using UnityEngine;

// Nguyễn Như Cường - 20200076
public class EnemyLogical : StateMachineBehaviour
{
    [SerializeField] public float speed = 2.5f;
    private float distance = 3f;

    private Transform player;
    private Rigidbody2D rb;
    private Enemy enemy;
    private bool isPlayerDead = false;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponentInParent<Rigidbody2D>();
        enemy = animator.GetComponentInParent<Enemy>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy.FollowPlayer();

        if (!isPlayerDead)
        {
            Vector2 target = new Vector2(player.position.x, rb.position.y);
            rb.transform.position = Vector2.MoveTowards(rb.position, target, speed * Time.deltaTime);
        }

        if (player.GetComponent<PlayerHealth>().isDead)
        {
            isPlayerDead = true; 
            animator.SetBool("IsPlayerDead", true);
        }


        if (!isPlayerDead && Vector2.Distance(player.position, rb.position) <= distance)
        {
            animator.SetTrigger("EnemyAttack");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("EnemyAttack");
    }
}
