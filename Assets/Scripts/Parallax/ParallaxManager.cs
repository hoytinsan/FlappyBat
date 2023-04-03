using UnityEngine;
using System.Collections.Generic;

public class ParallaxManager : MonoBehaviour
{
	public float BaseSpeed = 4;
    public bool IsInitialized= false;
    public List<ParallaxLayer> Layers;

    void Start()
    {
        InitializeParallaxManager();
    }

	public float GetBaseSpeed()
	{
		return BaseSpeed;
	}

	public void SetBaseSpeed(float speed)
	{
		BaseSpeed = speed;
	}

    public void InitializeParallaxManager()
    {
        for (int i = 0; i < Layers.Count; i++)
        {
            Layers[i].InitializeParallaxLayer();
        }
        IsInitialized = true;
    }

    public void Reset()
    {
        for (int i = 0; i < Layers.Count; i++)
        {
            if (!Object.ReferenceEquals(Layers[i], null))
            {
                Layers[i].Reset();
            }
        }
    }

	#region Singleton
	private static ParallaxManager _instance;

	public static ParallaxManager Instance
	{
        get { return _instance ?? (_instance = (ParallaxManager)FindObjectOfType(typeof(ParallaxManager))); }
	}
	#endregion
}
