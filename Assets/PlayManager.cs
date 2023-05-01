using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
    [SerializeField] Grass grassPrefab;
    [SerializeField] Road roadPrefab;
    [SerializeField] int initialGrassCount = 5;
    [SerializeField] int horizontalSize;
    [SerializeField] int backViewDistance = -4;
    [SerializeField] int forwardViewDistance = 15;
    [SerializeField, Range(0, 1)] float treeProbability;

    private List<Terrain> terrainList;
    Dictionary<int, Terrain> activeTerrainDict = new Dictionary<int, Terrain>(20);
    private void Start()
    {
        terrainList = new List<Terrain>
            {
                grassPrefab,
                roadPrefab
            };
        //create initial grass pos -4 ---- 4
        for (int zPos = backViewDistance; zPos < initialGrassCount; zPos++)
        {
            var grass = Instantiate(grassPrefab);
            grass.transform.localPosition = new Vector3(0, 0, zPos);
            grass.SetTreePercentage(zPos < -1 ? 1 : 0);
            grass.Generate(horizontalSize);
            activeTerrainDict[zPos] = grass;

        }

        //4 ---- 15
        for (int zPos = initialGrassCount; zPos < forwardViewDistance; zPos++)
        {
            var terrain = SpawnRandomTerrain(zPos);
            terrain.Generate(horizontalSize);
            activeTerrainDict[zPos] = terrain;
        }

        SpawnRandomTerrain(0);
    }

    private Terrain SpawnRandomTerrain(int zPos)
    {
        Terrain terrainCheck = null;
        int randomIndex;
        Terrain terrain = null;
        for (int z = -1; z >= -3; z--)
        {
            var checkPos = zPos + z;
            if (terrainCheck == null)
            {
                terrainCheck = activeTerrainDict[checkPos];
                continue;
            }
            else if (terrainCheck.GetType() != activeTerrainDict[checkPos].GetType())
            {
                randomIndex = Random.Range(0, terrainList.Count);
                terrain = Instantiate(terrainList[randomIndex]);
                terrain.transform.localPosition = new Vector3(0, 0, zPos);
                return terrain;
            }
            else
            {
                continue;
            }
        }

        var candidateTerrain = new List<Terrain>(terrainList);
        for (int i = 0; i < candidateTerrain.Count; i++)
        {
            if (terrainCheck.GetType() == candidateTerrain[i].GetType())
            {
                candidateTerrain.Remove(candidateTerrain[i]);
                break;
            }
        }

        randomIndex = Random.Range(0, candidateTerrain.Count);
        terrain = Instantiate(candidateTerrain[randomIndex]);
        terrain.transform.position = new Vector3(0,0,zPos);
        return terrain;
    }
}
