using Player;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ColorInShop : MonoBehaviour
{
    [SerializeField]
    private int price;
    [SerializeField]
    private PlayerStats playerStats;
    [SerializeField]
    private TextMeshProUGUI buttonText;
    [SerializeField]
    private TextMeshProUGUI priceText;
    [SerializeField]
    private TextMeshProUGUI sellButtonText;
    [SerializeField]
    private Image image;
    [SerializeField]
    private Button sellButton;
    [SerializeField]
    List<ColorInShop> colors;

    private bool isSelected = false;

    public bool IsSelected { get => isSelected; set => isSelected = value; }

    private void Awake()
    {
        UpdateButtonText();
        UpdatePriceText();
    }

    public void UpdateButtonText()
    {
        if (IsOwned())
        {
            if(image.color == playerStats.color)
            {
                IsSelected = true;
            }
            if(IsSelected)
            {
                buttonText.text = "Selected";
            }
            if(!IsSelected)
            {
                buttonText.text = "Select";
            }
            sellButton.gameObject.SetActive(true);
        }
        else
        {
            sellButton.gameObject.SetActive(false);
            buttonText.text = "Buy";
        }
    }

    public void PressButton()
    {
        if (!IsOwned())
        {
            if (playerStats.Money > price)
            {
                playerStats.Money -= price;
                playerStats.OwnedColors.Add(image.color);
            }
        }
        if (IsOwned())
        {
            playerStats.color = image.color;
            foreach (var color in colors)
            {
                color.IsSelected = false;
                color.UpdateButtonText();
            }
            IsSelected = true;
        }
        UpdateButtonText();
    }

    public void OnSellClick()
    {
        playerStats.OwnedColors.Remove(image.color);
        playerStats.Money += price / 2;
        if (isSelected)
        {
            playerStats.ReturnToDefaultColor();
            isSelected = false;
        }
        UpdateButtonText();
    }

    private bool IsOwned()
    {
        if (playerStats.OwnedColors.Contains(image.color))
        {
            return true;
        }
        return false;
    }


    private void UpdatePriceText()
    {
        priceText.text = "Price: " + price.ToString();
        sellButtonText.text = "Sell for: " + (price / 2).ToString();
    }
}
