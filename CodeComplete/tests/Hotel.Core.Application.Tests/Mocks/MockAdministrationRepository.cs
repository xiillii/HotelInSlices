using Hotel.Core.Application.Contracts.Persistence;
using Hotel.Core.Domain;
using Moq;


namespace Hotel.Core.Application.Tests.Mocks;

public class MockAdministrationRepository
{
  public static Mock<ICheckInRepository> GetMockRepository()
  {


    var mockRepo = new Mock<ICheckInRepository>();

    return mockRepo;
  }
}