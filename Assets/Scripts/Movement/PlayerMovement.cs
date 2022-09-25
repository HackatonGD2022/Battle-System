using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent playerNavMeshAgent;

    // A Camera that follow player movement
    [SerializeField]
    private Camera playerCamera;

    [SerializeField]
    private Animator playerAnimator;

    private bool stopped;

    private bool isMove;

    // Start is called before the first frame update
    void Start()
    {
        stopped = false;
    }

    public void StopWalk()
    {
        stopped = true;
        playerNavMeshAgent.ResetPath();
        isMove = false;
        playerAnimator.SetBool("IsMove", isMove);
        //playerNavMeshAgent.isStopped = stopped;
    }

    public void StartWalk()
    {
        stopped = false;
        //playerNavMeshAgent.isStopped = stopped;
        playerNavMeshAgent.ResetPath();
    }

    public void MovePlayer(Vector3 position)
    {
        playerNavMeshAgent.SetDestination(position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!stopped)
        {
            //if the left button of is clicked
            if (Input.GetMouseButton(0))
            {
                //Unity cast a ray from the position of mouse cursor on-screen toward the 3D scene.
                Ray myRay = playerCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit myRaycastHit;

                if (Physics.Raycast(myRay, out myRaycastHit))
                {
                    //Assign ray hit point as Destination of Navemesh Agent (Player)
                    playerNavMeshAgent.SetDestination(myRaycastHit.point);
                }
            }
        }

        //Compare the value of the remaining distance and the stopping distance(Destination point)
        if (playerNavMeshAgent.remainingDistance <= playerNavMeshAgent.stoppingDistance)
        {
            //The remaining distance are less or equal than the stopping distance it means character stop moving and reached destination
            isMove = false;
        }
        else
        {
            //If remaining distance are greater than the stopping distance than character still moving toward Destination
            isMove = true;
        }
        playerAnimator.SetBool("IsMove", isMove);
    }
}
