
//-----------------------------------------------
//              生成代码不要修改
//-----------------------------------------------

using System.Collections.Generic;

public class TableDataList
{
    public static Dictionary<string, ITableData> RegisterAllTable(DynamicPacket dynamicPacket)
    {
        Dictionary<string, ITableData> tableDic = new Dictionary<string, ITableData>();
        tableDic.Add(typeof(Test1TableMgr).Name, new Test1TableMgr(dynamicPacket));
        tableDic.Add(typeof(Test2TableMgr).Name, new Test2TableMgr(dynamicPacket));
        tableDic.Add(typeof(Test3TableMgr).Name, new Test3TableMgr(dynamicPacket));
        tableDic.Add(typeof(Test4TableMgr).Name, new Test4TableMgr(dynamicPacket));
        return tableDic;
    }
}
