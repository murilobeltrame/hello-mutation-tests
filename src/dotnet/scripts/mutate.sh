dotnet stryker -s HelloMutation.sln
LATEST_RUN=$(ls -td StrykerOutput/* | head -1)
open `$LATEST_RUN/reports/mutation-report.html`