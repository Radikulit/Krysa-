using UnityEngine;

public class OrganHover : MonoBehaviour
{
    public bool isSick = false;
    SpriteRenderer sr;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.enabled = false;
    }
    void OnMouseEnter()
    {
        if (isSick)
        {
            sr.enabled = true;

        }
    }
    void OnMouseExit()
    {
        if (isSick)
        {
            sr.enabled = false;

        }
    }
}
