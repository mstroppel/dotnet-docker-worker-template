# dotnet-docker-worker-template

A `dotnet new` template that scaffolds a **.NET background worker service** packaged as a Docker container, with GitHub Actions workflows to build and publish to GitHub Container Registry (GHCR).

## Install the template

```bash
dotnet new install Rafatz.DotnetDockerWorker
```

## Create a new project

```bash
dotnet new dotnet-docker-worker \
  --DotnetName "Acme.DataSync" \
  --GithubOwner "acme-corp" \
  --GithubName "data-sync-worker"
```

| Parameter | Description | Default |
|---|---|---|
| `--DotnetName` | Full .NET root namespace and project name prefix | `Company.ProjectName` |
| `--GithubOwner` | GitHub username or organization | `github-owner` |
| `--GithubName` | GitHub repository name in kebab-case | `project-name` |

---

## Usage (generated project)

```yaml
services:
  project-name:
    image: ghcr.io/github-owner/project-name:latest
    restart: unless-stopped
    environment:
      - WORKER_DELAY=15
```

## Configuration

| Environment Variable | Description |
|---|---|
| `WORKER_DELAY` | How often the worker runs, in minutes |

## Development

```bash
dotnet restore
dotnet build
dotnet test
```
