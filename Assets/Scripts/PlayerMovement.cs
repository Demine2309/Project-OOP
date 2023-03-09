using System.Collections;
using UnityEngine;

// Nguyễn Như Cường - 20200076
public class PlayerMovement : MonoBehaviour
{
    // Khai báo các biến
    protected Rigidbody2D rb;
    private Vector3 moveDelta;
    protected Collider2D coll;

    protected float x; // giá trị di chuyển ngang của nhân vật
    [SerializeField] private float moveSpeed = 7f; // tốc độ di chuyển
    [SerializeField] private float jumpForce = 14f; // lực nhảy của nhân vật

    private bool canJump = true; // biến xác định có thể nhảy hay không
    private bool canDoubleJump = true; // biến xác định có thể double jump hay không

    // Phương thức được gọi ngay khi bắt đầu game
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }

    // Phương thức được gọi mỗi khung hình
    protected virtual void Update()
    {
        // Nhận giá trị trục ngang của bàn phím
        x = Input.GetAxisRaw("Horizontal");

        // Thiết lập vận tốc của nhân vật
        rb.velocity = new Vector2(x * moveSpeed, rb.velocity.y);

        moveDelta = new Vector3(x, 0, 0);
        SwapDirection();

        // Cho phép nhân vật nhảy nếu đang đứng trên mặt đất hoặc có thể nhảy kép
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (canJump || canDoubleJump)
            {
                if (!canJump && canDoubleJump)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                    canDoubleJump = false;
                    
                    // Đặt thời gian trễ cho việc nhảy lần thứ hai
                    StartCoroutine(DelayTimeDoubleJump(3.7f));
                }
                else
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                    canJump = false;
                }
            }
        }
    }

    // Phương thức để đổi hướng nhân vật
    private void SwapDirection()
    {
        if (moveDelta.x > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if (moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    // Phương thức được gọi khi nhân vật va chạm với các đối tượng trong môi trường
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;

            if (canDoubleJump)
            {
                // Đặt thời gian trễ cho việc nhảy lần thứ hai
                StartCoroutine(DelayTimeDoubleJump(3.7f));
            }
        }

        if (collision.gameObject.CompareTag("Enemies"))
        {
            canJump = true;
        }
    }

    // Hàm đặt thời gian trễ cho việc nhảy lần thứ hai
    private IEnumerator DelayTimeDoubleJump(float doubleJumpDelay)
    {
        yield return new WaitForSeconds(doubleJumpDelay);
        canDoubleJump = true;
    }
}
