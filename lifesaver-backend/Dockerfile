# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy the entire repository content into the container
COPY . .

# Explicitly restore and build
RUN dotnet restore "lifesaver-backend/lifesaver-backend.csproj"
RUN dotnet publish "lifesaver-backend/lifesaver-backend.csproj" -c Release -o /app/publish

# Stage 2: Runtime (UPDATE THIS LINE)
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "lifesaver-backend.dll"]