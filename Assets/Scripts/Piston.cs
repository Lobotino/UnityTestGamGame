using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piston : MonoBehaviour
{
    public Animator anim;
    public GameObject pushCollider;
    public float startPushPos, endPushPos;
    public bool isPush = false, isStart = false, isContinue = false;
    
    public float startTime, speed = 1f;
    
    void Start()
    {
        startPushPos = pushCollider.transform.position.y;
        endPushPos = startPushPos + 0.7f;
    }

    void Update()
    {
        if (isStart) {
            if (isContinue)
            {

                var t = (Time.time - startTime) * speed;
                Debug.Log(t);
                if (isPush)
                {
                    pushCollider.transform.position = new Vector3(pushCollider.transform.position.x,
                        Mathf.SmoothStep(startPushPos, endPushPos, t), 0);

//                    var offset = pushCollider.offset;
//                    pushCollider.offset.Set(offset.x, Mathf.SmoothStep(startPushPos, endPushPos, Time.time / speed));

                    if (Math.Abs(pushCollider.transform.position.y - endPushPos) < 0.000001f)
                        isContinue = false;
                }
                else
                {
                    pushCollider.transform.position = new Vector3(pushCollider.transform.position.x,
                        Mathf.SmoothStep(endPushPos, startPushPos, t), 0);
                    
//                    var offset = pushCollider.offset;
//                    pushCollider.offset.Set(offset.x, Mathf.SmoothStep(endPushPos, startPushPos, Time.time / speed));
//

                    if (Math.Abs(pushCollider.transform.position.y - startPushPos) < 0.000001f)
                        isContinue = false;
                }
            }
        }
    }

    private void SetPush()
    {
        startTime = Time.time;
        isStart = true;
        isContinue = true;
        isPush = !isPush;
        anim.SetBool("isStart", true);
        anim.SetBool("Push", isPush);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player")) {
            SetPush();
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(other.gameObject.transform.up * 80, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag.Equals("Player")) {
            SetPush();
        }
    }
}
