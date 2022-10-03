using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drops : MonoBehaviour
{
    [SerializeField] private GameObject[] dropsPrefab;
    public float spawnTime = 1.0f;
    public float minTras;
    public float maxTras;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DropSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DropSpawn()
    {
        while (true)
        {
            var area = Random.Range(minTras, maxTras);
            var pos = new Vector2(area, transform.position.y);
            GameObject obj = Instantiate(dropsPrefab[Random.Range(0, dropsPrefab.Length)], pos, Quaternion.identity);
            yield return new WaitForSeconds(spawnTime);
            Destroy(obj, 5f);
        }
    }
}
