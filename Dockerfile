# Use the official .NET SDK image to build the application
# This image contains the .NET SDK and is used for compiling your application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copy the project file and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the application code and build it
COPY . ./
RUN dotnet publish -c Release -o out

# Use the official .NET Runtime image to run the application
# This image contains only the .NET Runtime and is used for running your application
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app

# Copy the compiled application from the build stage
COPY --from=build /app/out ./

# Set the entry point to your application
ENTRYPOINT ["dotnet", "investment-platform.dll"]

# Expose the port the app runs on (optional, depending on your application)
EXPOSE 80
