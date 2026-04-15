public class RelicContext
{
    public Entity owner;      // 원인 제공자
    public Entity target;      // 대상
    public RelicActionType actionType;   // 액션 종류

    public float value;              // 데미지량, 방어막량, 회복량 등
    public StatusEffectType status;  // 버프/디버프일 경우 어떤 종류인지 (선택 사항)

    // 생성자를 통해 다양한 상황을 빠르게 생성
    public RelicContext(Entity owner, Entity target, RelicActionType action, float value = 0, StatusEffectType status = StatusEffectType.None)
    {
        this.owner = owner;
        this.target = target;
        this.actionType = action;
        this.value = value;
        this.status = status;
    }
}