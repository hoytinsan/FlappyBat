using UnityEngine;

/// <summary>
/// bi üstten 3lü bi alttan 3lü
/// </summary>
public class Level_9_ObstacleGenerator : ObstacleGenerator
{
    public Level_9_ObstacleGenerator(ObstacleGenerator prevOG) : base(prevOG)
    {
        LogManager.levelLogger.Log("level 9");
    }

    public override void Generate()
    {
        int newRandomNumber = Random.Range(0, 4);
        while ((_randomNumber - newRandomNumber) < 2 && (_randomNumber - newRandomNumber) > -2)
        {
            newRandomNumber = Random.Range(0, 4);
        }
        _randomNumber = newRandomNumber;

        GenerateTripleObstacle();
    }

    public override ObstacleGenerator NextLevel()
    {
        prevObstacleGenerators.RemoveAt(0);
        return new Level_10_ObstacleGenerator(this);
    }
}
