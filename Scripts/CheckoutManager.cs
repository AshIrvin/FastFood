using TMPro;
using UnityEngine;

public class CheckoutManager : MonoBehaviour
{
    public enum Items
    {
        Burger,
        Wrap,
        Chips,
        Juice,
        Coffee,
        Icecream
    }

    [SerializeField] private float _tillPrice;
    [SerializeField] private TextMeshPro _tillPriceText;
    [SerializeField] private Items _items;
    [SerializeField] private string _paymentAccepted = "Payment Accepted";
    [SerializeField] private string _paymentDeclined = "Payment Declined";
    [SerializeField] private GameObject[] _orderScreenOutOfOrder;

    private void Start()
    {
        AvatarManager.OnTryingToPay += UpdateTillScreen;
        AvatarManager.OnPressingOrderScreen += DisplayOutOfOrder;
    }

    private void DisplayOutOfOrder(int n)
    {
        _orderScreenOutOfOrder[n].SetActive(true);
    }

    private void UpdateTillScreen(string tillText)
    {
        _tillPriceText.text = tillText;
    }

    public void AddItem(Items items)
    {
        _tillPrice += GetItemPrice(items);
        UpdateTillScreen(_tillPrice.ToString("0.00"));

        // TODO - add till ka-ching sound
    }

    private float GetItemPrice(Items items)
    {
        switch (items)
        {
            case Items.Burger:
                return 3.99f;

            case Items.Wrap:
                return 2.99f;

            case Items.Chips:
                return 0.99f;

            case Items.Juice:
                return 1.99f;

            case Items.Icecream:
                return 1.99f;

            case Items.Coffee:
                return 1.99f;
        }

        return 0;
    }
}
