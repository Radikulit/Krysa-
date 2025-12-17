using UnityEngine;
using TMPro;

public class ThrowDices : MonoBehaviour
{
    public int minValue = 1;
    public int maxValue = 7;
    public TextMeshProUGUI[] diceTexts;

    private int[] diceValues = new int[6];

    public void Roll()
    { 
        for(int i = 0; i < 6; i++)
        {
            diceValues[i] = Random.Range(minValue, maxValue);
            diceTexts[i].text = diceValues[i].ToString();
        }
    }
}
