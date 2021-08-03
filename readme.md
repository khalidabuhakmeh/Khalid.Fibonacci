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