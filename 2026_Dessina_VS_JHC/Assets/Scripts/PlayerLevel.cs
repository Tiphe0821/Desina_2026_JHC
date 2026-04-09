using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    public int level = 1;
    public int currentxp = 0;
    public int xpToNextLevel = 5;

    public AutoShooter autoShooter;

    public void AddXp(int amount)
    {
        currentxp += amount;

        Debug.Log("XP : " + currentxp + " / " + xpToNextLevel);

        if(currentxp >= xpToNextLevel )
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        level++;
        currentxp = 0;

        Debug.Log("Level UP! Current Level : " + level);

        if(autoShooter != null)
        {
            autoShooter.tAttackInterval = Mathf.Max(0.2f, autoShooter.tAttackInterval - 0.1f);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
