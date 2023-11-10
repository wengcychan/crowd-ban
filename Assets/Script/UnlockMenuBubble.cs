using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UnlockMenuBubble : MonoBehaviour
{
    public TextMeshProUGUI coinValue;
    public GameObject unlockText;
    public GameObject noButton;
    public GameObject yesButton;
    public GameObject noCoinText;
    public GameObject okButton;
    public GameObject unlockMenu;
    public GameObject unlock;
    int coin;
    string coinText;

    public void Yes()
    {
        if (PlayerPrefs.GetInt("Coin", 0) >= 10)
        {
            PlayerPrefs.SetInt("BubbleLevelOpen", 1);
            coin = PlayerPrefs.GetInt("Coin", 0) - 10;
            PlayerPrefs.SetInt("Coin", coin);

            if (coin < 10)
            {
                coinText = "000000" + coin;
            }

            else if (coin >= 10 && coin < 100)
            {
                coinText = "00000" + coin;
            }

            else if (coin >= 100 && coin < 1000)
            {
                coinText = "0000" + coin;
            }

            else if (coin >= 1000 && coin < 10000)
            {
                coinText = "000" + coin;
            }


            else if (coin >= 10000 && coin < 100000)
            {
                coinText = "00" + coin;
            }

            else if (coin >= 100000 && coin < 1000000)
            {
                coinText = "0" + coin;
            }

            else if (coin < 10000000)
            {
                coinText = coin.ToString();
            }

            else if (coin >= 10000000)
            {
                coinText = "9999999";
            }

            coinValue.SetText(coinText);

            unlockMenu.SetActive(false);
            unlock.SetActive(false);
        }

        else
        {
            unlockText.SetActive(false);
            noButton.SetActive(false);
            yesButton.SetActive(false);
            noCoinText.SetActive(true);
            okButton.SetActive(true);
        }


    }
}
