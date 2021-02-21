$scriptDir = $PSScriptRoot.Substring(0, $PSScriptRoot.LastIndexOf("\"))

If (Test-Path $scriptDir\dist) {
    Remove-Item `
        -Path $scriptDir\dist `
        -Force `
        -Recurse
}

& .\publish-api.ps1
& .\publish-ui.ps1
