$scriptDir = $PSScriptRoot.Substring(0, $PSScriptRoot.LastIndexOf("\"))

If (Test-Path $scriptDir\dist) {
    Remove-Item `
        -Path $scriptDir\dist `
        -Force `
        -Recurse
}

& .\build-api.ps1
& .\build-ui.ps1
