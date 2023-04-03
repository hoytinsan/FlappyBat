using System.Collections;
using UnityEngine;

public class Obstacle : Explosive
{
    private Transform _obstacleLayerTransform;
    private RectTransform _rectTransform;
    private float _maxHeight;
    private float _minHeight;
    private Vector2 initialPos;

    void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        initialPos = _rectTransform.anchoredPosition;

        if (tag.Equals("TopObstacle"))
        {
            _minHeight = _rectTransform.anchoredPosition.y;
            _maxHeight = _rectTransform.anchoredPosition.y + (_rectTransform.sizeDelta.y / 3);

        }
        else
        {
            _maxHeight = _rectTransform.anchoredPosition.y;
            _minHeight = _rectTransform.anchoredPosition.y - (_rectTransform.sizeDelta.y / 3);
        }

        _obstacleLayerTransform = ParallaxManager.Instance.transform.Find("Layer Obstacle");
    }

    void OnEnable()
    {
        Appear();
    }

    void OnBecameInvisible()
    {
        Game.Current.ActiveObstacles.Remove(this);

        DespawnDirectly();
    }

    void OnBecameVisible()
    {
        Game.Current.ActiveObstacles.Add(this);
    }

    public void Despawn()
    {
        if (gameObject.activeInHierarchy)
        {
            if (transform.GetComponent<Renderer>().isVisible)
            {
                ExplodeAndDisappear();
                StartCoroutine("DespawnLater");
            }
            else
            {
                DespawnDirectly();
            }
        }
    }
    void OnSpawnCalled()
    {

    }

    public void DespawnDirectly()
    {
        if (gameObject.activeInHierarchy)
        {
            _rectTransform.anchoredPosition = initialPos;
            Disappear();
            PoolManager.Despawn(gameObject);
        }
    }

    public IEnumerator DespawnLater()
    {
        yield return new WaitForSeconds(2f);
        DespawnDirectly();
    }

    public void Generate()
    {
        float heigt = Random.Range(_minHeight, _maxHeight);
        float randomX = Random.Range(-100, 100);
        _rectTransform.anchoredPosition = new Vector2(initialPos.x - _obstacleLayerTransform.localPosition.x+ randomX, heigt);
    }

}
