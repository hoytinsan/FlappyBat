using UnityEngine;

/// <summary>
/// 3lü ve 2li
/// </summary>
public class Level_11_ObstacleGenerator : ObstacleGenerator
{
    public Level_11_ObstacleGenerator(ObstacleGenerator prevOG) : base(prevOG)
    {
        LogManager.levelLogger.Log("level 11");
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

        GenerateTripleObstacle();
    }

    public override ObstacleGenerator NextLevel()
    {
        prevObstacleGenerators.RemoveAt(1);
        return new Level_12_ObstacleGenerator(this);
    }
}
