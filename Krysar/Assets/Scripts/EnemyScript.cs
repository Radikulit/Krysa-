using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public TextMeshProUGUI HPCount;
    public TextMeshProUGUI DecreaseHPText;
    private float enemyHp = 0;
    void Start()
    {
        enemyHp = UnityEngine.Random.Range(10, 16);
        UpdateHPText();   
    }
    public void TakeDamage(float damage)
    {
        if (damage < 0)//osetreni pro decreased text
        {
            damage = 0;
            DecreaseHPText.gameObject.SetActive(false);

        }
        else
        {
            DecreaseHPText.text = damage.ToString("- 0.0");
            DecreaseHPText.gameObject.SetActive(true);
            Invoke(nameof(HideDamageText), 1f);
        }

        enemyHp -= damage;
        if (enemyHp < 0)//osetreni 
        {
            enemyHp = 0;
        }

        UpdateHPText();

    }
    private void UpdateHPText()
    {
        HPCount.text = enemyHp.ToString(": 0.0");
    }
    private void HideDamageText()
    {
        DecreaseHPText.gameObject.SetActive(false);
    }
}
