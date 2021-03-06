﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

public class ChickenMovement : MonoBehaviour
{
    public GameObject player;
    public Rigidbody myRigidbody;
    public Animator chickenAnimator;
    private int isWalkingHash;

    public float speed;
    public float runSpeed;
    public float walkSpeed;

    public bool choosingDirection;
    public bool wander;

    public bool wandering;
    public bool idling;
    public bool eating;
    public bool running;

    public float distanceBeforeRunningAway;
    public float maximumAngleOfDeviation;

    public float timeTakenForAction;
    public float timeTakenForNewAction;
    public float timeBetweenBoundaryChecks;

    public LayerMask boundaries;
    public float boundaryCheckDist;
    private bool runningFromBoundary;

    private float currentTime;
    private float currentFixedTime;

    private float distanceBetweenPlayerAndChicken;

    public enum states {wandering, idle, eating, running};
    public states currentState;
    public states previousState;

    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector3(0, transform.position.y, 0);
        myRigidbody = GetComponent<Rigidbody>();
        chickenAnimator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        player = GameObject.FindGameObjectWithTag("Player");
        Physics.IgnoreCollision(GetComponent<Collider>(), player.GetComponent<Collider>());
        currentState = states.wandering;
        previousState = states.idle;
        StartCoroutine(PickRandomState());
        currentTime = Time.time;
        currentFixedTime = Time.fixedTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == states.wandering || currentState == states.running || currentState == states.idle)
        {
            distanceBetweenPlayerAndChicken = Vector3.Distance(transform.position, player.transform.position);

            if (distanceBetweenPlayerAndChicken < distanceBeforeRunningAway)
            {
                previousState = currentState;
                currentState = states.running;
                StopCoroutine(PickRandomState());
            }
            else
            {
                if (currentState != previousState || currentState == states.running)
                {
                    previousState = currentState;
                    StartCoroutine(PickRandomState());
                }
            }

            if (currentState == states.wandering && !wander)
            {
                wander = true;
                StartCoroutine(Wander());
            }
            else
            {
                StopCoroutine(Wander());
            }

            if (currentState == states.running && !choosingDirection && !runningFromBoundary)
            {
                choosingDirection = true;
                StartCoroutine(RunFromPlayer());
            }

            if (currentState == states.running)
            {
                float lerpVal = Mathf.InverseLerp(distanceBeforeRunningAway, 1, distanceBetweenPlayerAndChicken);
                speed = runSpeed * lerpVal;
                if(speed < walkSpeed)
                {
                    speed = walkSpeed;
                }
            }
            else if(currentState == states.wandering)
            {
                speed = walkSpeed;
            }
        }

        if(Time.time > currentTime + timeTakenForNewAction && currentState != states.running && currentState != states.eating)
        {
            StopCoroutine(PickRandomState());
            StartCoroutine(PickRandomState());
            currentTime = Time.time;
        }

        StateCheck();
        SetAnimatorStates();
    }

    void FixedUpdate()
    {
        if (currentState == states.running || currentState == states.wandering)
        {
            myRigidbody.MovePosition(transform.position + (transform.forward * speed * Time.fixedDeltaTime));
        }
        else
        {
            runningFromBoundary = false;
            choosingDirection = false;
            StopCoroutine(RunFromPlayer());
        }

        if (Time.fixedTime > currentFixedTime + timeBetweenBoundaryChecks)
        {
            BoundaryCheck();
            currentFixedTime = Time.fixedDeltaTime;
        }
    }

    public void BoundaryCheck()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, boundaryCheckDist, boundaries))
        {
            runningFromBoundary = true;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 180f, transform.rotation.eulerAngles.z);
            //Debug.DrawLine(transform.position, transform.position + transform.forward * boundaryCheckDist, Color.green, 5f);
        }
        else
        {
            runningFromBoundary = false;
            //Debug.DrawLine(transform.position, transform.position + transform.forward * boundaryCheckDist, Color.red);
        }
    }

    public void StateCheck()
    {
        if (currentState == states.wandering)
        {
            wandering = true;
        }
        else
        {
            wandering = false;
        }

        if (currentState == states.idle)
        {
            idling = true;
        }
        else
        {
            idling = false;
        }

        if (currentState == states.eating)
        {
            eating = true;
        }
        else
        {
            eating = false;
        }

        if (currentState == states.running)
        {
            running = true;
        }
        else
        {
            running = false;
        }
    }

    public void SetAnimatorStates()
    {
        chickenAnimator.SetBool(isWalkingHash, wandering || running);

        if(running)
        {
            chickenAnimator.speed = 3f;
        }
        else
        {
            chickenAnimator.speed = 1f;
        }
    }

    IEnumerator RunFromPlayer()
    {
        float playerRotation = player.transform.rotation.eulerAngles.y;
        float randomDir = Random.Range(playerRotation - maximumAngleOfDeviation, playerRotation + maximumAngleOfDeviation);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, randomDir, transform.rotation.eulerAngles.z);
        yield return new WaitForSeconds(timeTakenForAction);
        choosingDirection = false;
    }

    IEnumerator Wander()
    {
        float randomDir = Random.Range(0, 361);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, randomDir, transform.rotation.eulerAngles.z);
        yield return new WaitForSeconds(timeTakenForAction);
        wander = false;
    }

    IEnumerator PickRandomState()
    {
        byte randomState = (byte)Random.Range(0, 2); //max is not inclusive, the documentation lied

        switch(randomState)
        {
            case 0:
                currentState = states.wandering;
                break;
            case 1:
                currentState = states.idle;
                break;
            default:
                currentState = states.wandering;
                break;
        }
        yield return new WaitForSeconds(timeTakenForNewAction);

    }
}
