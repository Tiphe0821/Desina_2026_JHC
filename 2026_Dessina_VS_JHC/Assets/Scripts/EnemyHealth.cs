using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHp = 3;           // 적 최대체력 선언
    public int currentHp;           // 적 현재 체력 선언

    public GameObject xpPrefab;     // 죽을 때 떨어트릴 경험치 프리펩
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHp = maxHp;
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        Debug.Log("몬스터 피격");

        if(currentHp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if(xpPrefab != null)
        {
            Instantiate(xpPrefab, transform.position, Quaternion.identity);

        }

        Destroy(gameObject);
    }
}
