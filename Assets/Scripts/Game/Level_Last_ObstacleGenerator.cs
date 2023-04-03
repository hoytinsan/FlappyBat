using UnityEngine;

/// <summary>
/// alttan 3lü üstten 3lü 
/// </summary>
public class Level_Last_ObstacleGenerator : ObstacleGenerator
{
    public Level_Last_ObstacleGenerator(ObstacleGenerator prevOG) : base(prevOG)
    {
        LogManager.levelLogger.Log("level Last");
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
        prevObstacleGenerators.RemoveAt(0);
        return new Level_Last_ObstacleGenerator(this);
    }
}
