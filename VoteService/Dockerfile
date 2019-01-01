#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see http://aka.ms/containercompat 

FROM microsoft/aspnetcore:2.0-nanoserver-sac2016
ARG source
WORKDIR /inetpub/wwwroot
COPY ${source:-obj/Docker/publish} .
