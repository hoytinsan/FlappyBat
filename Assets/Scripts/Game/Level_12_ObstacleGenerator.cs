using UnityEngine;

/// <summary>
/// alttan 3lü üstten 3lü
/// </summary>
public class Level_12_ObstacleGenerator : ObstacleGenerator
{
    public Level_12_ObstacleGenerator(ObstacleGenerator prevOG) : base(prevOG)
    {
        LogManager.levelLogger.Log("level 12");
    }

    public override void Generate()
    {
        _randomNumber = Random.Range(0, 4);

        GenerateTripleObstacle();


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
        prevObstacleGenerators.RemoveAt(1);
        return new Level_Last_ObstacleGenerator(this);
    }
}
