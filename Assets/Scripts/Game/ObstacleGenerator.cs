using System.Collections.Generic;
using UnityEngine;

public abstract class ObstacleGenerator
{
    protected int _randomNumber;
    public List<ObstacleGenerator> prevObstacleGenerators;
        
    public ObstacleGenerator(ObstacleGenerator prevOG)
    {
        if (!Object.ReferenceEquals(prevOG,null))
        {
            prevObstacleGenerators = new List<ObstacleGenerator>();
            if (!Object.ReferenceEquals(prevOG.prevObstacleGenerators, null))
            {
                prevObstacleGenerators = prevOG.prevObstacleGenerators;
            }
            prevObstacleGenerators.Add(prevOG);


        }
    }

    public void GenerateFromPreviousOG()
    {
        if (!Object.ReferenceEquals(prevObstacleGenerators, null))
        {
            int randomLevel = Random.Range(0, prevObstacleGenerators.Count - 1);
            prevObstacleGenerators[randomLevel].Generate();
        }
    }
    public abstract void Generate();
    public abstract ObstacleGenerator NextLevel();

    protected void GenerateSingleObstacle()
    {
        switch (_randomNumber)
        {
            case 0: PoolManager.Spawn("bottom_obstacle_1").GetComponent<Obstacle>().Generate(); break;
            case 1: PoolManager.Spawn("bottom_obstacle_2").GetComponent<Obstacle>().Generate(); break;
            case 2: PoolManager.Spawn("top_obstacle_1").GetComponent<Obstacle>().Generate(); break;
            case 3: PoolManager.Spawn("top_obstacle_2").GetComponent<Obstacle>().Generate(); break;
        }
    }

    protected void GenerateDoubleObstacle()
    {
        _randomNumber = _randomNumber / 2 + 4; 

        switch (_randomNumber)
        {
            case 4: PoolManager.Spawn("bottom_obstacle_3").GetComponent<Obstacle>().Generate(); break;
            case 5: PoolManager.Spawn("top_obstacle_3").GetComponent<Obstacle>().Generate(); break;
        }

        _randomNumber = (_randomNumber - 4) * 2;
    }

    protected void GenerateTripleObstacle()
    {
        _randomNumber = _randomNumber / 2 + 6;

        switch (_randomNumber)
        {
            case 6: PoolManager.Spawn("bottom_obstacle_4").GetComponent<Obstacle>().Generate(); break;
            case 7: PoolManager.Spawn("top_obstacle_4").GetComponent<Obstacle>().Generate(); break;
        }

        _randomNumber = (_randomNumber - 6) * 2;
    }
}