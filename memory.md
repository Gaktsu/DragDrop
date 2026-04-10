---
applyTo: '**'
---
# 🎮 Game Project Memory: Action RPG with Throw Mechanics

## 🏗️ Core Architecture

### 프로젝트 식별
- **Project Name**: DragDrop (Action RPG with Throwing Weapon System)
- **Genre**: Action RPG / Roguelike
- **Core Loop**: 무기 투척 → 적 처치 → 스킬/투척기술 구매 → 강화 → 반복
- **Tech Stack**: Unity 6, C#, URP, New Input System, TextMesh Pro

### 설계 철학
- **Event-Driven Architecture**: Update() 남용 방지, Action/UnityEvent 기반 반응형 설계
- **ScriptableObject 기반 데이터 주입**: 런타임 디커플링 및 에디터 조정 용이성
- **Strategy Pattern**: 제품 타입별 독립적인 구매 로직
- **Factory Pattern**: 무기 생성 및 관리
- **Data-Driven Design**: SO 기반 스킬/투척/가격 데이터 외부화

---

## 📊 시스템 아키텍처 맵

### 1. Entity System (엔티티 계층)
**위치**: `Assets/Scripts/Entity/`

**핵심 구조**:
```
Entity (추상 베이스)
├── Player (싱글톤)
│   ├── WeaponFactory (무기 생성 관리)
│   ├── ActionLibrary (스킬북/투척북 보유)
│   └── PlayerInputHandler (입력 처리)
└── Enemy
    └── (상태 관리)

StatController (스탯 관리)
StatusController (상태효과 관리)
```

**의존성**:
- Entity → StatController (1:1 소유)
- Entity → StatusController (1:1 소유)
- Player → WeaponFactory (1:1 소유)
- Player → ActionLibrary (1:1 소유)

**설계 패턴**:
- **Singleton**: Player, ActionLibrary (씬 내 단일 인스턴스)
- **Template Method**: Entity.Damaged() 가상 메서드
- **Composition over Inheritance**: Stat/Status를 별도 클래스로 분리

---

### 2. Usable System (스킬/투척 시스템)
**위치**: `Assets/Scripts/Usable/`

**핵심 구조**:
```
Skill (런타임 인스턴스)
├── SkillData (SO) → SkillAction (SO 전략)
└── Cooldown 관리

Throw (런타임 인스턴스)
├── ThrowData (SO) → ThrowBehavior (SO 전략)
└── Cooldown 관리

SkillBook / ThrowBook (컬렉션 관리자)
```

**의존성**:
- SkillData(SO) → SkillAction(SO)
- ThrowData(SO) → ThrowBehavior(SO)
- Skill/Throw → respective Data(SO)
- ActionLibrary → SkillBook + ThrowBook

**설계 패턴**:
- **Strategy Pattern**: SkillAction, ThrowBehavior (다형적 행동 정의)
- **Data Object**: 런타임 Skill/Throw는 SO 참조만 보유
- **Observer Pattern**: Action<> 콜백으로 쿨다운 UI 업데이트

**기술적 결정**:
- SO로 행동 정의 → 런타임 수정 없이 밸런싱 가능
- Action 델리게이트로 UI 갱신 → 강결합 방지

---

### 3. Shop System (상점 시스템)
**위치**: `Assets/Scripts/Shop/`

**핵심 구조**:
```
Shop (MonoBehaviour)
├── Product (UI 슬롯) → IProductStrategy
│   ├── SkillProductStrategy
│   └── ThrowProductStrategy
└── ProductPriceSO (가격 데이터)

DatabaseHub (싱글톤)
├── SkillDatabase (SO)
└── ThrowDatabase (SO)
```

**의존성**:
```
DatabaseHub → SkillDatabase/ThrowDatabase (SO)
      ↓
Shop.CreateStrategy() → RandomSkill/Throw
      ↓
IProductStrategy 구현체 생성
      ↓
Product.Bind(strategy)
      ↓
Player.ActionLibrary.Add()
```

**설계 패턴**:
- **Strategy Pattern**: IProductStrategy로 제품 타입별 구매 로직 캡슐화
- **Factory Method**: CreateStrategy()로 전략 객체 생성
- **Singleton**: DatabaseHub (전역 데이터 접근)

**기술적 결정**:
- 가격 랜덤화를 ProductPriceSO로 외부화 → 밸런싱 편의성
- Strategy 패턴으로 제품 타입 확장 시 수정 최소화 (OCP 준수)

---

### 4. Weapon System (무기 투척 시스템)
**위치**: `Assets/Scripts/Entity/Player/`

**핵심 구조**:
```
WeaponFactory (무기 생성/관리)
└── Weapon (프리팹 인스턴스)
    ├── WeaponTip (충돌 감지)
    ├── WeaponHit (타격 처리)
    └── ThrowBehavior (SO 전략)

ThrowContext (투척 상태 전달 객체)
```

**의존성**:
- Player → WeaponFactory.OnThrow()
- WeaponFactory → Weapon 프리팹 생성
- Weapon → ThrowBehavior.OnThrow(context)
- WeaponTip → Weapon.OnTipTriggerEnter()
- Weapon → WeaponHit.Attack()

**설계 패턴**:
- **Factory Pattern**: WeaponFactory가 Weapon 인스턴스 생성/관리
- **Strategy Pattern**: ThrowBehavior(LinearThrow 등) 다형성
- **Context Object**: ThrowContext로 필요한 데이터만 전달
- **Delegation**: Weapon은 ThrowBehavior/WeaponHit에 로직 위임

**기술적 결정**:
- ThrowBehavior를 SO로 정의 → 런타임 교체 가능
- Context 객체로 필수 데이터만 전달 → 결합도 감소
- WeaponHit 분리 → SRP 준수

---

### 5. Database System (데이터 허브)
**위치**: `Assets/Scripts/Database/`

**핵심 구조**:
```
DatabaseHub (싱글톤 MonoBehaviour)
├── SkillDatabase (SO)
└── ThrowDatabase (SO)
```

**의존성**:
- Shop → DatabaseHub.GetRandomSkill/Throw()
- 각 Database(SO) → 에디터에서 할당된 SkillData/ThrowData 배열

**설계 패턴**:
- **Singleton**: DatabaseHub (전역 접근점)
- **Repository**: Database SO가 데이터 컬렉션 제공

**기술적 결정**:
- MonoBehaviour 싱글톤으로 SO 참조 보유 → 런타임 접근 용이
- GetRandom() 메서드로 무작위 선택 캡슐화

---

### 6. Status System (상태효과 시스템)
**위치**: `Assets/Scripts/Entity/StatusController.cs`

**핵심 구조**:
```
StatusEffect (데이터 클래스)
└── StatusEffectType (Enum: Enhance/Debuff/Shield)

StatusController (상태 관리자)
├── AddEffect()
├── ProcessTurn()
├── GetTotalModifier()
└── HandleShield()
```

**의존성**:
- Entity → StatusController (1:1 소유)
- StatController.GetAttackPower() → StatusController.GetTotalModifier()

**설계 패턴**:
- **Flyweight**: StatusEffect를 재사용 가능한 데이터 구조로 정의
- **Strategy**: OnHitEffect 플래그로 트리거 타이밍 분기

**기술적 결정**:
- 턴제 게임 로직 (ProcessTurn()으로 지속시간 감소)
- 보호막을 별도 HandleShield()로 분리 → 데미지 계산 로직과 독립

---

## 🛠️ Technical Decisions

### 아키텍처 결정
- **Pattern**: Strategy + Factory + Singleton 조합으로 확장성 확보
- **Physics**: Rigidbody2D 기반 투척 물리 (ThrowBehavior 구현체에서 제어)
- **Optimization**: SO 기반 데이터 공유로 메모리 효율화
- **Event System**: Action<> 델리게이트로 UI 업데이트 (UnityEvent 미사용)

### 메모리 최적화 전략
- **SO 활용**: SkillData, ThrowData, ThrowBehavior 등 공유 데이터
- **Object Pooling**: 미구현 (WeaponFactory에서 매 투척마다 인스턴스 생성)
- **GC 압박**: List<T> 사용, String 연산 존재 (개선 여지)

### 코드 품질 이슈
- **Update() 남용 방지**: ✅ 구현됨 (이벤트 기반)
- **XML 문서화**: ❌ Public 메서드 대부분 주석 없음
- **Null 체크**: 부분적 (ProductPriceSO, strategy 등)
- **Magic Number**: 일부 존재 (Int32.MaxValue 등)

---

## 📝 Coding Patterns & Preferences

### 관찰된 코딩 스타일
- **Architecture**: 
  - ScriptableObject 기반 데이터 주입 선호
  - Singleton 패턴 적극 사용 (Player, DatabaseHub, ActionLibrary)
  - Strategy 패턴으로 다형성 구현
  
- **Naming**: 
  - Public 필드: camelCase (productSlots, shopPanel)
  - Private 필드: camelCase (activeProduct, strategy)
  - _(언더스코어) 접두사 미사용
  
- **Documentation**: 
  - TODO 주석 존재 (`Shop.cs` 상단)
  - 간단한 한글 주석 사용
  - XML 문서화 주석 부재

- **Type Preferences**:
  - List<T> 선호 (배열 대신)
  - LINQ 사용 (`.ToList()`, `.Find()`)
  - var 키워드 사용하지 않음 (명시적 타입 선언)

---

## 🚀 Progress Tracking

### 마지막 분석일
**2026.04.11 01:14**

### 구현 완료 시스템
- [x] Entity System (Player, Enemy, Stat, Status)
- [x] Usable System (Skill, Throw, Book 관리)
- [x] Shop System (Product, Strategy, Database 연동)
- [x] Weapon System (Factory, Behavior, Hit Detection)
- [x] Database Hub (Singleton 기반 데이터 접근)
- [x] Input System (New Input System 연동)
- [x] UI System (BehaviorActPanel, SkillUI, ThrowUI)

### 기술 부채
- [ ] **Event-Driven 미흡**: Action<> 사용하지만 UnityEvent 미활용
- [ ] **Object Pooling 부재**: Weapon 인스턴스 매번 생성 (GC 압박)
- [ ] **Memory Optimization**: 
  - List<T> 대신 T[] 배열 고려
  - String 연산 최소화 필요
  - ref/out 키워드 미사용
- [ ] **XML Documentation**: Public API 문서화 부재
- [ ] **Null Safety**: 일부 null 체크 누락 가능성
- [ ] **Magic Numbers**: 하드코딩된 상수 (예: Int32.MaxValue)

### 확장 가능성 분석
**강점**:
- Strategy 패턴으로 새 스킬/투척/제품 타입 추가 용이
- SO 기반 데이터로 밸런싱 에디터에서 즉시 가능
- Factory 패턴으로 무기 로직 중앙 집중식 관리

**개선 필요**:
- Weapon Object Pooling 도입 시 성능 향상 기대
- Event System 표준화 (Action vs UnityEvent 혼용)
- 턴제 로직(StatusController)과 실시간 로직(Weapon) 분리 명확화

### 아키텍처 준수도
| 규칙 | 상태 | 비고 |
|------|------|------|
| Event-Driven | ⚠️ | Action<> 사용, UnityEvent 미활용 |
| ScriptableObject 활용 | ✅ | 8개 SO 클래스 적극 활용 |
| Update() 최소화 | ✅ | 입력/이벤트 기반 설계 |
| Object Pooling | ❌ | Weapon 매번 생성 |
| Struct 우선 | ❌ | Class 중심 설계 |
| XML 문서화 | ❌ | 주석 부재 |
| ref/out 활용 | ❌ | 미사용 |

---

## 🔗 시스템 간 의존성 체인

### 구매 플로우
```
DatabaseHub(SO 보유)
    ↓ GetRandomSkill/Throw()
Shop.CreateStrategy()
    ↓ new SkillProductStrategy(data)
Product.Bind(strategy)
    ↓ Product.Purchase()
IProductStrategy.OnPurchase(player)
    ↓ player.ActionLibrary.AddSkill/Throw()
SkillBook/ThrowBook
    ↓ new Skill(data) / new Throw(data)
UI Update (Action<> 콜백)
```

### 전투 플로우
```
PlayerInputHandler.OnFire()
    ↓ Player.ExecuteSkill()
Skill.Use()
    ↓ SkillAction.Execute(player)
OR
WeaponFactory.OnThrow(direction)
    ↓ Weapon 인스턴스 생성
Weapon.OnThrow(context)
    ↓ ThrowBehavior.OnThrow(context)
WeaponTip Trigger Enter
    ↓ Weapon.OnTipTriggerEnter()
WeaponHit.Attack(enemy)
    ↓ Enemy.Damaged()
StatusController.HandleShield()
    ↓ StatController HP 감소
```

---

## 📌 Next Steps (향후 작업 추천)

### 성능 최적화
1. WeaponFactory에 Object Pool 도입
2. List<Product> → Product[] 배열 변환
3. String.Format 대신 StringBuilder 사용

### 코드 품질
1. Public 메서드에 XML 주석 추가
2. Magic Number를 const/readonly 상수화
3. Null 체크 강화 (Null-Conditional Operator 활용)

### 아키텍처 개선
1. Event System 통일 (Action vs UnityEvent 정책 수립)
2. 턴제/실시간 시스템 분리 명확화
3. StatusEffect를 Struct로 변환 (GC 부하 감소)