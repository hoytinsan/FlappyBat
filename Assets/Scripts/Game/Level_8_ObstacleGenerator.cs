using UnityEngine;

/// <summary>
/// random 3lü
/// </summary>
public class Level_8_ObstacleGenerator : ObstacleGenerator
{
    public Level_8_ObstacleGenerator(ObstacleGenerator prevOG) : base(prevOG)
    {
        LogManager.levelLogger.Log("level 8");
    }

    public override void Generate()
    {
        int newRandomNumber = Random.Range(0, 4);

        GenerateTripleObstacle();
    }

    public override ObstacleGenerator NextLevel()
    {
        return new Level_9_ObstacleGenerator(this);
    }
}

