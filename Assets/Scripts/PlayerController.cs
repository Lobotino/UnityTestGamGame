using System;
using System.Collections;
using System.Collections.Generic;
using DragonBones;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f, jumpSpeed = 10f;
    public Rigidbody2D rigidBody;
    public UnityArmatureComponent ArmatureComponent;

    public GameObject sky, sun;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var position = transform.position;
        sky.transform.position = new Vector2(position.x, sky.transform.position.y);
        sun.transform.position = new Vector2(position.x, sun.transform.position.y);

        float horizontalMove = Input.GetAxisRaw("Horizontal");
        if (horizontalMove > 0)
            ArmatureComponent.armature.flipX = false;
        else if (horizontalMove < 0)
            ArmatureComponent.armature.flipX = true;


        if (Input.GetKey(KeyCode.A)) {
            transform.Translate(-speed * Time.deltaTime * transform.right);
        }

        if (Input.GetKey(KeyCode.D)) {
            transform.Translate(speed * Time.deltaTime * transform.right);
        }

        if (Input.GetKey(KeyCode.W) && Math.Abs(Math.Abs(rigidBody.velocity.y)) < 0.01f) {
            rigidBody.AddForce(transform.up * jumpSpeed, ForceMode2D.Impulse);
        }
    }
}
