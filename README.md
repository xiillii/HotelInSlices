# Slices workshop. The Hotel Project. Step by Step

## Create the project Core.Domain

```powershell
dotnet new globaljson --sdk-version 7.0.0
# add "rollForward": "latestFeature" to the json file
md src
cd src
md core
cd core
dotnet new classlib -n Hotel.Core.Domain
cd ..
cd ..
dotnet new sln --name Hotel
dotnet sln add .\src\core\Hotel.Core.Domain\Hotel.Core.Domain.csproj
code .
```

### Create the Domain Entities

1. Create the class `Common\BaseEntity.cs`
1. Create the class `Room.cs`
1. Create the class `CheckInRequest.cs`
1. Create the class `CheckOutRequest.cs`

## Create the project Core.Application

```powershell

cd src\core
dotnet new classlib -n Hotel.Core.Application
cd .\Hotel.Core.Application
dotnet add package AutoMapper
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
dotnet add package FluentValidation
dotnet add package FluentValidation.DependencyInjectionExtensions
dotnet add package MediatR
dotnet add reference ../Hotel.Core.Domain/Hotel.Core.Domain.csproj
cd ..\..\..
dotnet sln add .\src\core\Hotel.Core.Application\Hotel.Core.Application.csproj

```

### Create the Application classes

1. Create the class `ApplicationServiceRegistration.cs`
1. Create the Exception classes
   - `Exceptions\BadRequestException.cs`
   - `Exceptions\NotFoundException.cs`
   - `Exceptions\OccupiedRoomException.cs`
   - `Exceptions\VacantRoomException.cs`
1. Create the Persistence classes
   - `Contracts\Persistence\IGenericRepository.cs`
   - `Contracts\Persistence\IRoomRepository.cs`
1. Create the Features
   - Room
     - Queries
       - GetAvailableRooms
         - `Features\Room\Queries\GetAvailableRooms\RoomDto.cs`
         - `Features\Room\Queries\GetAvailableRooms\GetAvailableRoomQuery.cs`
1. Create the Mapper Profile

   - `MappingProfiles\RoomProfile.cs`

1. Create the Features
   - Room
     - Queries
       - GetAvailableRooms
         - `Features\Room\Queries\GetAvailableRooms\GetAvailableRoomQueryHandler.cs`
1. Create the test for the previous handler. See [Unit Tests](#tests)
1. Continue the Room Feature
   - Room
     - Queries
       - GetRoomDetails
         - `Features\Room\Queries\GetRoomDetails\RoomDetailsDto.cs`
         - Add the Mapper Profile for the previous DTO.
         - `Features\Room\Queries\GetRoomDetails\GetRoomDetailsQuery.cs`
         - `Features\Room\Queries\GetRoomDetails\GetRoomDetailsQueryHandler.cs`
1. Create the test for the previous handler. See [Unit Tests](#tests)
1. Create the Features
   - Room
     - Commands
       - `Features\Room\Commands\CreateRoom\CreateRoomCommand.cs` and its mapper profile
       - `Features\Room\Commands\CreateRoom\CreateRoomCommandValidator.cs`
       - `Features\Room\Commands\CreateRoom\CreateRoomCommandHandler.cs`
1. Create the Unit Test. See [Unit Tests](#tests)
1. Create the Persistence classes
   - `Contracts\Persistence\ICheckInRepository.cs`
   - `Contracts\Persistence\ICheckOutRepository.cs`
1. Create the Room Administration Feature
   - Administration
     - Commands
       - `Features\Administration\Commands\CheckIn\CheckInCommand.cs` and its mapper profile
       - `Features\Administration\Commands\CheckIn\CheckInCommandValidator.cs`
       - `Features\Administration\Commands\CheckIn\CheckInCommandHandler.cs`

## Create the project Infrastructure.Persistence

```powershell
# go to the solution root folder
cd src
md infrastructure
cd infrastructure
dotnet new classlib -n Hotel.Infrastructure.Persistence
cd .\Hotel.Infrastructure.Persistence
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 7.0.14
dotnet add package Microsoft.Extensions.Options.ConfigurationExtensions
dotnet add reference ../../core/Hotel.Core.Domain/Hotel.Core.Domain.csproj
dotnet add reference ../../core/Hotel.Core.Application/Hotel.Core.Application.csproj
cd ..\..\..
dotnet sln add .\src\infrastructure\Hotel.Infrastructure.Persistence\Hotel.Infrastructure.Persistence.csproj

```

### Create the Application classes

# Tests

## Create the Unit Tests Project

```powershell
md tests
cd tests
dotnet new xunit -n Hotel.Core.Application.Tests
cd .\Hotel.Core.Application.Tests\
dotnet add package Moq
dotnet add package Shouldly
dotnet add reference ..\..\src\core\Hotel.Core.Application\Hotel.Core.Application.csproj
cd ..\..
dotnet sln add .\tests\Hotel.Core.Application.Tests\Hotel.Core.Application.Tests.csproj
```

## Add the Mocks

- `Mocks\MockRoomRepository.cs`

## Add Room Feature Unit Tests

- `Features\Room\Queries\GetAvailableRoomQueryHandlerTests.cs`
- `Features\Room\Queries\GetRoomDetailsQueryHandlerTests.cs`
- `Features\Room\Commads\CreateRoomCommandHandlerTests.cs`
