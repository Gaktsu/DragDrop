// 일반적인 투척 방식 : 한 방향으로 날아감 (해당 주석 지우지 말 것)

using UnityEngine;

[CreateAssetMenu(fileName = "LinearThrow", menuName = "Scriptable Objects/LinearThrow")]
public class LinearThrow : ThrowBehavior
{
	public override void OnThrow(ThrowContext context)
	{
		context.rb.linearVelocity = context.direction * context.speed;
	}

    public override void OnHitWall(ThrowContext context, Collider2D collider)
    {
        base.OnHitWall(context, collider);
    }
}