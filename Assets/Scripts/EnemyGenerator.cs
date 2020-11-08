using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public float zMin = -5;
    public float zMax = 5;
    public float genTime = 2.0f;
    public bool generating = true;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Generate");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Generate()
    {
        while (generating)
        {
            yield return new WaitForSeconds(genTime);

            Vector3 newPos = new Vector3(gameObject.transform.position.x, enemy.transform.position.y, Random.Range(zMin, zMax));

            GameObject.Instantiate(enemy, newPos, Quaternion.identity);
        }
    }
}
