using UnityEngine;

public interface IProduct
{
    string Name { get; }
    string Description { get; }
    Sprite Icon { get; }
    ProductType ProductType { get; }
    void OnPurchase(Player player);
}
