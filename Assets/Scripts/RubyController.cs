using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    //Movement and collision
    public float moveSpeed = 3.0f;
    Rigidbody2D rigidbody2D;

    //Health
    public int startHealth = 5;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        currentHealth = startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 position = rigidbody2D.position;

        position.x += moveSpeed * horizontal * Time.deltaTime;
        position.y += moveSpeed * vertical * Time.deltaTime;

        rigidbody2D.MovePosition(position);
    }

    void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, startHealth);
        Debug.Log(currentHealth + " / " + startHealth);
    }
}
