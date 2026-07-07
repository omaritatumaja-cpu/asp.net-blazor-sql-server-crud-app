# verify if .NET is installed
cat *.csproj | grep -i "net"
# install Entity framework
echo ' dotnet add package Microsoft.EntityFrameworkCore --version .NETversion(i.e:10.0.0) '
echo 'dotnet add package Microsoft.EntityFrameworkCore.Tools -v 10.0.0'

# verify if Entity framework is installed

echo 'cat *.csproj | grep -i "EntityFramework"'
