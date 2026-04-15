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

    private IProduct product;
    private Shop shop;

    public void Bind(IProduct product, Shop shop)
    {
        this.product = product;
        this.shop = shop;
        nameText.text = product.Name;
        descriptionText.text = product.Description;
        iconImage.sprite = product.Icon;
        cost = shop.productPrice != null ? shop.productPrice.GetRandomCost(product.ProductType) : 0;
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
            product.OnPurchase(Player.Instance);
        }
    }
}