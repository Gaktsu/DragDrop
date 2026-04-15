using System;

public class Relic
{
    // 이 유물의 원본 데이터 (이름, 아이콘 등)
    public RelicData data;
    public Action OnUpdateStackCount;

    // 생성자: 설계도를 받아서 실체를 만듦
    public Relic(RelicData data)
    {
        this.data = data;
    }

    // 외부에서 사건이 터졌을 때 호출됨
    public void HandleEvent(RelicContext context)
    {
        // 1. 설계도에 정의된 트리거가 조건을 만족하는지 확인
        if (data.trigger.CheckCondition(context))
        {
            // 2. 조건을 만족하면 설계도에 정의된 효과 실행
            data.effect.Execute(context);
        }
    }
}