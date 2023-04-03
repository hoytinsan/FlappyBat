using UnityEngine;

/// <summary>
/// tek ve 2li
/// </summary>
public class Level_6_ObstacleGenerator : ObstacleGenerator
{
    public Level_6_ObstacleGenerator(ObstacleGenerator prevOG) : base(prevOG)
    {
        LogManager.levelLogger.Log("level 6");
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

        GenerateDoubleObstacle();
    }

    public override ObstacleGenerator NextLevel()
    {
        return new Level_7_ObstacleGenerator(this);
    }
}

