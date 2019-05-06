using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public int healthValue = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        RubyController controller = collision.GetComponent<RubyController>();
        if (controller != null)
        {
            if (controller.health < controller.startHealth)
            {
                controller.ChangeHealth(healthValue);
                Destroy(gameObject);
            }
        }
    }
}
