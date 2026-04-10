try {
    $rawInput = [Console]::In.ReadToEnd()
} catch { }

$instruction = @"
[SYSTEM: FINAL QA PROTOCOL]
1. Verify all Todo items are `[x]`.
2. Check for any placeholder code or `TODO` comments.
3. Ensure the final state of `memory.md` accurately reflects the project.
4. Report the result clearly and return control.
"@

@{
    cancel = $false
    contextModification = $instruction
    errorMessage = ""
} | ConvertTo-Json -Compress