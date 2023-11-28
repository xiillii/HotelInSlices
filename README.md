# Slices workshop. The Hotel Project

## Create the project Core.Domain

```powershell

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
1. Create the Features
   - Room
     - Queries
       - `Features\Room\Queries\GetAvailableRooms\RoomDto.cs`
       - `Features\Room\Queries\GetAvailableRooms\GetAvailableRoomQuery.cs`
       - `Features\Room\Queries\GetAvailableRooms\GetAvailableRoomQueryHandler.cs`
1. Create the Persistence classes
   - `Contracts\Persistence\IGenericRepository.cs`
   - `Contracts\Persistence\IRoomRepository.cs`
1. Create the Features
   - Room
     - Commands
   - Room Administration
