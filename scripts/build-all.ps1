$scriptDir = $PSScriptRoot.Substring(0, $PSScriptRoot.LastIndexOf("\"))

If (Test-Path $scriptDir\dist) {
    Remove-Item `
        -Path $scriptDir\dist `
        -Force `
        -Recurse
}

dotnet build $scriptDir\src\Pineapple.Api\Pineapple.Api.csproj -o $scriptDir\dist\Pineapple.Api -c Build
