using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[System.Serializable]
public class CardLogic: IIdentifiable
{
    public Player owner;
    public int UniqueCardID; 

    public CardAsset ca;
    public GameObject VisualRepresentation;

    private int baseResourceCost;
    public SpellEffect effect;

    public int ID
    {
        get{ return UniqueCardID; }
    }

    public int CurrentResourceCost{ get; set; }

    public bool CanBePlayed
    {
        get
        {
            bool ownersTurn = (TurnManager.Instance.whoseTurn == owner);
            // for spells the amount of characters on the field does not matter
            bool fieldNotFull = true;
            // but if this is a creature, we have to check if there is room on board (table)
            if (ca.MaxHealth > 0)
                fieldNotFull = (owner.table.CreaturesOnTable.Count < 7);
            //Debug.Log("Card: " + ca.name + " has params: ownersTurn=" + ownersTurn + "fieldNotFull=" + fieldNotFull + " hasMana=" + (CurrentManaCost <= owner.ManaLeft));
            return ownersTurn && fieldNotFull && (CurrentResourceCost <= owner.ManaLeft);
        }
    }

    public CardLogic(CardAsset ca)
    {
        this.ca = ca;
        UniqueCardID = IDFactory.GetUniqueID();
        //UniqueCardID = IDFactory.GetUniqueID();
        baseResourceCost = ca.ResourceCost;
        ResetManaCost();
        if (ca.SpellScriptName!= null && ca.SpellScriptName!= "")
        {
            effect = System.Activator.CreateInstance(System.Type.GetType(ca.SpellScriptName)) as SpellEffect;
        }
        CardsCreatedThisGame.Add(UniqueCardID, this);
    }

    public void ResetManaCost()
    {
        CurrentResourceCost = baseResourceCost;
    }

    // STATIC (for managing IDs)
    public static Dictionary<int, CardLogic> CardsCreatedThisGame = new Dictionary<int, CardLogic>();

}
