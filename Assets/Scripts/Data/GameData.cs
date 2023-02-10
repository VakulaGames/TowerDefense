public struct GameData
{
    public int Money;
    public int[] LevelStars;
    public int[] TowerUpgrades;

    public GameData(int levelCount, int towerCount)
    {
        Money = 0;
        LevelStars = new int[levelCount];
        TowerUpgrades = new int[towerCount];
    }
}
