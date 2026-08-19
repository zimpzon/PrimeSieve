FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY PrimeSieve/PrimeSieve.csproj PrimeSieve/
RUN dotnet restore PrimeSieve/PrimeSieve.csproj

COPY PrimeSieve/ PrimeSieve/
WORKDIR /src/PrimeSieve
RUN dotnet publish -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "PrimeSieve.dll"]
