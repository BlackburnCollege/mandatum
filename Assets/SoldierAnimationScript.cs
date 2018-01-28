using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAnimationScript : MonoBehaviour
{

    private Vector3 destination;
    private bool moving = false;
    public float moveSpeed = 0.5f;


    // Use this for initialization
    void Start()
    {
        destination = new Vector3(0, 0, 0);
        //SetDestination(destination);
    }


    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            Vector3 curPos = gameObject.transform.position;
            Animator animator = GetComponent<Animator>();
            if (Mathf.Abs(Vector3.Distance(curPos, destination)) > .05)
            {
                animator.SetBool("Moving", true);
                var unitVector = (destination - curPos).normalized;
                gameObject.transform.position = Vector3.MoveTowards(curPos, destination, Time.deltaTime * moveSpeed);
                gameObject.transform.rotation = Quaternion.LookRotation(unitVector);
            }
            else
            {
                animator.SetBool("Moving", false);
            }

        }
    }

    public void SetDestination(Vector3 newDest)
    {
        destination = new Vector3(newDest.x, gameObject.transform.position.y, newDest.z);
        moving = true;
    }


}
