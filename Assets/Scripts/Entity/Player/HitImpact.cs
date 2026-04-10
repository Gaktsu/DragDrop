using System.Collections;
using UnityEngine;

public class HitImpact : MonoBehaviour
{
    [Header("타격 연출 프리팹")]
    public GameObject hitSpritePrefab;    // 1. 피격 스프라이트
    public GameObject hitParticlePrefab;  // 2. 피격 파티클

    [Header("슬로우 모션 설정")]
    public float slowMotionTimeScale = 0.2f; // 얼마나 느려질지 (0.2 = 20% 속도)
    public float slowMotionDuration = 0.5f;  // 현실 시간으로 몇 초 유지할지

    public void ActiveHitImpact(Vector3 hitPoint)
    {
        StartCoroutine(HitImpactRoutine(hitPoint));
    }

    private IEnumerator HitImpactRoutine(Vector3 hitPoint)
    {
        // ==========================================
        // [1단계 & 2단계] 피격 스프라이트와 파티클 생성
        // ==========================================
        if (hitSpritePrefab != null)
            Instantiate(hitSpritePrefab, hitPoint, Quaternion.identity);

        if (hitParticlePrefab != null)
            Instantiate(hitParticlePrefab, hitPoint, Quaternion.identity);

        // ==========================================
        // [3단계] 게임 전체 속도 줄이기 (역경직 / 슬로우 모션)
        // ==========================================
        Time.timeScale = slowMotionTimeScale;

        // (선택) 물리 엔진도 같이 느리게 연산하도록 맞춰주면 더 부드럽습니다.
        Time.fixedDeltaTime = 0.02f * Time.timeScale;

        // ==========================================
        // [4단계] 0.5초 대기 후 정상 속도로 복구
        // ==========================================
        // 🚨 주의: timeScale이 변했으므로 그냥 WaitForSeconds를 쓰면 안 됩니다!
        // 현실 시간(Realtime) 기준으로 0.5초를 세어주는 함수를 써야 합니다.
        yield return new WaitForSecondsRealtime(slowMotionDuration);

        // 정상 속도로 복구
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f; // 물리 엔진 복구
    }
}