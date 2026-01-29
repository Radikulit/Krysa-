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
    public Button[] endturnButton;
    public Image LockDiceImage;

    int[] diceValues = new int[6];
    bool[] lockedDices = new bool[6];
    bool canRoll = true;

    public void Roll()//hod kostkamy
    {
        if (!canRoll)
        {
            LockDiceImage.gameObject.SetActive(true);
            Invoke(nameof(HideWarning), 1.5f);
            return;
        }

        canRoll = false;

        for (int i = 0; i < 6; i++)
        {
            if (lockedDices[i]) continue;

            diceValues[i] = UnityEngine.Random.Range(1, 7);
            diceTexts[i].text = diceValues[i].ToString();
        }
    }
    public void LockNumber(int i)//odloz kostku
    {
        if (diceValues[i] != 1 && diceValues[i] != 5)
        {
            return;
        }

        lockedDices[i] = true;
        diceButtons[i].image.color = new Color(1, 1, 1, 0.5f);//at bude pruhledna
        canRoll = true;
    }
    public void EndTurn()
    {
        Debug.Log("XAXAXAXAXAXAXAXAXAXAXAXAXA");
    }
    void HideWarning()
    {
        LockDiceImage.gameObject.SetActive(false);
    }
}
