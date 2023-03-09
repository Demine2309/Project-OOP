using UnityEngine;

// Nguyễn Như Cường - 20200076
public class PlayerAnimation : PlayerMovement
{
    protected Animator anim;

    // Enum để lưu trạng thái animation của người chơi
    protected enum MovementState
    {
        idle,
        run,
        jump,
        fall
    }

    protected override void Start()
    {
        base.Start();

        anim = GetComponent<Animator>(); // Lấy Animator của đối tượng
    }

    protected override void Update()
    {
        base.Update();

        UpadateAnimationState();
    }

    // Phương thức để cập nhật trạng thái animations
    private void UpadateAnimationState()
    {
        MovementState state;
        if (x > 0)
        {
            state = MovementState.run;
        }
        else if (x < 0)
        {
            state = MovementState.run;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > 0.1f)
        {
            state = MovementState.jump;
        }
        else if (rb.velocity.y < -0.1f)
        {
            state = MovementState.fall;
        }

        anim.SetInteger("state", (int)state);
    }
}
