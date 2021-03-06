﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using Random = UnityEngine.Random;

public class Demo : MonoBehaviour 
{
    public MeshFilter filter;
    private Mesh mesh;
    private MeshTool tool;

    [Header("Config")]
    [Range(0, 16)]
    public int complexity;
    public bool correction;
    public bool spin;

    private void Awake()
    {
        mesh = new Mesh();
        tool = new MeshTool(mesh, MeshTopology.Triangles);
        filter.sharedMesh = mesh;
    }

    public void Refresh()
    {
        //SphereGenerator.Sphere(tool, 0.5f, level, correction);
        SphereGenerator.Hemisphere(tool, 0.5f, complexity, correction);

        if (spin)
        {
            transform.localRotation = Quaternion.Euler(-90, 0, 0);
            transform.Rotate(Vector3.up, Random.value * 360);
        }
    }

    public void Update()
    {
        Refresh();
    }
}
