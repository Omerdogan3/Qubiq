﻿using UnityEngine;
using System.Collections;

public class PlayerMovementScript : MonoBehaviour {

    public bool canMove = false;
    public float timeForMove = 0.2f;
    public float jumpHeight = 1.0f;
    public int minX = -4;
    public int maxX = 5;
    public GameObject[] leftSide;
    public GameObject[] rightSide;
    public float leftRotation = -45.0f;

    public float rightRotation = 90.0f;
    private bool moving;
    private float elapsedTime;
    private Vector3 current;
    private Vector3 target;
    private float startY;
    private Rigidbody body;
    private GameObject mesh;
    private int score;
    public void Start()
    {
        current = transform.position;
        moving = false;
        startY = transform.position.y;

        body = GetComponentInChildren<Rigidbody>();

        mesh = GameObject.Find("Player/Mesh");

        score = 0;
    }

    public void Update()
    {
        if (moving)
        {
            MovePlayer();
        }
        else
        {
            current = new Vector3(
                Mathf.Round(transform.position.x),
                Mathf.Round(transform.position.y),
                Mathf.Round(transform.position.z)
            );

            if (canMove)
            {
                HandleInput();
            }
        }


    }

    private void HandleInput()
    {		
        if (Input.GetKeyDown(KeyCode.W))
        {
            Move(new Vector3(0, 0, 1));
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Move(new Vector3(0, 0, -1));

        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (Mathf.RoundToInt(current.x) > minX)
            {
                Move(new Vector3(-1, 0, 0));
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (Mathf.RoundToInt(current.x) < maxX)
            {
                Move(new Vector3(1, 0, 0));
            }
        }
    }

    private void Move(Vector3 distance)
    {
        var newPosition = current + distance;

        if (Physics.CheckSphere(newPosition + new Vector3(0.0f, 0.5f, 0.0f), 0.1f)) return;

        target = newPosition;

        moving = true;
        elapsedTime = 0;
        body.isKinematic = true;

        switch (MoveDirection)
        {
            case "north":
                mesh.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case "south":
                mesh.transform.rotation = Quaternion.Euler(0, 180, 0);
                break;
            case "east":
                mesh.transform.rotation = Quaternion.Euler(0, 270, 0);
                break;
            case "west":
                mesh.transform.rotation = Quaternion.Euler(0, 90, 0);
                break;
            default:
                break;
        }

        // Rotate arm and leg.
        foreach (var o in leftSide)
        {
            o.transform.Rotate(leftRotation, 0, 0);
        }

        foreach (var o in rightSide)
        {
            o.transform.Rotate(rightRotation, 0, 0);
        }
    }

    private void MovePlayer()
    {
        elapsedTime += Time.deltaTime;

        float weight = (elapsedTime < timeForMove) ? (elapsedTime / timeForMove) : 1;
        float x = Lerp(current.x, target.x, weight);
        float z = Lerp(current.z, target.z, weight);
        float y = Sinerp(current.y, startY + jumpHeight, weight);

        Vector3 result = new Vector3(x, y, z);
        transform.position = result;

        if (result == target)
        {
            moving = false;
            current = target;
            body.isKinematic = false;
            body.AddForce(0, -10, 0, ForceMode.VelocityChange);

            foreach (var o in leftSide)
            {
                o.transform.rotation = Quaternion.identity;
            }

            foreach (var o in rightSide)
            {
                o.transform.rotation = Quaternion.identity;
            }
        }
    }

    private float Lerp(float min, float max, float weight)
    {
        return min + (max - min) * weight;
    }

    private float Sinerp(float min, float max, float weight)
    {
        return min + (max - min) * Mathf.Sin(weight * Mathf.PI);
    }

    public bool IsMoving
    {
        get { return moving; }
    }

    public string MoveDirection
    {
        get
        {
            if (moving)
            {
                float dx = target.x - current.x;
                float dz = target.z - current.z;
                if (dz > 0)
                {
                    return "north";
                }
                else if (dz < 0)
                {
                    return "south";
                }
                else if (dx > 0)
                {
                    return "west";
                }
                else
                {
                    return "east";
                }
            }
            else
            {
                return null;
            }
        }
    }

}