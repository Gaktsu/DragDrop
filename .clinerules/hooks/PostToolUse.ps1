try {
    $rawInput = [Console]::In.ReadToEnd()
} catch { }

$instruction = @"
[SYSTEM: POST-TOOL AUDIT]
1. If code was modified, run `dotnet build` or a check to verify syntax.
2. Update `memory.md` immediately if a technical decision was made.
3. Mark the completed step in your Todo list with `[x]`.
"@

@{
    cancel = $false
    contextModification = $instruction
    errorMessage = ""
} | ConvertTo-Json -Compress