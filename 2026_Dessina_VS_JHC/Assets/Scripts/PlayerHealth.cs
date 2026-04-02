using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHP = 10;
    public int currentHp;

    public bool isDead = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHp = maxHP;
    }

    public void TakeDamage(int damage)
    {
        if(isDead) return;

        currentHp -= damage;

        if(currentHp <= 0)
        {
            currentHp = 0;
            Die();
        }    
            Debug.Log("Player HP: " + currentHp);
    }

    private void Die()
    {
        isDead = true;
        Debug.Log("Game Over");
    }
}
