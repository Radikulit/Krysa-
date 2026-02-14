using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class VisorScript : MonoBehaviour
{
    public Button VisorButton;
    public Button DeactivateVisorButton;

    public GameObject OrganHolder;
    public GameObject visorCursor;
    public GameObject VisorPanel;
    void Update()
    {
        if (!visorCursor.activeSelf) return;

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Mathf.Abs(Camera.main.transform.position.z);

        visorCursor.transform.position =
            Camera.main.ScreenToWorldPoint(mousePos);
    }

    public void ActivateVisor()
    {
        OrganHolder.SetActive(true);
        visorCursor.SetActive(true);
        VisorPanel.SetActive(true);
        Cursor.visible = false;
    }

    public void DeactivateVisor()
    {
        OrganHolder.SetActive(false);
        visorCursor.SetActive(false);
        VisorPanel.SetActive(false);
        Cursor.visible = true;
    }
}
