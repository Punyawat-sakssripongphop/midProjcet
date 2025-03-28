using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float crouchSpeed = 2f;

    public float mouseSensitivity = 2f;
    public Transform mCameraT;
    public float minLookX = -90f;
    public float maxLookX = 60f;

    public float jumpForce = 5f;
    public LayerMask groundMask;

    public float normalHeight = 2f;
    public float crouchHeight = 1f;

    private Rigidbody mRig;
    private float currentLookX = 0f;

    private CapsuleCollider mCapsuleCol;
    private float originCameraHeight = 0f;

    void Start()
    {
        mRig = GetComponent<Rigidbody>();
        mCapsuleCol = GetComponent<CapsuleCollider>();
        originCameraHeight = mCameraT.localPosition.y;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Input Crouch
        bool isCrounching = Input.GetKey(KeyCode.LeftControl);
        Crouch(isCrounching);

        //Input Move
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        if (h != 0 || v != 0)
        {
            Move(h, v, isRunning, isCrounching);
        }

        //Input MouseLook
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        if(mouseX != 0 || mouseY != 0)
        {
            MouseLook(mouseX, mouseY);
        }

        //Input Jump
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            jump();
        }

    }

    private void Move(float moveX, float moveZ, bool isRun, bool isCrouch)
    {
        //Vector3 movement = new Vector3(moveX, 0f, moveZ);
        Vector3 movement = (transform.forward * moveZ) + (transform.right * moveX);

        if (isRun && !isCrouch)
        {
            mRig.velocity = movement * runSpeed + new Vector3(0f, mRig.velocity.y, 0f);
        }
        else if(isCrouch)
        {
            mRig.velocity = movement * crouchSpeed + new Vector3(0f, mRig.velocity.y, 0f);
        }
        else
        {
            mRig.velocity = movement * walkSpeed + new Vector3(0f, mRig.velocity.y, 0f);
        }

    }

    private void MouseLook(float mouseX, float mouseY)
    {
        transform.Rotate(0f, mouseX, 0f);

        currentLookX -= mouseY;
        currentLookX = Mathf.Clamp(currentLookX, minLookX, maxLookX);

        mCameraT.localRotation = Quaternion.Euler(currentLookX, 0f, 0f);
    }

    private void jump()
    {
        mRig.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
    }

    private bool isGrounded()
    {
        bool result = Physics.Raycast(transform.position + new Vector3(0f, 0.05f, 0f), Vector3.down, 0.1f, groundMask);
        return result;
    }

    private void Crouch(bool isCrouch)
    {
        if(isCrouch)
        {
            float cameraheight = originCameraHeight - (normalHeight - crouchHeight);
            mCameraT.localPosition = new Vector3(0f, cameraheight, 0f);

            mCapsuleCol.height = crouchHeight;
            mCapsuleCol.center = new Vector3(0f, crouchHeight * 0.5f, 0f);
        }
        else
        {
            mCameraT.localPosition = new Vector3(0f, originCameraHeight, 0f);

            mCapsuleCol.height = normalHeight;
            mCapsuleCol.center = new Vector3(0f, normalHeight * 0.5f, 0f);
        }
    }
}
