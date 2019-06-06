using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnableObject : MonoBehaviour
{
    bool alive;

    public bool Alive
    {
        get { return gameObject.activeInHierarchy; }
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
