using UnityEngine;

// Nguyễn Như Cường - 20200076
public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform player;

    private bool isFlip = false;

    private Vector3 eMoveDelta;

    public void FollowPlayer()
    {
        eMoveDelta = transform.localScale;
        eMoveDelta.z *= -1f;

        if (transform.position.x > player.position.x && isFlip)
        {
            transform.localScale = eMoveDelta;
            transform.Rotate(0f, 180f, 0f);
            isFlip = false;
        }
        else if(transform.position.x < player.position.x && !isFlip)
        {
            transform.localScale = eMoveDelta;
            transform.Rotate(0f, 180f, 0f);
            isFlip = true;
        }
    }
}
