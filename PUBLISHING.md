# NuGet Package Publishing Guide

This guide explains how to publish the ExeContainer package to NuGet.

## Prerequisites

1. **NuGet Account**: Create an account at [nuget.org](https://www.nuget.org)
2. **API Key**: Generate an API key from your NuGet account
3. **GitHub Secrets**: Add your NuGet API key to GitHub repository secrets

## Publishing Methods

### Method 1: GitHub Actions (Recommended)

1. **Set up GitHub Secrets**:
   - Go to your GitHub repository
   - Navigate to Settings → Secrets and variables → Actions
   - Add a new secret named `NUGET_API_KEY` with your NuGet API key

2. **Create a Release Tag**:
   ```bash
   git tag v1.0.0
   git push origin v1.0.0
   ```

3. **Automatic Publishing**:
   - The GitHub Actions workflow will automatically build and publish the package
   - Check the Actions tab in your repository to monitor the process

### Method 2: Manual Publishing

1. **Build the Package**:
   ```bash
   dotnet pack ExeContainer/ExeContainer.csproj --configuration Release --output nupkgs
   ```

2. **Publish to NuGet**:
   ```bash
   dotnet nuget push nupkgs/ExeContainer.1.0.0.nupkg --api-key YOUR_API_KEY --source https://api.nuget.org/v3/index.json
   ```

### Method 3: Using Visual Studio

1. **Right-click** on the ExeContainer project
2. Select **Pack**
3. Navigate to the generated `.nupkg` file
4. Use NuGet Package Explorer or command line to publish

## Version Management

To update the package version:

1. **Update Version in Project File**:
   ```xml
   <Version>1.0.1</Version>
   ```

2. **Update Release Notes**:
   ```xml
   <PackageReleaseNotes>Bug fixes and improvements</PackageReleaseNotes>
   ```

3. **Create New Tag**:
   ```bash
   git tag v1.0.1
   git push origin v1.0.1
   ```

## Package Information

- **Package ID**: ExeContainer
- **Authors**: lishuangquan1987
- **License**: MIT
- **Repository**: https://github.com/lishuangquan1987/ExeContainer
- **Tags**: exe, embed, container, winforms, wpf, windows, process

## Troubleshooting

### Common Issues

1. **API Key Invalid**: Ensure your NuGet API key is correct and has publish permissions
2. **Package Already Exists**: Increment the version number before publishing
3. **Build Failures**: Check that all dependencies are properly referenced

### Support

If you encounter issues:
1. Check the GitHub Actions logs
2. Verify your NuGet account permissions
3. Ensure all required files are included in the package

## Security Notes

- Never commit your NuGet API key to the repository
- Use GitHub Secrets for sensitive information
- Regularly rotate your API keys 