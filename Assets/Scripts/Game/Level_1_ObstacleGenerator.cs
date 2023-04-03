using UnityEngine;

/// <summary>
/// Random Tek
/// </summary>
public class Level_1_ObstacleGenerator : ObstacleGenerator
{
    public Level_1_ObstacleGenerator(ObstacleGenerator prevOG) : base(prevOG)
    {
        LogManager.levelLogger.Log("level 1");
    }

    public override void Generate()
    {
        _randomNumber = Random.Range(0, 4);

        GenerateSingleObstacle();
    }

    public override ObstacleGenerator NextLevel()
    {
        return new Level_2_ObstacleGenerator(this);
    }
}
