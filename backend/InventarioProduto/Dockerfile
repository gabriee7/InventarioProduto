FROM mcr.microsoft.com/dotnet/sdk:9.0 AS sdk-base
WORKDIR /app

COPY InventarioProduto.sln ./
COPY InventarioProduto/ ./InventarioProduto/

ENV NUGET_PACKAGES_PATH=/usr/share/nuget/packages
RUN dotnet restore InventarioProduto.sln \
    --runtime linux-x64 \
    --packages ${NUGET_PACKAGES_PATH} \
    --force-evaluate


FROM sdk-base AS build-api
WORKDIR /app/InventarioProduto
RUN dotnet publish InventarioProduto.csproj \
    -c Release \
    -o /app/publish \
    --no-restore \
    --runtime linux-x64 \
    /p:UseAppHost=false \
    /p:DisableImplicitNuGetFallbackFolder="true"


FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final-api
WORKDIR /app
ENV LANG C.UTF-8
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
COPY --from=build-api /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "InventarioProduto.dll"]
