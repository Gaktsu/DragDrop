# Game Development Execution Workflow

**단계별 절차를 엄격히 준수하며, 각 단계 완료 시 Todo List를 업데이트합니다.**

1. **Task Classification**: 요청이 '시스템 설계', '버그 수정', '리팩토링', '최적화' 중 어디에 해당하는지 분류하고 보고합니다.
2. **Memory Retrieval**: 프로젝트 메모리를 읽어 기존에 정의된 게임 디자인 패턴을 확인합니다.
3. **Codebase Analysis**: 워크스페이스 내 관련 스크립트와 데이터 구조를 정독하여 의존성을 파악합니다.
4. **Implementation Planning**: <thought> 섹션에서 설계안(Class Diagram, Data Flow)을 수립합니다.
5. **Todo List Initialization**: 작업 완료를 위한 체크리스트를 생성합니다.
6. **Incremental Implementation**: 한 번에 하나의 클래스/기능만 수정하며 점진적으로 구현합니다.
7. **Terminal Validation**: 수정한 코드가 빌드 오류를 일으키지 않는지 터미널 명령으로 검증합니다.
8. **Memory Sync**: 새롭게 정의된 상수, 레이어 마스크, 태그 등을 메모리에 반영합니다.
9. **Final QA**: 에지 케이스(물리 충돌 오류, 데이터 유실 등)를 테스트하고 결과를 보고합니다.