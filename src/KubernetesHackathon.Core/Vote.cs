namespace KubernetesHackathon.Core;

public sealed class Vote
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
}
