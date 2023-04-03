using UnityEngine;

/// <summary>
/// alttan 2li üstten 2li
/// </summary>
public class Level_7_ObstacleGenerator : ObstacleGenerator
{
    public Level_7_ObstacleGenerator(ObstacleGenerator prevOG) : base(prevOG)
    {
        LogManager.levelLogger.Log("level 7");
    }

    public override void Generate()
    {
        _randomNumber = Random.Range(0, 4);
        GenerateDoubleObstacle();

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
        return new Level_8_ObstacleGenerator(this);
    }
}

