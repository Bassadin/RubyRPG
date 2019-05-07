using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3.0f;
    public bool vertical;
    public float movementChangeTime = 3.0f;
    public int damageAmount = -1;

    Rigidbody2D rigidbody2D;
    float movementTimer;
    int movementDirection = 1;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        movementTimer = movementChangeTime;
    }

    void Update()
    {
        movementTimer -= Time.deltaTime;

        if (movementTimer < 0)
        {
            movementDirection = -movementDirection;
            movementTimer = movementChangeTime;
        }

        Vector2 position = rigidbody2D.position;

        if (vertical)
        {
            position.y += Time.deltaTime * speed * movementDirection;
        }
        else
        {
            position.x += Time.deltaTime * speed * movementDirection;
        }

        rigidbody2D.MovePosition(position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        RubyController player = collision.gameObject.GetComponent<RubyController>();
        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }
}
