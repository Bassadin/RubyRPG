using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3.0f;
    public bool vertical;
    public float movementChangeTime = 3.0f;
    public int damageAmount = -1;

    Rigidbody2D rigidbody2D;
    Animator animator;
    float movementTimer;
    int movementDirection = 1;
    bool broken = true;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        movementTimer = movementChangeTime;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!broken)
        {
            return;
        }

        ChangeMovementDirection();
        MoveCharacter();
    }

    private void ChangeMovementDirection()
    {
        movementTimer -= Time.deltaTime;

        if (movementTimer < 0)
        {
            movementDirection = -movementDirection;
            movementTimer = movementChangeTime;
        }
    }

    private void MoveCharacter()
    {
        Vector2 position = rigidbody2D.position;

        if (vertical)
        {
            position.y += Time.deltaTime * speed * movementDirection;
            SetMovementIntoAnimator(new Vector2(0, movementDirection));
        }
        else
        {
            position.x += Time.deltaTime * speed * movementDirection;
            SetMovementIntoAnimator(new Vector2(movementDirection, 0));
        }

        rigidbody2D.MovePosition(position);
    }

    void SetMovementIntoAnimator(Vector2 movementVector)
    {
        animator.SetFloat("moveX", movementVector.x);
        animator.SetFloat("moveY", movementVector.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        RubyController player = collision.gameObject.GetComponent<RubyController>();
        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }

    public void Fix()
    {
        broken = false;
        rigidbody2D.simulated = false;
    }
}
