using UnityEngine;

/// <summary>
/// bi alttan tek bi üstten tek
/// </summary>
public class Level_2_ObstacleGenerator : ObstacleGenerator
{
    public Level_2_ObstacleGenerator(ObstacleGenerator prevOG) : base(prevOG)
    {
        LogManager.levelLogger.Log("level 2");
    }

    public override void Generate()
    {
        int newRandomNumber = Random.Range(0, 4);
        while ((_randomNumber - newRandomNumber) < 2 && (_randomNumber - newRandomNumber) > -2)
        {
            newRandomNumber = Random.Range(0, 4);
        }
        _randomNumber = newRandomNumber;

        GenerateSingleObstacle();
    }

    public override ObstacleGenerator NextLevel()
    {
        return new Level_3_ObstacleGenerator(this);
    }
}

