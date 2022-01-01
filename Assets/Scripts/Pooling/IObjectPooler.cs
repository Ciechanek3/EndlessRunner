using UnityEngine;

public interface IObjectPooler
{ 
    void InstantiateObjectsToPool();
    void AddElementToPool(int index);
    void AddRandomElementToPool();
}
