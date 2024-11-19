using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    private enum State
    {
        PatrollingAB, PatrollingBC, PatrollingCA, FollowingPlayer
    }

    private State currentState;

    public GameObject pointA;
    public GameObject pointB;
    public GameObject pointC;

    public Rigidbody rb;

    public float moveSpeed;

    public Transform player;

    public float detectionDistance;

    void Start()
    {
        transform.position = pointA.transform.position;
        currentState = State.PatrollingAB;
    }

    void Update()
    {
        HandleState();
        if(transform.position == pointB.transform.position)
        {
            currentState = State.PatrollingBC;
        }
        if (transform.position == pointC.transform.position)
        {
            currentState = State.PatrollingCA;
        }
        if (transform.position == pointA.transform.position)
        {
            currentState = State.PatrollingAB;
        }
        if(Vector3.Distance(transform.position, player.position) <= detectionDistance)
        {
            currentState = State.FollowingPlayer;
        }
    }

    private void HandleState()
    {
        switch(currentState)
        {
            case State.PatrollingAB:
                transform.position = Vector3.MoveTowards(transform.position, pointB.transform.position, moveSpeed * Time.deltaTime);
                break;
            case State.PatrollingBC:
                transform.position = Vector3.MoveTowards(transform.position, pointC.transform.position, moveSpeed * Time.deltaTime);
                break;
            case State.PatrollingCA:
                transform.position = Vector3.MoveTowards(transform.position, pointA.transform.position, moveSpeed * Time.deltaTime);
                break;
            case State.FollowingPlayer:
                transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
                if(Vector3.Distance(transform.position, player.position) > detectionDistance)
                {
                    currentState= State.PatrollingCA;
                }
                break;
        }
    }
    void OnTriggerStay(Collider boom)
    {
        if(boom.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("LostScreen");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;

        }
    }
}
