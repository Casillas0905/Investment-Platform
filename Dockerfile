# Use the .NET 6 SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Set the working directory inside the container
WORKDIR /app

# Copy the solution and project files into the container
COPY *.sln ./
COPY HttpRequest/HttpRequest.csproj HttpRequest/
COPY Test-methods/Test-methods.csproj Test-methods/

# Restore the dependencies for both projects
RUN dotnet restore

# Copy the rest of the application code
COPY . .

# Build the solution
RUN dotnet build -c Release -o /app/build

# Publish the application
RUN dotnet publish -c Release -o /app/publish

# Use the .NET 6 ASP.NET runtime image for the final image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime

# Set the working directory inside the runtime container
WORKDIR /app

# Copy the published output from the build stage
COPY --from=build /app/publish .

# Define the entry point for the application
ENTRYPOINT ["dotnet", "HttpRequest.dll"]

# Expose port if needed (e.g., for web applications)
EXPOSE 80
