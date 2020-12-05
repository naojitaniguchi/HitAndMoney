using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed = 5.0f;
    public GameObject item;
    public GameObject punch;
    public GameObject effectRight;
    public GameObject effectLeft;
    Rigidbody rb;
    public int money = 0;
    public GameObject textMoneyCount;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = Vector3.forward * speed;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.velocity = Vector3.forward * speed * -1;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = Vector3.right * speed;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = Vector3.right * speed * -1;
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            Vector3 itemPos = new Vector3(gameObject.transform.position.x, item.transform.position.y, gameObject.transform.position.z);
            GameObject newItem = GameObject.Instantiate(item, itemPos, Quaternion.identity);

            GameObject[] enemyList = GameObject.FindGameObjectsWithTag("Enemy");
            for ( int i = 0; i < enemyList.Length; i ++ )
            {
                enemyList[i].GetComponent<NavEnemy>().item = newItem;
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Punch(Vector3.right * -1.0f);
            GameObject effectObj = Instantiate(effectLeft, gameObject.transform.position, Quaternion.identity);
            effectObj.transform.parent = gameObject.transform;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Punch(Vector3.right );
            GameObject effectObj = Instantiate(effectRight, gameObject.transform.position, Quaternion.identity);
            effectObj.transform.parent = gameObject.transform;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            Punch(Vector3.forward);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Punch(Vector3.forward * -1.0f );
        }
    }

    void Punch( Vector3 dir)
    {
        Vector3 punchPos = new Vector3(gameObject.transform.position.x, punch.transform.position.y, gameObject.transform.position.z);
        GameObject newPunch = GameObject.Instantiate(punch, punchPos, Quaternion.identity);
        newPunch.GetComponent<Punch>().Strike(dir);
    }

    private void OnTriggerEnter(Collider other)
    {
        if ( other.gameObject.tag == "Coin")
        {
            money += other.GetComponent<Coin>().money;
            Debug.Log(money);
            textMoneyCount.GetComponent<Text>().text = money.ToString();

            Destroy(other.gameObject);
        }
    }
}
