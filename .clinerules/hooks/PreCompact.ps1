try {
    $rawInput = [Console]::In.ReadToEnd()
} catch { }

$instruction = @"
[SYSTEM: CONTEXT COMPRESSION WARNING]
- The conversation is getting long. 
- Summarize all key logic, constants, and architecture changes into `memory.md` NOW.
- Ensure no "Technical Decisions" are lost in this compression.
"@

@{
    cancel = $false
    contextModification = $instruction
    errorMessage = ""
} | ConvertTo-Json -Compress