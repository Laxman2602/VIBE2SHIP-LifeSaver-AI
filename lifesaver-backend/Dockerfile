# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy everything
COPY . .

# Explicitly restore the project
RUN dotnet restore "lifesaver-backend.csproj"

# Build and Publish
RUN dotnet publish "lifesaver-backend.csproj" -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

# The command to run your app
ENTRYPOINT ["dotnet", "lifesaver-backend.dll"]