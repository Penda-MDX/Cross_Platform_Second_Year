using UnityEngine;
using System.Collections;
using System; //This allows the IComparable Interface

//So that collections can use the Sort() method, 
//this class needs to implement the IComparable interface.

public class FoodType : IComparable<FoodType>
{
    public string name;
    public int toxicity_percentage;
    public int goodness_percentage;

    public FoodType(string newName, int newToxicity)
    {
        name = newName;
        toxicity_percentage = newToxicity;
        goodness_percentage = 100 - toxicity_percentage;

    }

    //This method is required by the IComparable
    //interface. 
    public int CompareTo(FoodType other)
    {
        if (other == null)
        {
            return 1;
        }

        //Return the difference in power.
        return toxicity_percentage - other.toxicity_percentage;
    }
}