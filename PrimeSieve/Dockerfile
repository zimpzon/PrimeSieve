FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY PrimeSieve/PrimeSieve.csproj PrimeSieve/
COPY PrimeSieveLib/PrimeSieveLib.csproj PrimeSieveLib/

RUN dotnet restore PrimeSieve/PrimeSieve.csproj

COPY PrimeSieve/ PrimeSieve/
COPY PrimeSieveLib/ PrimeSieveLib/

RUN dotnet publish PrimeSieve/PrimeSieve.csproj \
    -c Release \
    -o /app/publish \
    --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "PrimeSieve.dll"]
