using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour
{
    public Text coinsLeft;

    public int cur_coins = 0;

    public int max_coins = 0;

    public GameObject Portal;

    // Start is called before the first frame update
    void Start()
    {
        Portal.SetActive(false);
        max_coins = cur_coins;
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void UpdateUI()
    {
        if (cur_coins > 0)
        {
            coinsLeft.text = "Coins Left:" + cur_coins.ToString("D3") + "/" + max_coins.ToString("D3");
        }
        else if (cur_coins <= 0)
        {
            Portal.SetActive(true);
        }
    }

    public void LoadNextLevel(int x)
    {
        SceneManager.LoadScene(x);
    }
}