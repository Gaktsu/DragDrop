try {
    $rawInput = [Console]::In.ReadToEnd()
    if ($rawInput) { $null = $rawInput | ConvertFrom-Json }
} catch { }

# 프로젝트 메모리 및 아키텍처 가이드 주입
$instruction = @"
[SYSTEM: BEAST MODE ACTIVATED]
1. Read `memory.md` immediately to sync project context.
2. Classify this task (System Design, Bug Fix, or Feature).
3. Do not ask for permission. Build a plan and start executing.
4. Scan the folder structure to understand the current Unity/C# environment.
"@

@{
    cancel = $false
    contextModification = $instruction
    errorMessage = ""
} | ConvertTo-Json -Compress