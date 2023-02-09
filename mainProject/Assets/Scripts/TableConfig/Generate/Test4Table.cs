
//-----------------------------------------------
//              生成代码不要修改
//-----------------------------------------------

using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class Test4Table
{
    /// <summary>
    /// int类型
    /// </summary>
    public int ID;
    /// <summary>
    /// float类型
    /// </summary>
    public float HP;
    /// <summary>
    /// bool类型
    /// </summary>
    public bool HasUse;
    /// <summary>
    /// string类型
    /// </summary>
    public string Name1;
    /// <summary>
    /// string类型
    /// </summary>
    public string Name2;
    /// <summary>
    /// int数组
    /// </summary>
    public List<int> Vec1;
    /// <summary>
    /// float数组
    /// </summary>
    public List<float> Vec2;
    /// <summary>
    /// string数组
    /// </summary>
    public List<string> Vec4;
    /// <summary>
    /// intint字典
    /// </summary>
    public Dictionary<int, int> Map1;
    /// <summary>
    /// intfloat字典
    /// </summary>
    public Dictionary<int, float> Map2;
    /// <summary>
    /// intstring字典
    /// </summary>
    public Dictionary<int, string> Map4;
    /// <summary>
    /// stringint字典
    /// </summary>
    public Dictionary<string, int> Map5;
    /// <summary>
    /// stringfloat字典
    /// </summary>
    public Dictionary<string, float> Map6;
    /// <summary>
    /// stringstring字典
    /// </summary>
    public Dictionary<string, string> Map8;

    public void Deserialize (DynamicPacket packet)
    {
        ID = packet.PackReadInt32();
        HP = packet.PackReadFloat();
        HasUse = packet.PackReadBoolean();
        Name1 = packet.PackReadString();
        Name2 = packet.PackReadString();
        Vec1 = SheetGenCommonFunc.GetListInt(packet.PackReadString());
        Vec2 = SheetGenCommonFunc.GetListFloat(packet.PackReadString());
        Vec4 = SheetGenCommonFunc.GetListString(packet.PackReadString());
        Map1 = SheetGenCommonFunc.GetDictIntInt(packet.PackReadString());
        Map2 = SheetGenCommonFunc.GetDictIntFloat(packet.PackReadString());
        Map4 = SheetGenCommonFunc.GetDictIntString(packet.PackReadString());
        Map5 = SheetGenCommonFunc.GetDictStringInt(packet.PackReadString());
        Map6 = SheetGenCommonFunc.GetDictStringFloat(packet.PackReadString());
        Map8 = SheetGenCommonFunc.GetDictStringString(packet.PackReadString());
    }
}

public class Test4TableMgr : ITableData
{
    public Test4TableMgr(DynamicPacket packet)
    {
        Deserialize(packet);
    }

    private Dictionary<int, Test4Table> mDict = new Dictionary<int, Test4Table>();
    
    public Dictionary<int, Test4Table> Dict
    {
        get {return mDict;}
    }

    public void Deserialize (DynamicPacket packet)
    {
        int num = (int)packet.PackReadInt32();
        for (int i = 0; i < num; i++)
        {
            Test4Table item = new Test4Table();
            item.Deserialize(packet);
            if (mDict.ContainsKey(item.ID))
            {
                mDict[item.ID] = item;
            }
            else
            {
                mDict.Add(item.ID, item);
            }
        }
    }
    
    public Test4Table GetDataByID(int id)
    {
        if(mDict.ContainsKey(id))
        {
            return mDict[id];
        }
        
        return null;
    }
}
