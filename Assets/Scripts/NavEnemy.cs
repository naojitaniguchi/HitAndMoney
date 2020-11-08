using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavEnemy : MonoBehaviour
{
    public GameObject item;

    NavMeshAgent agent;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if ( item != null)
        {
            agent.SetDestination(item.transform.position);
        }
        else
        {
            if (player != null)
            {
                agent.SetDestination(player.transform.position);
            }
        }
    }
}
