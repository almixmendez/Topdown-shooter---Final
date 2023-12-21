using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/HealthBuff")]
public class HealthBuff : PowerupEffect
{
    public float amount;
    public override void Apply(GameObject target)
    {
        PlayerHealth playerHealth = target.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            GameObject healthBarObject = GameObject.FindWithTag("HealthBar");
            HealthBar healthBar = healthBarObject.GetComponent<HealthBar>();

            playerHealth.IncreaseHealth(amount);

            if (healthBar != null)
            {
                healthBar.IncreaseHealth(amount);
            }
        }
    }
}
