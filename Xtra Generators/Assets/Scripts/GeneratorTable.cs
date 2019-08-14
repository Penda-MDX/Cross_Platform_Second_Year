using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorTable : ScriptableObject {

    public string TableTitle;
    public string TableDescription;
    public int minRange;
    public int maxRange;
    //dice combination?
    public List<GeneratorItem> ItemList;

}
