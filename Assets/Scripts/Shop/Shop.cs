// TODO
// 5. 구매했을 경우, UX적용(약간 어둡게?)
// 6. 구매하면 2번에 대한 Book 스크립트를 가져와 Add함

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public List<Product> productSlots;
    public Transform contentParent;
    public GameObject shopPanel;
    public ProductPriceSO productPrice;

    private Product activeProduct;

    void Start()
    {
        productSlots = contentParent.GetComponentsInChildren<Product>().ToList();
    }

    public void OpenShop()
    {
        shopPanel.SetActive(true);
        CreateProducts();
    }

    public void CloseShop()
    {
        shopPanel.SetActive(false);
    }

    private void CreateProducts()
    {
        foreach (var product in productSlots)
        {
            if (productPrice == null) continue;

            IProduct newProduct = CreateProduct(product.productType);

            if (newProduct != null)
                product.Bind(newProduct, this);
        }
    }

    private IProduct CreateProduct(ProductType type)
    {
        return type switch
        {
            ProductType.Skill => new SkillProduct(DatabaseHub.Instance.skillDB.GetRandomSkill()),
            ProductType.Throw => new ThrowProduct(DatabaseHub.Instance.throwDB.GetRandomThrow()),
            ProductType.Relic => new RelicProduct(DatabaseHub.Instance.relicDB.GetRandomRelic()),
            _ => null
        };
    }

    public void ActiveDetail(Product product)
    {
        if (activeProduct != null && activeProduct != product)
            activeProduct.HideDetail();

        activeProduct = product;
        activeProduct.ShowDetail();
    }
}