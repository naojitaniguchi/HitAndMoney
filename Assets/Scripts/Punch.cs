using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour
{
    public float lifeTime = 3.0f;
    public float power = 100.0f;
    public Vector3 forceDir;
    public GameObject[] coins;
    // Start is called before the first frame update
    void Start()
    {
        
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

    public void Strike( Vector3 dir )
    {
        forceDir = dir;

        gameObject.GetComponent<Rigidbody>().AddForce(forceDir.normalized * power);

        StartCoroutine("Life");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if ( other.gameObject.tag == "Enemy")
        {
            Vector3 enemyPos = other.gameObject.transform.position;
            Destroy(other.gameObject);

            GameObject coin = coins[Random.Range(0, coins.Length)];
            Vector3 coinPos = new Vector3(enemyPos.x, coin.transform.position.y, enemyPos.z);

            GameObject.Instantiate(coin, coinPos, Quaternion.identity);

            Destroy(this.gameObject);
        }
    }
}
