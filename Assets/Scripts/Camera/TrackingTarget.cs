
using System;
using Unity.Cinemachine;
using UnityEngine;

public class TrackingTarget : MonoBehaviour
{
    // 1. Cinemachine Camera 변수
    public CinemachineCamera cinemachineCamera;

    void Start()
    {
        // 3. Player의 Action과 ChangeTarget 연결
        PlayerEventBus.Instance.OnThrown += ChangeTarget;
        PlayerEventBus.Instance.OnTeleport += ChangeTarget;
    }

    void OnDestroy()
    {
        PlayerEventBus.Instance.OnThrown -= ChangeTarget;
        PlayerEventBus.Instance.OnTeleport -= ChangeTarget;
    }

    // 3 & 4. 매개변수로 받은 Transform으로 Cinemachine 타겟 변경
    public void ChangeTarget(Transform target)
    {
        cinemachineCamera.Follow = target;
    }
}