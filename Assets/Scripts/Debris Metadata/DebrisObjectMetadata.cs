using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Debris Object", menuName = "New Debris Object")]
public class DebrisObjectMetadata : ScriptableObject
{
    public new string name;
    public int hydrogen;
    public int helium;
    public int oxygen;
    public int carbon;

    public Mesh mesh;
    public Material material;
}
