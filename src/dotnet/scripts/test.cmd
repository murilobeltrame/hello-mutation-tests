dotnet test --collect:"XPlat Code Coverage"
dotnet reportgenerator "-reports:HelloMutation.Domain.Tests\TestResults\*\coverage.cobertura.xml" "-targetdir:coveragereport" -reporttypes:Html
start "" "coveragereport\index.html"