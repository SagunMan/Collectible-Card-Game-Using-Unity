using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCollection : MonoBehaviour {

    public CardAsset cardAsset;
	
    // Update is called once per frame
	void OnMouseUp () {
        
            new ShowMessageCommand(cardAsset.Lore, 10f).AddToQueue();
        
	}
}
