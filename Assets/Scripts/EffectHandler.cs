using UnityEngine;

public class EffectHandler : MonoBehaviour
{
    // 1. ParticleSystem을 매개변수로 받아 한 번 Play하는 static 함수
    public static void Play(ParticleSystem particle)
    {
        particle.Play();
    }
}
