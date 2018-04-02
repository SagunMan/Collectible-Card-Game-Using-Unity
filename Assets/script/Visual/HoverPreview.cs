using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HoverPreview : MonoBehaviour {

    public GameObject TurnOffParent;
    public Vector3 TargetPosition;
    public float TargetScale;
    public GameObject PreviewGameObject;
    public bool ActivateInAwake = false;

    private static HoverPreview currentlyViewing = null;

    private static bool _PreviewsAllowed = true;
    public static bool PreviewsAllowed
    {
        get
        {
            return _PreviewsAllowed;
        }
        set
        {
            _PreviewsAllowed = value;
            if (!_PreviewsAllowed)
            {
                StopAllPreviews();
            }
        }
    }

    private bool _ThisPreviewEnabled = false;
    public bool ThisPreviewEnabled
    {
        get
        {
            return _ThisPreviewEnabled;
        }
        set
        {
            _ThisPreviewEnabled = value;
            if (!_ThisPreviewEnabled)
            {
                StopThisPreview();
            }
        }
    }

    public bool OverCollider { get; set; }

    void Awake()
    {
        ThisPreviewEnabled = ActivateInAwake;
    }

    void OnMouseEnter()
    {
        OverCollider = true;
        if (PreviewsAllowed && ThisPreviewEnabled)
        {
            PreviewThisObject();
        }
    }

    void OnMouseExit()
    {
        OverCollider = false;
        if (!PreviewingSomeCard())
        {
            StopAllPreviews();
        }
    }

    void PreviewThisObject()
    {
        StopAllPreviews();
        currentlyViewing = this;
        
        PreviewGameObject.SetActive(true);
        if (TurnOffParent != null)
        {
            TurnOffParent.SetActive(false);
        }

        PreviewGameObject.transform.localPosition = Vector3.zero;
        PreviewGameObject.transform.localScale = Vector3.one;

        PreviewGameObject.transform.DOLocalMove(TargetPosition, 1f).SetEase(Ease.OutQuint);
        PreviewGameObject.transform.DOScale(TargetScale, 1f).SetEase(Ease.OutQuint);
    }

    void StopThisPreview()
    {
        PreviewGameObject.SetActive(false);
        PreviewGameObject.transform.localScale = Vector3.one;
        PreviewGameObject.transform.localPosition = Vector3.zero;
        if (TurnOffParent != null)
        {
            TurnOffParent.SetActive(true);
        }
    }

    public static void StopAllPreviews()
    {
        if (currentlyViewing != null)
        {
            currentlyViewing.PreviewGameObject.SetActive(false);
            currentlyViewing.PreviewGameObject.transform.localScale = Vector3.one;
            currentlyViewing.PreviewGameObject.transform.localPosition = Vector3.zero;
            if (currentlyViewing.TurnOffParent != null)
            {
                currentlyViewing.TurnOffParent.SetActive(true);
            }
        }
    }

    private static bool PreviewingSomeCard()
    {
        if (!PreviewsAllowed)
        {
            return false;
        }

        HoverPreview[] allHoverBlowups = GameObject.FindObjectsOfType<HoverPreview>();

        foreach (HoverPreview hb in allHoverBlowups)
        {
            if (hb.OverCollider && hb.ThisPreviewEnabled)
                return true;
        }

        return false;
    }
}
