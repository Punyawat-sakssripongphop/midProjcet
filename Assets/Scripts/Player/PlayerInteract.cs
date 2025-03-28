using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInteract : MonoBehaviour
{
    public Transform mCameraT;
    public float interactRange = 3f;

    public TMP_Text interactText;
    public Image progressImg;

    private BaseInteractObj currentInteract;

    void Update()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(mCameraT.position, mCameraT.forward, out hitInfo, interactRange))
        {
            //Debug.Log($"Hit {hitInfo.collider.name}.");
            BaseInteractObj bio = hitInfo.collider.GetComponent<BaseInteractObj>();
            if (bio != null) 
            {
                if(currentInteract != null)
                {
                    if(bio != currentInteract)
                    {
                        currentInteract.EndInteract();
                    }
                }
                currentInteract = bio;
                
                //Debug.Log("Interactable!");
                interactText.gameObject.SetActive(true);
                interactText.text = bio.message;

                if(Input.GetKeyDown(KeyCode.E))
                {
                    bio.StartInteract(this);
                }
                if(Input.GetKeyUp(KeyCode.E))
                {
                    bio.EndInteract();
                }
            }
            else 
            {
                //Debug.Log("Non Interactable");
                interactText.gameObject.SetActive(false);
                if (currentInteract != null)
                {
                    currentInteract.EndInteract();
                    currentInteract = null;
                }
            }
        }
        else
        {
            //Debug.Log("Hit Nothing!");
            interactText.gameObject.SetActive(false);
            if (currentInteract != null)
            {
                currentInteract.EndInteract();
                currentInteract = null;
            }
        }
    }

    public void OnProgress(float percent)
    {
        progressImg.fillAmount = percent;
    }
}
