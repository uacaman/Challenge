@echo off
setlocal

:: Change to the directory where the batch file is located
cd /d "%~dp0"

:: Set image name and tag
set IMAGE_NAME=challenge
set TAG=dev

:: Set build context directory to the parent directory
set BUILD_CONTEXT=.

:: Path to the Dockerfile
set DOCKERFILE_PATH=Challenge\Dockerfile
:: Get the absolute path to the Challenge folder
for /f "delims=" %%i in ('cd') do set ABSOLUTE_PATH=%%i\Challenge

:: Check if an existing container is running and stop it
echo Checking for running container...
for /f "tokens=*" %%i in ('docker ps -q --filter "ancestor=%IMAGE_NAME%:%TAG%"') do (
    echo Stopping and removing existing container with ID %%i...
    docker stop %%i
    docker rm %%i
)

:: Build the Docker image
echo Building Docker image...
docker build -f "%DOCKERFILE_PATH%" --force-rm -t %IMAGE_NAME%:%TAG% "%BUILD_CONTEXT%"

if %ERRORLEVEL% neq 0 (
    echo Failed to build Docker image
    pause
    exit /b %ERRORLEVEL%
)

echo Docker image built successfully

:: Run the Docker container with environment variable and volume mount
echo Running Docker container...
docker run --rm -p 8080:8080 -p 8081:8081 -e DB_PATH="/data" -v "%ABSOLUTE_PATH%:/data" %IMAGE_NAME%:%TAG%

if %ERRORLEVEL% neq 0 (
    echo Failed to run Docker container
    pause
    exit /b %ERRORLEVEL%
)


endlocal