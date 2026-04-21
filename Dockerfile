# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app
COPY *.csproj ./
RUN dotnet restore
COPY . ./
RUN dotnet publish -c Release -o out

# Run stage
FROM ://microsoft.com
WORKDIR /app
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "PMWJar.dll"]