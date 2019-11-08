using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelController : MonoBehaviour, INT_Shootable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WasShot()
    {
        Debug.Log("Barrel being destroyed");
        for (var i = transform.childCount; i-- > 0;)
        {
            Destroy(transform.GetChild(0).gameObject);           
        }
        Destroy(gameObject);
    }
}
