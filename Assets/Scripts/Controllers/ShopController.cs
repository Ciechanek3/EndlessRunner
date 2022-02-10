using Player;
using TMPro;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    [SerializeField]
    private int healthPriceMultiplier;
    [SerializeField]
    private PlayerStats playerStats;
    [SerializeField]
    private TextMeshProUGUI startingHpText;
    [SerializeField]
    private TextMeshProUGUI hpPriceText;
    [SerializeField]
    private TextMeshProUGUI currMoneyText;

    private void OnEnable()
    {
        UpdateTexts();
        playerStats.OnCashChanged += UpdateMoneyText;
        playerStats.OnStartingHealthChanged += UpdateMaxHpText;
        playerStats.OnStartingHealthChanged += UpdateHpPriceText;
    }

    private void OnDisable()
    {
        playerStats.OnCashChanged -= UpdateMoneyText;
        playerStats.OnStartingHealthChanged -= UpdateMaxHpText;
        playerStats.OnStartingHealthChanged -= UpdateHpPriceText;
    }

    public void BuyHealth()
    {
        AddHealth(CalculateHpPrice());
    }

    private void AddHealth(int price)
    {
        if (playerStats.Money >= price)
        {
            playerStats.StartingHealth++;
            playerStats.Money -= price;
        }
    }

    private int CalculateHpPrice()
    {
        return (playerStats.StartingHealth - 2) * healthPriceMultiplier;
    }

    public void UpdateTexts()
    {
        UpdateHpPriceText(0);
        UpdateMaxHpText(playerStats.StartingHealth);
        UpdateMoneyText(playerStats.Money);
    }
    private void UpdateHpPriceText(int value)
    {
        hpPriceText.text = "Cost: " + CalculateHpPrice().ToString();
    }
    private void UpdateMaxHpText(int value)
    {
        startingHpText.text = "Current max hp: " + value.ToString();
    }
    private void UpdateMoneyText(int value)
    {
        currMoneyText.text = "Cash: " + value.ToString();
    }
}
