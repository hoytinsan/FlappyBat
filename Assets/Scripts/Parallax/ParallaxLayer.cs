using System.Collections.Generic;
using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
	public float LayerSpeed;
    public List<ParallaxItem> ParallaxItems; 

	public float LastItemRight;

	private Vector3 _cameraLeftCornerPosition;

    void Awake()
    {
        ParallaxManager.Instance.Layers.Add(this);
    }

    void FixedUpdate()
    {
        transform.position -= new Vector3(ParallaxManager.Instance.BaseSpeed * LayerSpeed, 0f, 0f);
    }

	public void InitializeParallaxLayer()
	{
        transform.localPosition = new Vector3(0, transform.localPosition.y, transform.localPosition.z);
        
        LastItemRight = 0;

	    foreach (ParallaxItem parallaxItem in ParallaxItems)
	    {
	        parallaxItem.InitializeParallaxItem();
	    }
	}

    public void Reset()
    {
        transform.localPosition = new Vector3(0, transform.localPosition.y, transform.localPosition.z);

        LastItemRight = 0;

        foreach (ParallaxItem parallaxItem in ParallaxItems)
        {
            parallaxItem.Reset();
        }
    }
}
