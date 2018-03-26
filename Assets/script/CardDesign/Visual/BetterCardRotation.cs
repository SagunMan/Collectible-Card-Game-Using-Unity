using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class BetterCardRotation : MonoBehaviour
{

    //parent variable for all card faces
    public RectTransform CardFront;

    //parent variable for all card backs
    public RectTransform CardBack;

    //empty gameobject that is placed a bit above the face of the card, in the centre of the card
    public Transform targetFacePoint;

    //box collider attatched to the card
    public Collider col;

    //to determine whether card is showing face or back
    private bool showingBack = false;

    //Update is called once per frame
    void Update()
    {
        //Raycast from camera to target point on the face of the card
        //if it passes through the card collider change to card back
        RaycastHit[] hits;
        hits = Physics.RaycastAll(origin: Camera.main.transform.position,
            direction: (-Camera.main.transform.position + targetFacePoint.position).normalized,
            maxDistance: (-Camera.main.transform.position + targetFacePoint.position).magnitude);
        bool passedThroughColliderOnCard = false;
        foreach (RaycastHit h in hits)
        {
            if (h.collider == col)
            {
                passedThroughColliderOnCard = true;
            }
        }

        if (passedThroughColliderOnCard != showingBack)
        {
            showingBack = passedThroughColliderOnCard;
            if (showingBack)
            {
                //Show backside
                CardFront.gameObject.SetActive(false);
                CardBack.gameObject.SetActive(true);
            }
            else
            {
                //show frontside
                CardFront.gameObject.SetActive(true);
                CardBack.gameObject.SetActive(false);
            }
        }
    }

}
