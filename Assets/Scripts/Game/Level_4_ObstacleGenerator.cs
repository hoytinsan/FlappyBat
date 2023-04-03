using UnityEngine;

/// <summary>
/// random 2li
/// </summary>
public class Level_4_ObstacleGenerator : ObstacleGenerator
{
    public Level_4_ObstacleGenerator(ObstacleGenerator prevOG) : base(prevOG)
    {
        LogManager.levelLogger.Log("level 4");
    }

    public override void Generate()
    {
        _randomNumber = Random.Range(0, 4);
        GenerateDoubleObstacle();
    }

    public override ObstacleGenerator NextLevel()
    {
        return new Level_5_ObstacleGenerator(this);
    }
}

