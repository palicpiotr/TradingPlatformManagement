FROM microsoft/aspnetcore:2.0-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0-nanoserver-1709 AS build
WORKDIR /src
COPY Platform.TradingManagement/Platform.TradingManagement.csproj Platform.TradingManagement/
RUN dotnet restore Platform.TradingManagement/Platform.TradingManagement.csproj
COPY . .
WORKDIR /src/Platform.TradingManagement
RUN dotnet build Platform.TradingManagement.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Platform.TradingManagement.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Platform.TradingManagement.dll"]
