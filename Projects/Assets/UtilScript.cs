using UnityEngine;

//this class is going to become a generic script with useful functions in it
//it does not derive from Monobehavior
public class UtilScript
{
    //this function (or method) has a RETURN TYPE
    //this means the function must "return" or "give" something at the end of its code
    //in this case, we're modifying a vector3 and then "returning" that vector3 to whatever
    //called this function
    public static Vector3 Vector3Modify(Vector3 initVec, float xMod, float yMod, float zMod)
    {
        Vector3 returnVec = new Vector3(initVec.x + xMod,
                                        initVec.y + yMod,
                                        initVec.z + zMod);
        return returnVec;
    }
}
