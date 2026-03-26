# Rafatz.DotnetDockerWorker

A `dotnet new` template that scaffolds a complete **.NET background worker service** packaged as a Docker container, with GitHub Actions workflows ready to build and publish to GitHub Container Registry (GHCR).

## Install

```bash
dotnet new install Rafatz.DotnetDockerWorker
```

## Usage

```bash
dotnet new dotnet-docker-worker \
  --DotnetName "Acme.DataSync" \
  --GithubOwner "acme-corp" \
  --GithubName "data-sync-worker"
```

### Parameters

| Parameter | Description | Default |
|---|---|---|
| `--DotnetName` | Full .NET root namespace and project name prefix | `Company.ProjectName` |
| `--GithubOwner` | GitHub username or organization | `github-owner` |
| `--GithubName` | GitHub repository name in kebab-case | `project-name` |

`DotnetShortName` (the last segment of `DotnetName`) is derived automatically and used for class names.

## What you get

| Component | Description |
|---|---|
| **BackgroundService** | `while (!stoppingToken.IsCancellationRequested)` loop on a configurable minute interval |
| **Fail-fast config binding** | `WORKER_DELAY` env var read at startup via `GetValueOrThrow` extension |
| **JSON structured logging** | `AddJsonConsole()` — ready for log aggregation in containerized environments |
| **Multi-stage Dockerfile** | SDK image for build, minimal runtime image for the final artifact |
| **docker-compose.yml** | Pre-populated with your GHCR image URL |
| **GitHub Actions — PR Check** | Restore, build, and test on every PR to `main` |
| **GitHub Actions — Docker Publish** | Push `sha-*` + `latest` on merge to `main`; full semver + `stable` on GitHub Release |
| **xUnit v3 test project** | Pre-wired with AutoFixture, AutoMoq, FluentAssertions, Moq, and coverlet |
| **Modern `.slnx` solution** | Surfaces CI workflows and repo files as IDE solution items |

## Uninstall

```bash
dotnet new uninstall Rafatz.DotnetDockerWorker
```

## License

MIT — Copyright (c) 2026 Marco Stroppel
