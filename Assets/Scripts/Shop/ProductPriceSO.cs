using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ProductPriceSO", menuName = "Scriptable Objects/ProductPriceSO")]
public class ProductPriceSO : ScriptableObject
{
    [Serializable]
    public class PriceRange
    {
        public ProductType type;
        public int minCost;
        public int maxCost;
    }

    public List<PriceRange> priceRanges;

    public int GetRandomCost(ProductType type)
    {
        var range = priceRanges.Find(r => r.type == type);
        if (range == null) return 0;
        return UnityEngine.Random.Range(range.minCost, range.maxCost + 1);
    }
}
