using System.Collections;
using UnityEngine;

public class ParallaxItem : MonoBehaviour
{
	public Vector3 InitialPosition;

	private ParallaxLayer _parallaxLayer;
    private RectTransform _rectTransform;

	void Awake()
	{
		_parallaxLayer = transform.parent.GetComponent<ParallaxLayer>();
        _rectTransform = transform.GetComponent<RectTransform>();
	}

	public void InitializeParallaxItem()
	{

        if (!ParallaxManager.Instance.IsInitialized)
        {
	        InitialPosition = new Vector3(_parallaxLayer.LastItemRight, _rectTransform.anchoredPosition.y);
		}
		_rectTransform.anchoredPosition = InitialPosition;

		_parallaxLayer.LastItemRight = _rectTransform.anchoredPosition.x + _rectTransform.rect.width - 2;
	}

	void OnBecameInvisible()
	{
	    if (gameObject.activeInHierarchy)
        {
            StartCoroutine("PushToEnd");
	    }
	}

    public IEnumerator PushToEnd()
    {
        yield return new WaitForSeconds(1f);
     
        if (Game.Current.IsGameOn)
		{
			_rectTransform.anchoredPosition = new Vector3(_parallaxLayer.LastItemRight, _rectTransform.anchoredPosition.y);
			_parallaxLayer.LastItemRight += _rectTransform.rect.width - 2;
		}
    }

	public void Reset()
	{
		_rectTransform.anchoredPosition = InitialPosition;
		_parallaxLayer.LastItemRight += _rectTransform.rect.width - 2;
	}
}
