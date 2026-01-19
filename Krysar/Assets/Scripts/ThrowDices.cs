using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ThrowDices : MonoBehaviour
{
    public TextMeshProUGUI[] diceTexts;
    public Button[] diceButtons;

    int[] diceValues = new int[6];
    bool[] lockedDices = new bool[6];
    bool canRoll = true;

    public void Roll()
    {
        if (!canRoll)
        {
            Debug.Log("Zamkni kostku");
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
    public void LockNumber(int i)
    {
        if (diceValues[i] != 1 && diceValues[i] != 5)
        {
            return;
        }

        lockedDices[i] = true;
        diceButtons[i].image.color = new Color(1, 1, 1, 0.5f);
        canRoll = true;
    }
}
