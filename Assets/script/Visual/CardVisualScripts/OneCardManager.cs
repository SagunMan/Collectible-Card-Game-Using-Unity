using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OneCardManager : MonoBehaviour {

    public CardAsset cardAsset;
    public OneCardManager PreviewManager;
    [Header("Text Component Reference")]
    public Text NameText;
    public Text ResourceCostText;
    public Text DescriptionText;
    public Text HealthText;
    public Text AttackText;
    //[Header("GameObject Reference")]
    //public GameObject HealthIcon;
    //public GameObject AttackIcon;
    [Header("Image Reference")]
    public Image CardHeaderImage;
    public Image CardDescriptionImage;
    public Image CardGraphicImage;
    public Image CardBodyImage;
    public Image CardFaceFrameImage;
    public Image CardFaceGlowImage;
    //public Image CardBackGlowImage;

	// Use this for initialization
	void Awake ()
    {
        if (cardAsset != null)
        {
            ReadCardFromAsset();
        }
	}

    private bool canBePlayedNow = false;
    public bool CanBePlayedNow
    {
        get
        {
            return canBePlayedNow;
        }
        set
        {
            canBePlayedNow = value;
            CardFaceGlowImage.enabled = value;
        }
    }

    public void ReadCardFromAsset()
    {
        //if (cardAsset.characterAsset != null)
        //{
        //    CardBodyImage.color = cardAsset.characterAsset.ClassCardTint;
        //    CardFaceFrameImage.color = cardAsset.characterAsset.ClassCardTint;
        //    CardTopRibbonImage.color = cardAsset.characterAsset.ClassRibbonsTint;
        //    CardLowRibbonImage.color = cardAsset.characterAsset.ClassRibbonsTint;
        //}
        //else
        //{
        //CardBodyImage.color = GlobalSettings.Instance.CardBodyStandardColor;
        //CardFaceFrameImage.color = Color.white;
        //CardTopRibbonImage.color = GlobalSettings.Instance.CardRibbonStandardColor;
        //CardLowRibbonImage.color = GlobalSettings.Instance.CardRibbonStandardColor;
        //}

        NameText.text = cardAsset.name;

        ResourceCostText.text = cardAsset.ResourceCost.ToString();

        DescriptionText.text = cardAsset.Description;

        CardGraphicImage.sprite = cardAsset.CardImage;

        CardBodyImage.sprite = cardAsset.CardBodyImage;

        CardHeaderImage.sprite = cardAsset.CardHeaderImage;

        CardDescriptionImage.sprite = cardAsset.CardDescriptionImage;
        
        

        
        if (cardAsset.MaxHealth != 0)
        {
            AttackText.text = cardAsset.Attack.ToString();
            HealthText.text = cardAsset.MaxHealth.ToString();
        }

        if (PreviewManager != null)
        {
            PreviewManager.cardAsset = cardAsset;
            PreviewManager.ReadCardFromAsset();
        }
    }
}
