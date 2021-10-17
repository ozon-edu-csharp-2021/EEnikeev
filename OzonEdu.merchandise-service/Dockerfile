FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/OzonEdu.merchandise-service/OzonEdu.merchandise-service.csproj","src/OzonEdu.merchandise-service/"]
RUN dotnet restore "src/OzonEdu.merchandise-service/OzonEdu.merchandise-service.csproj"
Copy . .
WORKDIR "/src/src/OzonEdu.merchandise-service"
RUN dotnet build "OzonEdu.merchandise-service.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "OzonEdu.merchandise-service.csproj" -c Release -o /app/publish
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime
WORKDIR /app
EXPOSE 80
FROM runtime AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet","OzonEdu.merchandise-service.dll"]
