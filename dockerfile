# ===== 1. Build stage =====
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy everything and restore dependencies
COPY . .
RUN dotnet restore "NnBlazorProj/NnBlazorProj.csproj"

# Publish app
RUN dotnet publish "NnBlazorProj/NnBlazorProj.csproj" -c Release -o /app/publish

# ===== 2. Runtime stage =====
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

# Copy published output
COPY --from=build /app/publish .

# Expose the port Render will map
EXPOSE 8080

# Render sets PORT env variable automatically  
# We tell ASP.NET to listen on that port
ENV ASPNETCORE_URLS=http://0.0.0.0:${PORT}

# DLL name MUST match your project
ENTRYPOINT ["dotnet", "NnBlazorProj.dll"]