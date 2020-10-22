using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseManager : MonoBehaviour
{
    public void OpenOrClose(GameObject panel)
    {
        if (panel.activeSelf)
        {
            panel.SetActive(false);
        }
        else if (!panel.activeSelf)
        {
            panel.SetActive(true);
        }
    }
}
