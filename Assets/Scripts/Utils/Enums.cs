namespace Sauce.Enums
{
    public enum TileType
    {
        Ground,
        Wall,
    }

    public enum DungeonType
    {
        NONE,
        Castle,
        Snow,
        Lava,
        Desert,
        Town,
    }

    public enum Direction4
    {
        NONE,
        UP,
        DOWN,
        RIGHT,
        LEFT,
    }

    public enum Direction8
    {
        NONE,
        UP,
        DOWN,
        RIGHT,
        LEFT,
        UPLEFT,
        UPRIGHT,
        DOWNLEFT,
        DOWNRIGHT,
    }

    public enum TAG
    {
        Player,
        Enemy,
        Tile,
    }

    public enum EnemyType
    {
        Minion,
        Normal,
        Hard,
        Boss
    }
}