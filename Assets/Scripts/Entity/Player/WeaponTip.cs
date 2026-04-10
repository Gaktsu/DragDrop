using System;
using UnityEngine;

public class WeaponTip : MonoBehaviour
{
    // 1. Trigger 발생 시 Layer와 GameObject를 전달하는 Action
    public Action<int, GameObject, Collider2D> onCollisionEnter;

    private Weapon weapon;

    void Awake()
    {
        weapon = GetComponentInParent<Weapon>();

        // 3. Action과 Weapon의 수신 함수 연결
        onCollisionEnter += weapon.OnTipTriggerEnter;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"[WeaponTip] OnTriggerEnter2D - 충돌 오브젝트: {other.gameObject.name}, Layer: {LayerMask.LayerToName(other.gameObject.layer)}");

        // 4. Trigger 발생 시 Action Invoke
        onCollisionEnter?.Invoke(other.gameObject.layer, other.gameObject, other);
    }
}