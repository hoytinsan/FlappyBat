using UnityEngine;

/// <summary>
/// bi alttan 2li bi üstten 2li
/// </summary>
public class Level_5_ObstacleGenerator : ObstacleGenerator
{
    public Level_5_ObstacleGenerator(ObstacleGenerator prevOG) : base(prevOG)
    {
        LogManager.levelLogger.Log("level 5");
    }

    public override void Generate()
    {
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
        return new Level_6_ObstacleGenerator(this);
    }
}

