## How to run

Docker Desktop for Windows is required, it can be download from [here](https://hub.docker.com/editions/community/docker-ce-desktop-windows/) . If you are running Windows Home, please follow the instructions located [here](https://docs.docker.com/docker-for-windows/install-windows-home/) .

Once Docker is installed on the machine you need to:

``` powershell
docker-compose build
docker-compose up
````

API would be accessible on port 5000

Database would be accessible on port 6642

## Content

The author has tried to demonstrate 3 areas of know-how via the current work.

1. Docker Compose
   1. Demonstrate use of privately build images (API) and publicly available images (SQLServer)
   2. Demonstrate networking and volume knowledge
2. API & Shared
   1. Demonstrate architecture knowledge (DDD, extracting commonly used code outside of the solution, structuring)
   2. Demonstrate API building knowledge
3. API.Tests
   1. Demonstrate basic unit testing of our controllers
   2. Demonstrate mocking with Moq