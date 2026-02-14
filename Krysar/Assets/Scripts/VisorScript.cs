using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class VisorScript : MonoBehaviour
{
    public Button VisorButton;
    public Button DeactivateVisorButton;

    public GameObject[] organs;

    public GameObject OrganHolder;
    public GameObject visorCursor;
    public GameObject VisorPanel;

    private int[] sickOrgans = new int[2];

    private void Start()
    {
        ChooseSickOrgans();
    }
    void Update()
    {
        if (!visorCursor.activeSelf) return;

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Mathf.Abs(Camera.main.transform.position.z);

        visorCursor.transform.position =
            Camera.main.ScreenToWorldPoint(mousePos);
    }

    public void ChooseSickOrgans()
    {
        foreach (var organ in organs)
        {
            organ.SetActive(false);
        }

        int a = Random.Range(0, organs.Length);
        int b = Random.Range(0, organs.Length);

        while (b == a)
        {
            b = Random.Range(0, organs.Length);
        }

        organs[a].SetActive(true);
        organs[b].SetActive(true);
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
