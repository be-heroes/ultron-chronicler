namespace Application.Commands.Pod;

public sealed class CreateDomainObjectCommandHandler(IPodService podService) : ICommandHandler<CreatePodMetricsCommand, PodMetrics>
{
    private readonly IPodService _podService = podService ?? throw new ArgumentNullException(nameof(podService));

    public async Task<PodMetrics> Handle(CreatePodMetricsCommand command, CancellationToken cancellationToken = default)
    {
        return await _podService.AddOrUpdatePodMetricsAsync(command.EntityId, command.Label, command.PodSelector, command.CpuUsage, command.MemoryUsage, cancellationToken);
    }
}