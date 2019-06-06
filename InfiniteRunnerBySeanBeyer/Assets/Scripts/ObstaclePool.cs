using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour
{
    [SerializeField]
    GameObject obstaclePrefab;

    [SerializeField]
    Vector2 minMaxTimeBetweenSpawns;

    float timeElapsed;

    float timeUntilSpawn;

    List<SpawnableObject> pool;

    // Start is called before the first frame update
    void Start()
    {
        pool = new List<SpawnableObject>();
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > timeUntilSpawn)
            Spawn();
    }

    void Spawn()
    {
        GameObject newObject = null;
        //if an object is inactive, set it as the new object
        for (int i = 0; i < pool.Count; ++i)
        {
            if (!pool[i].Alive)
            {
                newObject = pool[i].gameObject;
                break;
            }
        }
        if (newObject == null)
            newObject = CreateNewObject();

        //spawn new object
        newObject.transform.localPosition = Vector3.zero;
        newObject.SetActive(true);

        //reset the spawn timer
        timeElapsed = 0f;
        timeUntilSpawn = Random.Range(minMaxTimeBetweenSpawns.x, minMaxTimeBetweenSpawns.y);
    }

    GameObject CreateNewObject()
    {
        GameObject obj = Instantiate(obstaclePrefab, transform);
        pool.Add(obj.GetComponent<SpawnableObject>());
        return obj;
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
