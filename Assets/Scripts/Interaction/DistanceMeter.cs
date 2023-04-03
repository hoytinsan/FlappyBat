using UnityEngine;

public class DistanceMeter : MonoBehaviour 
{
    public int Distance;

    void OnEnable()
    {
        Distance = 0;
    }

    void FixedUpdate()
    {
        if (transform.localPosition.x / 100 != Distance)
        {
            Distance = (int) (transform.localPosition.x / 500);
            Game.Current.Distance = (-Distance);
        }
    }
}
