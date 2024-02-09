# Ebanx Api test

## Info

Api for Ebanx assignment. Endpoints docs on http://localhost:5159/swagger.

## Setup

Install .Net 6 SDK from microsoft website https://dotnet.microsoft.com/en-us/download/dotnet:

Then run on root directory:

```
dotnet run --project ./EbanxApi/EbanxApi.csproj
```
then make requests to http://localhost:5159.

## Docker setup

Install docker

Then run on root directory:

```
docker build -t dotnet-api-image . && docker run --name dotnet-api -p 5159:5159 dotnet-api-image
```
then make requests to http://localhost:5159.
