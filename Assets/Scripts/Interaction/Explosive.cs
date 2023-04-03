using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;

public class Explosive : MonoBehaviour
{
    public DOTweenAnimation DotweenAnim;
    public ParticleSystem ExplotionPS;
    public string dotweenId;

    void Awake()
    {
        DotweenAnim = GetComponent<DOTweenAnimation>();
        dotweenId = DotweenAnim.id;

    }

    void OnEnable()
    {
        if (tag.Equals("button") && !Object.ReferenceEquals(GetComponent<Collider>(), null))
        {
            GetComponent<Collider>().enabled = true;
        }
        
    }

    public void ExplodeAndDisappear()
    {
        if (tag.Equals("button") && !Object.ReferenceEquals(GetComponent<Collider>(), null))
        {
            GetComponent<Collider>().enabled = false;
        }

        Explode();
        Disappear();
    }

    public void ExplodeAndAppear()
    {
        Explode();
        Appear();
    }

    public void Explode()
    {
        if (!Object.ReferenceEquals(ExplotionPS, null))
        {
            if (ExplotionPS.isPlaying)
            {
                ExplotionPS.Clear();
            }
            ExplotionPS.Play(true);
        }
    }

    public void Appear()
    {
        DotweenAnim.DORestartById(dotweenId);
    }

    public void Disappear()
    {
        DotweenAnim.DOPlayBackwards();
    }
}
