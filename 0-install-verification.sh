# verify if .NET is installed
cat *.csproj | grep -i "net"
# install Entity framework
echo ' dotnet add package Microsoft.EntityFrameworkCore --version .NETversion(i.e:10.0.0) '
echo 'dotnet add package Microsoft.EntityFrameworkCore.Tools -v 10.0.0'

# verify if Entity framework nad tools are installed

echo 'cat *.csproj | grep -i "EntityFramework"'
echo 'cat *.csproj | grep -i "tools"'
# install dotnet CLI
dotnet tool install --global dotnet-ef
# create migrations 
dotnet ef migrations add FirstMigration
# update migrations 
dotnet ef database update
# remove migrations 
dotnet ef migrations remove