using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCahe : MonoBehaviour
{

    public void ClearCaheButton()
    {
        Caching.ClearCache();
        print("Cache Borrado");
    }

    public void PrintCachePats()
    {
        var cachPats = new List<string>();
        Caching.GetAllCachePaths(cachPats);

        print("Conteo de cache = " + Caching.cacheCount);

        foreach (string item in cachPats)
        {
            print("path = "+ item);
        }
    }
}
