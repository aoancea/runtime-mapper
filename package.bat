msbuild src\Runtime.Mapper.sln /t:Rebuild /p:Configuration=Release /p:Platform="Any CPU"
nuget pack Runtime.Mapper.nuspec

#https://docs.microsoft.com/en-us/nuget/create-packages/creating-a-package