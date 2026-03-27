# dotnet-docker-worker-template

A `dotnet new` template package that scaffolds a production-ready **.NET background worker service** in Docker, including GitHub Actions workflows for CI and container publishing.

## Install

Install from NuGet:

```bash
dotnet new install Rafatz.DotnetDockerWorker
```

Uninstall:

```bash
dotnet new uninstall Rafatz.DotnetDockerWorker
```

## Create a New Worker Project

```bash
dotnet new dotnet-docker-worker \
	--DotnetName "Acme.DataSync" \
	--GithubOwner "acme-corp" \
	--GithubName "data-sync-worker"
```

## Template Parameters

| Parameter       | Description                                      | Default               |
| --------------- | ------------------------------------------------ | --------------------- |
| `--DotnetName`  | Full .NET root namespace and project name prefix | `Company.ProjectName` |
| `--GithubOwner` | GitHub username or organization                  | `github-owner`        |
| `--GithubName`  | GitHub repository name in kebab-case             | `project-name`        |

`DotnetShortName` is generated from the last segment of `DotnetName` and used in class names and file renames.

## What the Generated Project Includes

- .NET 10 worker service using `BackgroundService`
- Fail-fast config binding for `WORKER_DELAY`
- Structured JSON console logging (`AddJsonConsole`)
- Multi-stage Dockerfile (SDK build image + runtime image)
- `docker-compose.yml` prefilled with a GHCR image name
- GitHub Actions workflows:
	- PR validation (`restore`, `build`, `test`)
	- Docker image build and push to GHCR
	- NuGet publish workflow (release-triggered)
- xUnit test project scaffold with AutoFixture, AutoMoq, Moq, and coverlet
- `.slnx` solution file

## Run the Generated Worker

Run with Docker Compose:

```bash
docker compose up -d
```

Or run directly with .NET:

```bash
dotnet restore
dotnet build
dotnet test
dotnet run --project src/Acme.DataSync.Worker/Acme.DataSync.Worker.csproj
```

## Configuration

The worker reads configuration from environment variables:

| Variable       | Description                             | Example |
| -------------- | --------------------------------------- | ------- |
| `WORKER_DELAY` | Delay between worker cycles, in minutes | `15`    |

## Repository Layout

- `Rafatz.DotnetDockerWorker.csproj`: template package project
- `README.nuget.md`: NuGet package readme
- `templates/dotnet-docker-worker`: template source content

## Local Template Development

Pack the template locally:

```bash
dotnet pack Rafatz.DotnetDockerWorker.csproj --configuration Release --output ./nupkg
```

Install from the generated package:

```bash
dotnet new install ./nupkg/Rafatz.DotnetDockerWorker.1.0.0.nupkg
```

After changes, reinstall by uninstalling first (or use a newer version number):

```bash
dotnet new uninstall Rafatz.DotnetDockerWorker
dotnet new install ./nupkg/Rafatz.DotnetDockerWorker.1.0.0.nupkg
```

## License

MIT
