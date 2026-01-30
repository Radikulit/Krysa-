using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ThrowDices : MonoBehaviour
{
    public static ThrowDices Instance;
    void Awake()
    {
        Instance = this;
    }//Singleton

    public TextMeshProUGUI[] diceTexts;
    
    public Button[] diceButtons;
    public Button EndTurnButton;
    public Button RollButton;

    public Image LockDiceImage;
    public Image EnemyTurnImage;

    private int[] diceValues = new int[6];
    private bool[] lockedDices = new bool[6];
    private bool canRoll = true;
    private bool turnActive = false;//zajisti ze po ukonceni tahu kostky odkladat nelze

    public void Roll()//hod kostkamy
    {
        if (!canRoll)
        {
            LockDiceImage.gameObject.SetActive(true);
            CancelInvoke();
            Invoke(nameof(HideWarning), 1.5f);
            return;
        }

        canRoll = false;
        turnActive = true;
        EndTurnButton.interactable = true;
        bool canLockAnyDice = false;
        for (int i = 0; i < 6; i++)
        {
            if (lockedDices[i]) continue;

            diceValues[i] = UnityEngine.Random.Range(1, 7);
            diceTexts[i].text = diceValues[i].ToString();
            
            if (diceValues[i] == 1 || diceValues[i] == 5)
            {
                canLockAnyDice = true;
            }
        }
        if (!canLockAnyDice)
        {
            System.Array.Clear(lockedDices, 0, lockedDices.Length);
            EndTurn(0);
        }
    }
    public void LockNumber(int i)//odloz kostku
    {
        if (!turnActive)
        {
            return;
        }

        if (diceValues[i] != 1 && diceValues[i] != 5)
        {
            return;
        }

        lockedDices[i] = true;
        diceButtons[i].image.color = new Color(1, 1, 1, 0.5f);//at bude pruhledna
        canRoll = true;
    }
    public void EndTurn(float damage = 0)
    {

        for (int i = 0; i < lockedDices.Length; i++)
            if (lockedDices[i])
            {
                damage += diceValues[i] == 1 ? 1f : 0.5f;
                if (damage <= 0)
                {
                    return;
                }
            }
        GetComponent<EnemyScript>().TakeDamage(damage);

        System.Array.Clear(lockedDices, 0, lockedDices.Length);
        canRoll = false;
        turnActive = false;
        EndTurnButton.interactable = false;

        EnemyTurnImage.gameObject.SetActive(true);
        CancelInvoke();
        Invoke(nameof(HideWarning), 3f);
    }
    void HideWarning()
    {
        LockDiceImage.gameObject.SetActive(false);
        EnemyTurnImage.gameObject.SetActive(false);
    }
}
