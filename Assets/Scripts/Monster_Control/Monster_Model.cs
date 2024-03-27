using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Model : MonoBehaviour
{
    [SerializeField] private GameObject[] monster_models;
    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();
        UpdateEvol(0);
    }

    public void UpdateEvol(int evolution)
    {
        meshFilter.mesh = monster_models[evolution].GetComponent<MeshFilter>().sharedMesh;
        meshRenderer.materials = monster_models[evolution].GetComponent<MeshRenderer>().sharedMaterials;
    }
}
