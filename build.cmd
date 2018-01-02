cd src/Thrifty.Web

call yarn install

cd ../..

echo hello


dotnet publish src\Thrifty.Web\Thrifty.Web.csproj -o ..\..\publish -v m