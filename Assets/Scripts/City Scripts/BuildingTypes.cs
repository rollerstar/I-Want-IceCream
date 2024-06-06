using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingTypes
{
    public string name;
    public int type;
    public GameObject mesh;

    public BuildingTypes(string newName, int newType, GameObject newMesh)
    {
        name = newName;
        type = newType;
        mesh = newMesh;
    }

}