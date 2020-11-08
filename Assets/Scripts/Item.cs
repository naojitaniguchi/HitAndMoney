using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public float lifeTime = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Life");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Life() 
    {
        yield return new WaitForSeconds(lifeTime);

        Destroy(this.gameObject);
    }
}
