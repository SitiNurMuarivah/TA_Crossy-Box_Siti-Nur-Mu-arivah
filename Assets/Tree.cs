using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    static HashSet<Vector3> positionSet = new HashSet<Vector3>();

    public static HashSet<Vector3> AllPositions{ get => new HashSet<Vector3>(positionSet);}
    // Start is called before the first frame update
    private void OnEnable()
    {
        positionSet.Add(this.transform.position);
    }

    // Update is called once per frame
    private void OnDisable()
    {
        positionSet.Remove(this.transform.position);
    }
}
