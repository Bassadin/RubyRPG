using UnityEngine;

public class DamageZone : MonoBehaviour
{
    public int healthChangeAmount = -1;

    private void OnTriggerStay2D(Collider2D collision)
    {

        RubyController controller = collision.GetComponent<RubyController>();

        if (controller != null)
        {
            controller.ChangeHealth(healthChangeAmount);
        }
    }
}
