using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashPanel : MonoBehaviour
{
    public void GoButton()
    {
        PlayerPrefs.SetInt("FirstOpen", 1);
        gameObject.SetActive(false);
    }
}
