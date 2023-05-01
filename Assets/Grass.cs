using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : Terrain
{
    [SerializeField] GameObject treePrefab;

    public override void Generate(int size)
    {
        base.Generate(size);

        var limit = Mathf.FloorToInt((float)size / 3);
        var treeCount = Mathf.FloorToInt((float)size / 3);

        //membuat daftar posisi yang masih kosong
        List<int> emptyPosition = new List<int>();
        for (int i = -limit; i <= limit; i++)
        {
            emptyPosition.Add(i);
        }

        for (int i = 0; i < treeCount; i++)
        {
            //memilih posisi kosong secara random
            var randomIndex = Random.Range(0, emptyPosition.Count - 1);
            var pos = emptyPosition[randomIndex];
            
            //poisi yang terpilih hapus dari daftar posisi kosong
            emptyPosition.RemoveAt(randomIndex);

            //set pohon ke posisi yang terpilih
            var tree = Instantiate(treePrefab, transform);
            tree.transform.localPosition = new Vector3(pos, 0, 0);
        }
    }
}
