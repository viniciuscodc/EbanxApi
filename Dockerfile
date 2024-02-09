# Use the official .NET SDK image as the development image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

# Set the working directory in the container
WORKDIR /app

# Copy the entire project
COPY EbanxApi/ .

# Expose the port that your application will run on
EXPOSE 5159

# Start the application using dotnet run
CMD ["dotnet", "run", "--urls", "http://0.0.0.0:5159"]