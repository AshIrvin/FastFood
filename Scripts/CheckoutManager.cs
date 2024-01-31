using TMPro;
using UnityEngine;

public class CheckoutManager : MonoBehaviour
{
    /* Press button for item
     * Item price added to till order
     */

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

    public void AddItem(Items items)
    {
        _tillPrice += GetItemPrice(items);
        _tillPriceText.text = _tillPrice.ToString("0.00");

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
