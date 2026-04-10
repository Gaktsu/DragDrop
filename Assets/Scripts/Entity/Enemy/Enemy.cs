using System.Collections;
using UnityEngine;

public class Enemy : Entity
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite idleSprite;
    [SerializeField] private Sprite attackedSprite;
    [SerializeField] private float hitFlashDuration = 0.2f;

    protected override void Awake()
    {
        base.Awake();
    }

    public override void Damaged(int damage)
    {
        int deltaHp = stat.Hp - damage;
        stat.SetHp(deltaHp);
        Debug.Log($"[Enemy] Damaged - 피해량: {damage}, 남은 HP: {deltaHp}");

        spriteRenderer.sprite = attackedSprite;
        StartCoroutine(ResetVisualsDelayed());
    }

    private IEnumerator ResetVisualsDelayed()
    {
        yield return new WaitForSeconds(hitFlashDuration);
        spriteRenderer.sprite = idleSprite;
    }
}
