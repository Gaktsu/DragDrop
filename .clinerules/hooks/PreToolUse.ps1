try {
    $rawInput = [Console]::In.ReadToEnd()
} catch { }

$instruction = @"
[SYSTEM: PRE-TOOL VALIDATION]
- Terminal: Ensure commands are safe for the Unity/C# environment.
- Edit: Ensure the change follows the established Game Design Patterns in memory.
- Search: Verify if you really need to search or if you already have the context.
"@

@{
    cancel = $false
    contextModification = $instruction
    errorMessage = ""
} | ConvertTo-Json -Compress