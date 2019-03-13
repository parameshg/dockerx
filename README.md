# DockerX

This tool implements extension commands and convinience helpers for Docker.

## Setup

This tool is implemented using C# and DotNet Core v2.2 and hence can be cross-complied to Windows, Linux and Mac. The tool expects an environment variable "DOCKER_ENDPOINT" to be setup for targetting a docker runtime or host.

```
setx DOCKER_ENDPOINT tcp://localhost:2375
```

## Commands

**Image Cleaning**

This commands removes all unnamed and untagged images.

```
dockerx image clean
```
