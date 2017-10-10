#!/bin/bash
set -eu -o pipefail

dotnet restore ./PeopleSearch.Web.Api.Tests/PeopleSearch.Web.Api.Tests.csproj
dotnet test ./PeopleSearch.Web.Api.Tests/PeopleSearch.Web.Api.Tests.csproj