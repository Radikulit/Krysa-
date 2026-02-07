using UnityEngine;
using UnityEngine.EventSystems;

public class RightClickButton : MonoBehaviour, IPointerClickHandler
{
    public int diceIndex;
    public ThrowDices diceManager;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            diceManager.Reroll(diceIndex);
        }
    }
}
