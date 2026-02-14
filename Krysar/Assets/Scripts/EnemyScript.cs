using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public Animator RatAnimator;

    public TextMeshProUGUI HPCount;
    public TextMeshProUGUI DecreaseHPText;
    public TextMeshProUGUI[] EnemyResults;

    private float enemyHp = 0;
    private int[] EnemydiceValues = new int[6];
    private bool[] EnemylockedDices = new bool[6];
    void Start()
    {
        enemyHp = UnityEngine.Random.Range(10, 16);
        UpdateHPText();
    }
    public void TakeDamage(float damage)
    {
        if (damage <= 0)//osetreni pro decreased text, at se text nezobrazuje, pod neni potreba
        {
            damage = 0;
            DecreaseHPText.gameObject.SetActive(false);
        }
        else
        {
            DecreaseHPText.text = damage.ToString("- 0.0");
            DecreaseHPText.gameObject.SetActive(true);
            Invoke(nameof(HideDamageText), 1f);
            RatAnimator.SetTrigger("DamageTaken");
        }

        enemyHp -= damage;
        if (enemyHp <= 0)//osetreni 
        {
            RatAnimator.SetTrigger("Death");
            enemyHp = 0;
        }
        damage = 0;
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

    //Tady je logika pro tah soupere
    public void EnemyRoll()
    {
        Debug.Log("Tady hraje souper");
    }

}
