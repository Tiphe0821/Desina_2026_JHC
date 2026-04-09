using UnityEngine;

public class AutoShooter : MonoBehaviour
{
    public GameObject projectilePrefab;     // 투사체의 프리펩
    public float tAttackInterval = 1.0f;    // 몇초마다 공격할지
    public float attackRange = 10.0f;       // 공격 범위
    public Transform FirePoint;

    private float attackTimer = 0.0f;
    private PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }



    void Update()
    {
        if (playerHealth != null && playerHealth.isDead) return;

        attackTimer += Time.deltaTime;

        if(attackTimer >= tAttackInterval)
        {
            Transform target = FindNearestEnemy();

            if(target != null)
            {
                
                Shoot(target);
                attackTimer = 0.0f;
            }

        }    
        
    }

    Transform FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        Transform nearest = null;
        float nearestDisTance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            if (distance < nearestDisTance && distance <= attackRange)
            {
                nearestDisTance = distance;
                nearest = enemy.transform;
            }
        }


        return nearest;
    }

    void Shoot(Transform target)
    {
        Vector3 direction = (target.position - FirePoint.position).normalized;

        GameObject projectile = Instantiate(
            projectilePrefab,
            FirePoint.position,
            Quaternion.LookRotation(direction)
            );
        Projectile projectileScript = projectile.GetComponent<Projectile>();

        if(projectileScript != null)
        {
            projectileScript.SetDirection(direction);
        }
    }
}
