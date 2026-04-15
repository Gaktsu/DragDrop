using UnityEngine;

public class RelicProduct : IProduct
{
    private readonly RelicData data;

    public RelicProduct(RelicData data) => this.data = data;

    public string Name => data.relicName;
    public string Description => data.description;
    public Sprite Icon => data.icon;
    public ProductType ProductType => ProductType.Relic;

    public void OnPurchase(Player player)
    {
        ActionLibrary.Instance.relicBook.AddRelic(data);
    }
}
