using UnityEngine;

public class SkillProductStrategy : IProductStrategy
{
    private readonly SkillData data;

    public SkillProductStrategy(SkillData data) => this.data = data;

    public string Name => data.throwName;
    public string Description => data.description;
    public Sprite Icon => data.icon;
    public ProductType ProductType => ProductType.Skill;

    public void OnPurchase(Player player)
    {
        ActionLibrary.Instance.skillBook.AddSkill(data);
    }
}
