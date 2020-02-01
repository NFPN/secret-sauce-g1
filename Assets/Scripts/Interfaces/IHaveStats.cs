namespace Sauce.Interfaces
{
    public interface IHaveStats
    {
        short Health { get; }
        float MoveSpeed { get; }
    }

    public interface IHavePlayerStats : IHaveStats
    {
        short Stamina { get; }
        short Mana { get; }
    }

    public interface IHaveEnemyStats : IHaveStats
    {
        short Level { get; }
    }
}