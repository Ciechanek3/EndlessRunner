using UnityEngine;

public interface IObjectPooler
{ 
    void InstantiateObjectsToPool();
    void GetRandomObjectFromPool(Transform position);
}
