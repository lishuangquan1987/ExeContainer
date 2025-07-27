# ExeContainer NuGet Package Publisher
# Usage: .\publish.ps1 -ApiKey "your-api-key" -Version "1.0.0"

param(
    [Parameter(Mandatory=$true)]
    [string]$ApiKey,
    
    [Parameter(Mandatory=$false)]
    [string]$Version = "1.0.0"
)

Write-Host "🚀 Starting ExeContainer NuGet Package Publishing..." -ForegroundColor Green

# Step 1: Update version in project file
Write-Host "📝 Updating version to $Version..." -ForegroundColor Yellow
$projectFile = "ExeContainer\ExeContainer.csproj"
$content = Get-Content $projectFile -Raw
$content = $content -replace '<Version>.*?</Version>', "<Version>$Version</Version>"
Set-Content $projectFile $content

# Step 2: Build the project
Write-Host "🔨 Building project..." -ForegroundColor Yellow
dotnet build --configuration Release
if ($LASTEXITCODE -ne 0) {
    Write-Host "❌ Build failed!" -ForegroundColor Red
    exit 1
}

# Step 3: Create packages
Write-Host "📦 Creating NuGet packages..." -ForegroundColor Yellow
if (Test-Path "nupkgs") {
    Remove-Item "nupkgs" -Recurse -Force
}
dotnet pack ExeContainer\ExeContainer.csproj --configuration Release --output nupkgs
if ($LASTEXITCODE -ne 0) {
    Write-Host "❌ Package creation failed!" -ForegroundColor Red
    exit 1
}

# Step 4: Publish to NuGet
Write-Host "📤 Publishing to NuGet..." -ForegroundColor Yellow
$nupkgFile = "nupkgs\ExeContainer.$Version.nupkg"
if (Test-Path $nupkgFile) {
    dotnet nuget push $nupkgFile --api-key $ApiKey --source https://api.nuget.org/v3/index.json
    if ($LASTEXITCODE -eq 0) {
        Write-Host "✅ Package published successfully!" -ForegroundColor Green
        Write-Host "📋 Package: $nupkgFile" -ForegroundColor Cyan
        Write-Host "🔗 View on NuGet: https://www.nuget.org/packages/ExeContainer" -ForegroundColor Cyan
    } else {
        Write-Host "❌ Package publishing failed!" -ForegroundColor Red
        exit 1
    }
} else {
    Write-Host "❌ Package file not found: $nupkgFile" -ForegroundColor Red
    exit 1
}

Write-Host "🎉 Publishing completed successfully!" -ForegroundColor Green 