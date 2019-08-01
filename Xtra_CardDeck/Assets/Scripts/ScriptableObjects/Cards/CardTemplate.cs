using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class CardTemplate : ScriptableObject {
    public string CardName = "New Card";
    public string CardDescription = "This is the situation.";
    public string YesDescription = "Yes";
    public string NoDescription = "No";
    public Sprite CardSprite;

    public List<ActionTemplate> YesActions;
    public List<ActionTemplate> NoActions;
    

}
