FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

# Copy everything
COPY ./src/ApiGateways/OcelotApiGw/OcelotApiGw.csproj .
# Restore as distinct layers
RUN dotnet restore "OcelotApiGw.csproj"

COPY ./src/ApiGateways/OcelotApiGw/. .
# Build and publish a release
RUN dotnet publish "OcelotApiGw.csproj" -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "OcelotApiGw.dll"]