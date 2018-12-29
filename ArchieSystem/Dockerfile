#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see http://aka.ms/containercompat 

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-sac2016 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk-nanoserver-sac2016 AS build
WORKDIR /src
COPY ArchieSystem/ArchieSystem.csproj ArchieSystem/
RUN dotnet restore ArchieSystem/ArchieSystem.csproj
COPY . .
WORKDIR /src/ArchieSystem
RUN dotnet build ArchieSystem.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish ArchieSystem.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ArchieSystem.dll"]
