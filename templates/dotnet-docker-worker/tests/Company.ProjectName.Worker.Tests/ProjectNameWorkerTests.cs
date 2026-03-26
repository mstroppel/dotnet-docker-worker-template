using AutoFixture;
using AutoFixture.AutoMoq;
using Microsoft.Extensions.Options;
using Moq;

namespace Company.ProjectName.Worker.Tests;

public class ProjectNameWorkerTests
{
    private readonly IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());
    private readonly Mock<IOptions<ProjectNameSettings>> _optionsMock;
    private readonly ProjectNameSettings _settings;
    private readonly ProjectNameWorker _sut;

    public ProjectNameWorkerTests()
    {
        _optionsMock = _fixture.Freeze<Mock<IOptions<ProjectNameSettings>>>();

        _settings = _fixture.Build<ProjectNameSettings>()
            .With(x => x.WorkerDelay, 60)
            .Create();

        _optionsMock.Setup(x => x.Value).Returns(_settings);

        _sut = _fixture.Create<ProjectNameWorker>();
    }

}
