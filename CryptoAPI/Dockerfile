#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see http://aka.ms/containercompat 

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 54532
EXPOSE 44373

FROM microsoft/dotnet:2.1-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY CryptoAPI/CryptoAPI.csproj CryptoAPI/
RUN dotnet restore CryptoAPI/CryptoAPI.csproj
COPY . .
WORKDIR /src/CryptoAPI
RUN dotnet build CryptoAPI.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish CryptoAPI.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CryptoAPI.dll"]
