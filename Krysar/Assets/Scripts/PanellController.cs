using UnityEngine;

public class PanelController : MonoBehaviour
{
    public Animator ItemPanelAnimator;
    public void ShowItemPanel()
    {
        ItemPanelAnimator.SetTrigger("ShowItemPanel");
    }
    public void HideItemPanel() 
    {
        ItemPanelAnimator.SetTrigger("HideItemPanel");
    }
}
