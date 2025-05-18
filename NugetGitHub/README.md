# NugetGitHub
Publish a nuget package in GitHub and consume it in other solutions

## STEP 1: Publish nuget package to GitHub
- In your `dotnet solution`
  - Right-click `dotnet project` > Select `Properties` > In the left menu, select `Package` > Under `Generate NuGet package on build` option, tick the checkbox `Produce a package file during build operations.` > Build the project
- In your `GitHub Account`
  - Go to `Settings` > In the left menu, select `Developer Settings` > Under `Personal access tokens` > choose `Tokens (classic)` > click `Generate new token (classic)` button > confirm your password > choose scopes `write:packages | read:packages` > click `Generate token` button > grab a copy of your newly generated PAT and store it safely somewhere
- Create a `nuget.config` file
  - Back in your dotnet solution, right-click your dotnet solution > Create a new item using a text file template and give it a name `nuget.config` > Add the following with your previous generated PAT as follows:
  ```
  <?xml version="1.0" encoding="utf-8"?>
  <configuration>
    <packageSources>
      <clear />
      <add key="github" value="https://nuget.pkg.github.com/{GITHUB USERNAME}/index.json" />
    </packageSources>
    <packageSourceCredentials>
      <github>
        <add key="Username" value="{GITHUB USERNAME}" />
        <add key="ClearTextPassword" value="{PERSONAL ACCESS TOKEN}" />
      </github>
    </packageSourceCredentials>
  </configuration>
  ``` 

- Build and publish the nuget package
  - In your `dotnet solution`
    - Right-click `dotnet project` > Select `Properties` > In the left menu, select `Package`
      - Provide a `repository url`
      - Provide a `Title` and `Description`
      - Provide `Release Notes`
      - Change `Package Version` to `0.0.1` (for debug package)
    - Build the dotnet project
      - This creates a nuget package file called `NugetGitHub.Common.0.0.1.nupkg`
    - Open `Package Manager Console`
      - cd to the path of the dotnet project
      - Run the following command `dotnet nuget push ".\bin\debug\NugetGitHub.Common.0.0.1.nupkg" --source "github"`. This will push the nuget package to your github repository packages

## STEP 2: Consume the nuget package
- Choose nuget package source `github` in `NugetGitHub.App` project's Nuget Package Manager
  - Install the `NugetGitHub.Common` package
  - Try to call `{someString}.IsEmailValid()`

