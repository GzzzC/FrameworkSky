using System.Collections;
using System.Collections.Generic;
using libx;
using UnityEngine;
using System;

public class GameResourcesManager : SingletonBehaviour<GameResourcesManager>
{

    public AssetRequest LoadAssetAsync<T>(string assetName)
    {
        var path = string.Empty;
        if (Assets.GetAssetPath(assetName, out path))
        {
            return Assets.LoadAssetAsync(path, typeof(T));
        }
        else
        {
            Debug.LogError("资源名不存在" + assetName);
            return null;
        }
    }



}