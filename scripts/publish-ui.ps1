$scriptDir = $PSScriptRoot.Substring(0, $PSScriptRoot.LastIndexOf("\"))

If (Test-Path $scriptDir\dist\Pineapple.Ui) {
    Remove-Item `
        -Path $scriptDir\dist\Pineapple.Ui `
        -Force `
        -Recurse
}

npm run publish --prefix $scriptDir\src\Pineapple.Ui
