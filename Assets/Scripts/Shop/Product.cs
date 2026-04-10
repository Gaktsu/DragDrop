using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Product : MonoBehaviour, IPointerClickHandler
{
    public ProductType productType;
    public GameObject detail;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI costText;
    public Image iconImage;

    public int cost;
    public bool purchased;

    private IProductStrategy strategy;
    private Shop shop;

    public void Bind(IProductStrategy strategy, Shop shop)
    {
        this.strategy = strategy;
        this.shop = shop;
        nameText.text = strategy.Name;
        descriptionText.text = strategy.Description;
        iconImage.sprite = strategy.Icon;
        cost = shop.productPrice != null ? shop.productPrice.GetRandomCost(strategy.ProductType) : 0;
        costText.text = cost.ToString();
    }

    public void ShowDetail() => detail.SetActive(true);
    public void HideDetail() => detail.SetActive(false);

    public void OnPointerClick(PointerEventData eventData)
    {
        shop.ActiveDetail(this);
    }

    public void Purchase()
    {
        int money = Int32.MaxValue; // 돈 관리하는곳에서 가져오기

        if (purchased == true)
            return;

        if (money > cost)
        {
            money -= cost;
            purchased = true;
            strategy.OnPurchase(Player.Instance);
        }
    }
}