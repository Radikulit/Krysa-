using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public TextMeshProUGUI HPCount;
    private float enemyHp = 0;
    void Start()
    {
        enemyHp = UnityEngine.Random.Range(10, 16);
        UpdateHPText();
    }
    public void TakeDamage(float damage)
    {
        enemyHp -= damage;
        if (enemyHp < 0)//osetreni 
        {
            enemyHp = 0;
        }

        UpdateHPText();

    }
    private void UpdateHPText()
    {
        HPCount.text = enemyHp.ToString(":0.0");
    }
}
