using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : System.IComparable<Score>
{
    public string name;
    public int time;
    

    public Score(string n, int s)
    {
        name = n;
        time = s;
    }

    public int CompareTo(Score other)
    {
        if (other ==null)
       
            return 0;
            int value = other.time - this.time;
            return (int)value;

        
    }
}
