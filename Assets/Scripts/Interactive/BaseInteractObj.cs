using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseInteractObj : MonoBehaviour
{
    public string message;

    public bool hasDuration;
    public float duration;
    public bool isResetTimer;

    private bool onProgress;
    private float timer;

    private PlayerInteract mPlayerInteract;

    public virtual void Interact()
    {
        Debug.Log($"{name} : Interact!!!");
    }

    public void StartInteract(PlayerInteract pi)
    {
        mPlayerInteract = pi;

        if(hasDuration)
        {
            timer = 0f;
            onProgress = true;

        }
        else
        {
            Interact();
        }
    }

    public void EndInteract()
    {
        onProgress = false;
        if(mPlayerInteract != null)
        {
            mPlayerInteract.OnProgress(0f);
        }
    }

    private void Update()
    {
        if(onProgress)
        {
            timer += Time.deltaTime;
            mPlayerInteract.OnProgress(timer / duration);
            if(timer > duration)
            {
                onProgress = false;
                timer = 0f;
                mPlayerInteract.OnProgress(0f);
                Interact();
            }
        }
    }
}
