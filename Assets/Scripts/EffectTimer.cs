using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectTimer : MonoBehaviour
{
    public float lifeTime = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("life");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator life()
    {
        yield return new WaitForSeconds(lifeTime);

        Destroy(gameObject);
    }
}
