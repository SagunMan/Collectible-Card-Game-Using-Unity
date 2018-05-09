﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerPortraitVisual : MonoBehaviour {

    // TODO : get ID from players when game starts

    //public GameObject Explosion;
    public CharacterAsset charAsset;
    [Header("Text Component References")]
    //public Text NameText;
    public Text HealthText;
    [Header("Image References")]
    //public Image HeroPowerIconImage;
    //public Image HeroPowerBackgroundImage;
    public Image PortraitBackgroundImage;
    public Image PortraitImage;
    

    void Awake()
    {
        if (charAsset != null)
        {
            ApplyLookFromAsset();
        }
    }

    public void ApplyLookFromAsset()
    {
        HealthText.text = charAsset.MaxHealth.ToString();
        //HeroPowerIconImage.sprite = charAsset.HeroPowerIconImage;
        //HeroPowerBackgroundImage.sprite = charAsset.HeroPowerBGImage;
        
        PortraitImage.sprite = charAsset.AvatarImage;
        PortraitBackgroundImage.sprite = charAsset.AvatarBGImage;
        

        //HeroPowerBackgroundImage.color = charAsset.HeroPowerBGTint;
        PortraitBackgroundImage.color = charAsset.AvatarBGTint;

    }

    public void TakeDamage(int amount, int healthAfter)
    {
        if (amount > 0)
        {
            DamageEffect.CreateDamageEffect(transform.position, amount);
            HealthText.text = healthAfter.ToString();
        }
    }

    public void Explode()
    {
        
        GlobalSettings.Instance.GameOverCanvas.SetActive(true);
    }



}
