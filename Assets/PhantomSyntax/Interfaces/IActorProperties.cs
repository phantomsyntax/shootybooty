public interface IActorProperties
{
    int SendDamage();

    void TakeDamage(int incomingDamage);
    void Die();
    void PopulateStats(SOActorObject actorObject);
}