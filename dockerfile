# ===== 1. Build stage =====
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy everything into the image
COPY . .

# Restore dependencies for the project at repo root
RUN dotnet restore "NnBlazorProj.csproj"

# Publish app
RUN dotnet publish "NnBlazorProj.csproj" -c Release -o /app/publish

# ===== 2. Runtime stage =====
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

# Copy published output from build stage
COPY --from=build /app/publish .

# ASP.NET will listen on 0.0.0.0:8080
ENV ASPNETCORE_URLS=http://0.0.0.0:8080

# Expose port 8080 from the container
EXPOSE 8080

# Start the app (DLL name = project name)
ENTRYPOINT ["dotnet", "NnBlazorProj.dll"]