using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;

public class VFXManager : Singleton<VFXManager>
{
    #region Variables
    public enum VFXType
    {
        JUMP
    }
    public List<VFXManagerSetup> vfxSetup;
    #endregion

    #region Methods

    public void PlayVFXByType(VFXType vfxType, Vector3 position)
    {
        foreach (var i in vfxSetup)
        {
            if (i.vfxType == vfxType)
            {
                var item = Instantiate(i.prefab);
                item.transform.position = position;
                Destroy(item.gameObject, 5f);
                break;
            }
        }
    }
    #endregion
}

[System.Serializable]
public class VFXManagerSetup
{
    #region Variables
    public VFXManager.VFXType vfxType;
    public GameObject prefab;
    #endregion
}