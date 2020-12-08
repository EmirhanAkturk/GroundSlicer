using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject splashPanel;
    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        SplashControl();
    }

    void SplashControl()
    {
        if (PlayerPrefs.GetInt("FirstOpen") == 0)
        {
            player.SetActive(false);
            splashPanel.SetActive(true);
        }
    }
}
