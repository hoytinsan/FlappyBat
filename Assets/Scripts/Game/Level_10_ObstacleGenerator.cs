using UnityEngine;

/// <summary>
/// tekli ve  3lü
/// </summary>
public class Level_10_ObstacleGenerator : ObstacleGenerator
{
    public Level_10_ObstacleGenerator(ObstacleGenerator prevOG) : base(prevOG)
    {
        LogManager.levelLogger.Log("level 10");
    }

    public override void Generate()
    {
        _randomNumber = Random.Range(0, 4);

        GenerateSingleObstacle();


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
        return new Level_11_ObstacleGenerator(this);
    }
}
