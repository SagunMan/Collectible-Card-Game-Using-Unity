using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum TargetingOptions
{
    NoTarget,
    AllCards,
    EnemyCards,
    YourCards,
    AllCharacters,
    EnemyCharacters,
    YourCharacters,
    AllCreatures,
    EnemyCreatures,
    YourCreatures
}

public class CardAsset: ScriptableObject
{

    [Header("General info")]
    [TextArea(2, 3)]
    public string Description;
    public Sprite CardImage;
    public Sprite CardBodyImage;
    public Sprite CardHeaderImage;
    public Sprite CardDescriptionImage;
    public int ResourceCost;

    [Header("Unit info")]
    public int MaxHealth;
    public int Attack;
    public int AttacksForOneTurn = 1;
    public bool Charge;
    public string UnitScriptName;

    [Header("Spell info")]
    public string SpellScriptName;
    public int specialUnitAmount;
    public int specialSpellAmount;
    public TargetingOptions Targets;

}

