# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
# Set the workdir to the subfolder where your .csproj actually lives
WORKDIR /src/lifesaver-backend

# Copy everything from the current folder into the container
COPY . .

# Now this will work because we are in the right folder
RUN dotnet restore "lifesaver-backend.csproj"
RUN dotnet publish "lifesaver-backend.csproj" -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "lifesaver-backend.dll"]