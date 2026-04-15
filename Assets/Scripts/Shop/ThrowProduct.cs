using UnityEngine;

public class ThrowProduct : IProduct
{
    private readonly ThrowData data;

    public ThrowProduct(ThrowData data) => this.data = data;

    public string Name => data.throwName;
    public string Description => data.description;
    public Sprite Icon => data.icon;
    public ProductType ProductType => ProductType.Throw;

    public void OnPurchase(Player player)
    {
        ActionLibrary.Instance.throwBook.AddThrow(data);
    }
}
