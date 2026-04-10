try {
    $rawInput = [Console]::In.ReadToEnd()
} catch { }

$instruction = @"
[SYSTEM: RESUMING TASK]
1. Check the 'Progress Tracking' in memory to find the last unfinished `[ ]`.
2. Do not repeat previous questions. Continue exactly where you left off.
3. If code was partially written, verify its state before proceeding.
"@

@{
    cancel = $false
    contextModification = $instruction
    errorMessage = ""
} | ConvertTo-Json -Compress