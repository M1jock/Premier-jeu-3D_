using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayandList : MonoBehaviour
{
    //https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=net-6.0
    [SerializeField]
    List<Transform> list; //List<"Type"> name of the list | exemple : List<int / GameObject / bool ect> name;
                     //List start from '1' and int start from '0'
    public class WaypointInfo
    {
        public int index;
        public Transform target;
        public WaypointInfo(int Index, Transform target)
        {
            index = Index;
            this.target = target;
        }
        public WaypointInfo()
        {
            index = 0;
            target = null;
        }
    }

}
