using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicPlayer : MonoBehaviour
{
    Vector3 posToMove;
    bool isMoving;
    public float margin = 200f;
    public float speed = 20f;
    Vector3 mouseStartPoint;
    bool checkingMouse = false;
    Vector3 mousePos;
   int kesitocount = 0; 
    //public GameObject won;
    //public GameObject gameOver;
    

    private void Start() {
        posToMove = transform.position;
    }

    void Update()
    {   
        #if UNITY_IOS || UNITY_ANDROID
            if (Input.touchCount > 0) {
                Touch touch = Input.GetTouch(0);
                mousePos = touch.position;

                if (touch.phase == TouchPhase.Moved) {
                    OnMouseMoveStart();
                }
            }
        #else
            mousePos = Input.mousePosition;
            if (Input.GetKeyDown(KeyCode.Mouse0)) {
                OnMouseMoveStart();
            }
            if (checkingMouse) {
                if (Vector3.Distance(mouseStartPoint, mousePos) > margin) {
                    OnMouseOutOfMargin();
                }
            }
        #endif
        

        transform.position = Vector3.MoveTowards(transform.position, posToMove, Time.deltaTime * speed);

        isMoving = (posToMove != transform.position);

    }

    void OnMouseMoveStart() {
        mouseStartPoint = mousePos;
        checkingMouse = true;
    }

void OnMouseOutOfMargin() {
        checkingMouse = false;
        Vector3 delta = mouseStartPoint - mousePos;
        if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y)) {
            if (delta.x > 0) {
                MoveInDirection(Vector3.right);
                transform.GetChild(0).rotation = Quaternion.Euler(new Vector3(-90,-90,0));
            }else {
                MoveInDirection(Vector3.left);
                transform.GetChild(0).rotation = Quaternion.Euler(new Vector3(-90,90,0));
            }
        }else {
            if (delta.y > 0) {
                MoveInDirection(Vector3.forward);
                transform.GetChild(0).rotation = Quaternion.Euler(new Vector3(-90,180,0));
            }else {
                MoveInDirection(Vector3.back);
                transform.GetChild(0).rotation = Quaternion.Euler(new Vector3(-90,0,0));
            }
        }
    }
    void MoveInDirection(Vector3 dir) {
        if (isMoving) return;
        Vector3 fwd = transform.TransformDirection(dir);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, fwd, out hit))
            posToMove = hit.point - (dir/2);
    }
}
