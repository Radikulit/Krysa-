using TMPro;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float HPcount = 20;
    public int AnatomyScore = 5;
    public TextMeshProUGUI HealthText;
    public TextMeshProUGUI AnatomyText;
    void Start()
    {
        UpdatePlayerStats();
    }
    public void UpdatePlayerStats()
    {
        HealthText.text = HPcount.ToString("0.0");
        AnatomyText.text = AnatomyScore.ToString("0");
    }
}
