# project-name

A lightweight .NET background worker service running inside a Docker container.

## Usage

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
