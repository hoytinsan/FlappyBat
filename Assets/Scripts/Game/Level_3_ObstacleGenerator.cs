using UnityEngine;

/// <summary>
/// üstten tekli alttan tekli
/// </summary>
public class Level_3_ObstacleGenerator : ObstacleGenerator
{
    public Level_3_ObstacleGenerator(ObstacleGenerator prevOG) : base(prevOG)
    {
        LogManager.levelLogger.Log("level 3");
    }

    public override void Generate()
    {
        _randomNumber = Random.Range(0, 2);
        GenerateSingleObstacle();
        _randomNumber = Random.Range(2, 4);
        GenerateSingleObstacle();
    }

    public override ObstacleGenerator NextLevel()
    {
        return new Level_4_ObstacleGenerator(this);
    }
}

