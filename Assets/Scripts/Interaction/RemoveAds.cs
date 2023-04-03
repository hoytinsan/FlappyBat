using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveAds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(!GameData.Current.RemoveAds);

    }

    private void OnBecameInvisible()
    {
        Debug.Log("OnBecameInvisible");
        if (GameData.Current.RemoveAds)
            Destroy(gameObject);
    }

}
