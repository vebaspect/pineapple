$scriptDir = $PSScriptRoot.Substring(0, $PSScriptRoot.LastIndexOf("\"))

If (Test-Path $scriptDir\dist) {
    Remove-Item `
        -Path $scriptDir\dist `
        -Force `
        -Recurse
}

dotnet publish $scriptDir\src\Pineapple.Api\Pineapple.Api.csproj -o $scriptDir\dist\Pineapple.Api -c Publish --self-contained true -p:PublishSingleFile=true -p:PublishTrimmed=true -p:IncludeAllContentForSelfExtract=true

# Skopiowanie pliku "CHANGELOG.md".
$source = "$scriptDir\CHANGELOG.md"
$destination = "$scriptDir\dist\CHANGELOG.md"
Copy-Item -Path $source -Destination $destination
