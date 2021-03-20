$scriptDir = $PSScriptRoot.Substring(0, $PSScriptRoot.LastIndexOf("\"))

If (Test-Path $scriptDir\dist\Pineapple.Api) {
    Remove-Item `
        -Path $scriptDir\dist\Pineapple.Api `
        -Force `
        -Recurse
}

# Runtime: win10-x64
dotnet publish $scriptDir\src\Pineapple.Api\Pineapple.Api.csproj -o $scriptDir\dist\Pineapple.Api\win10-x64 -r win10-x64 -c Publish --self-contained true -p:PublishSingleFile=true -p:PublishTrimmed=true -p:IncludeAllContentForSelfExtract=true

# Runtime: linux-x64
dotnet publish $scriptDir\src\Pineapple.Api\Pineapple.Api.csproj -o $scriptDir\dist\Pineapple.Api\linux-x64 -r linux-x64 -c Publish --self-contained true -p:PublishSingleFile=true -p:PublishTrimmed=true -p:IncludeAllContentForSelfExtract=true

# Skopiowanie pliku "CHANGELOG.md".
$source = "$scriptDir\CHANGELOG.md"
$destination = "$scriptDir\dist\CHANGELOG.md"
Copy-Item -Path $source -Destination $destination
