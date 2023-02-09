using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/// <summary>
/// 配置表管理类
/// </summary>
public class TableDataManager
{
    private static string dataPath = Application.dataPath + "/Art/TableData/Config.data";
    private static Dictionary<string, ITableData> _tables = new Dictionary<string, ITableData>();
    public static T GetTable<T>() where T : ITableData
    {
        if (_tables.TryGetValue(typeof(T).Name, out ITableData table))
        {
            return (T) table;
        }
        return default(T);
    }
    
    public static void LoadConfig()
    {
        _tables.Clear();
        FileStream fileStream = new FileStream(dataPath, FileMode.Open, FileAccess.Read);
        BinaryReader binaryReader = new BinaryReader(fileStream);
        int cnt = binaryReader.ReadInt32();
        byte[] bytes = binaryReader.ReadBytes(cnt);
        DynamicPacket dynamicPacket = new DynamicPacket(bytes);
        _tables = TableDataList.RegisterAllTable(dynamicPacket);
        
        binaryReader.Close();
        fileStream.Close();
    }
}
