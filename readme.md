# Build, Test, and Publish .NET Project

## Step 1. Write a Solution

In this example, I'm building a straightforward library that generates a series of Fibonnaci numbers. I also have a unit test project to test that the sequence generated is correct.

## Step 2. Create a Git Repository

Once the project is written, I have setup a Git repository and committed my initial commit.

## Step 3. Install MinVer to Library Project

I will be using [`MinVer`](https://github.com/adamralph/minver) to track version numbers by git tags. It's normally the easiest way to keep track of simple libraries like this without having to mess with the `csproj` constantly.

## Step 4. Add NuGet Package Info in Csproj

```xml
<!-- add to top group -->
<PropertyGroup>
    <!-- NuGet Package Information -->
    <PackageId>Khalid.Fibonacci</PackageId>
    <PackageLicenseExpression>MIT</PackageLicenseExpression>
    <PackageTags>Fibonnaci</PackageTags>
    <IsPackable>true</IsPackable>
    <Description>Iterator for Fibonacci sequence</Description>
</PropertyGroup>
```

## Step 5. Add .github workflows for build and publish

### Build

```yaml
name: Build & Test

on:
  push:
    branches: [ main ]
  pull_request:
    branches: [ main ]

jobs:
  build:

    runs-on: ubuntu-latest

    steps:
      - uses: actions/checkout@v2
      - name: Setup .NET
        uses: actions/setup-dotnet@v1
        with:
          dotnet-version: 5.0.x
      - name: Restore dependencies
        run: dotnet restore
      - name: Build
        run: dotnet build --no-restore
      - name: Test
        run: dotnet test --no-build --verbosity normal
```

### Publish

```yaml
name: Publish

on:
  push:
    tags:
      - '**'

jobs:
  build:

    runs-on: ubuntu-latest

    steps:
      - uses: actions/checkout@v2
      - name: Setup .NET
        uses: actions/setup-dotnet@v1
        with:
          dotnet-version: 5.0.x
      - name: Restore dependencies
        run: dotnet restore
      - name: Build
        run: dotnet build --no-restore
      - name: Test
        run: dotnet test --no-build --verbosity normal
      - name: Pack
        run: dotnet pack -o ./nupkgs --no-restore --no-build
      - name: Publish
        run: dotnet nuget push ./nupkgs/*.nupkg --api-key ${{secrets.NugetApiKey}}  --skip-duplicate -s https://api.nuget.org/v3/index.json
```

## Step 6. Add NuGet API Key from NuGet.org Account

Go to [NuGet](https://nuget.org) and get a key.

## Step 7. Add A Tag and Push

Add a tag and push. This should trigger the `publish` workflow. Tags should be in the format of `0.0.0` to be recognized by MinVer.