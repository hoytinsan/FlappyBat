using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Vampire : Explosive
{
    [SerializeField]
    Animator animator;

    [SerializeField]
    DOTweenAnimation dOTweenShadow;

    [SerializeField]
    DOTweenAnimation dOTweenRock;

    private Collider2D _collider2D;

    void Start()
    {
        _collider2D = GetComponent<Collider2D>();
    }

    void OnEnable()
    {    
        Explode();
    }

    public void Initialize()
    {
        GetComponent<Collider2D>().enabled = true;

    }

    public void PlayAnimation()
    {
        animator.SetTrigger("Vanish");
    }

    public void ExplodeAndChangeToBat()
    {
        ExplodeAndDisappear();

        dOTweenShadow.DOPlayBackwards();
        dOTweenRock.DOPlayBackwards();

        _collider2D.enabled = false;
        UIEventManager.Current.LoadGame();
    }

    public void StartGame()
    {
        UIEventManager.Current.Play();
        GameData.Current.IsButtonPressEnabled = true;
    }

    public void Unload()
    {
        UIEventManager.Current.UnLoadVampire();
    }



}
