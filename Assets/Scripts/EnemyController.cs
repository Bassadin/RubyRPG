using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public bool vertical;
    public float movementChangeTime = 3.0f;

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
}
