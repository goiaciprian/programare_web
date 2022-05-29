FROM mcr.microsoft.com/dotnet/sdk:6.0 

ENV ASPNETCORE_URLS=http://+:80
RUN apt-get update -y
RUN apt-get install dos2unix -y
RUN dotnet tool install --global dotnet-ef
ENV PATH="${PATH}:/root/.dotnet/tools"

WORKDIR ../
COPY ./ App/

WORKDIR /App
RUN dotnet build --configuration Release
RUN chmod +x "./sync_db.sh"
RUN dos2unix "./sync_db.sh"

EXPOSE 80
ENTRYPOINT ./sync_db.sh dotnet bin/Release/net6.0/FinalAPI.dll