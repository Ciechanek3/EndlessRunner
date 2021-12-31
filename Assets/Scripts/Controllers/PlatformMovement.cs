using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{   
    [SerializeField]
    private PlatformPooler platformPooler;

    private void Awake()
    {
        platformPooler.InstantiateObjectsToPool();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
       
    }
}
