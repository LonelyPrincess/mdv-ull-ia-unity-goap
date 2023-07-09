using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GWorld
{
    private static readonly GWorld instance = new GWorld();
    private static WorldStates world;
    private static WorldResources resources;

    static GWorld()
    {
        world = new WorldStates();
        resources = new WorldResources();

        // Speed up the simulation
        // Time.timeScale = 5;
    }

    private GWorld()
    {
    }

    public static GWorld Instance
    {
        get { return instance; }
    }

    public WorldStates GetWorld()
    {
        return world;
    }

    public WorldResources GetSharedResources ()
    {
        return resources;
    }
}
