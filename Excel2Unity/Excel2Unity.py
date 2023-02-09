import os

import xlrd2
import shutil
from Config import EXCEL_DIR, UnityCodeDir
from Config import EXCEL_EXT
from Config import UNITY_TABLE_FIELD_FILTER
from Config import UnityDataDir
from ConfigDataGen import ConfigDataGen
from UnityCodeGen import UnityCodeGen


class Excel2Unity:
    # 构造函数
    def __init__(self):
        self.mExcelFiles = []  # 所有的excel文件

    # 外部处理函数
    def Process(self):
        self.RecursiveSearchExcel(EXCEL_DIR)
        self.ProcessExcelExportUnity()

    # 递归查找文件
    def RecursiveSearchExcel(self, path):
        for pathdir in os.listdir(path):  # 遍历当前目录
            fullpath = os.path.join(path, pathdir)

            if os.path.isdir(fullpath):
                self.RecursiveSearchExcel(fullpath)
            elif os.path.isfile(fullpath):
                if os.path.splitext(fullpath)[1] == EXCEL_EXT:
                    self.mExcelFiles.append(fullpath)

    # 处理excel文件
    def ProcessExcelExportUnity(self):

        allbytesdata = bytes()

        # 删除旧的文件
        deldir(UnityDataDir)
        deldir(UnityCodeDir)

        # 处理每个文件
        for filename in self.mExcelFiles:
            data = xlrd2.open_workbook(filename)
            table = data.sheet_by_index(0)
            fields = self.FilterFieldData(table, UNITY_TABLE_FIELD_FILTER)

            # 数据
            cfgbytes = ConfigDataGen.Process(filename, fields, table)
            allbytesdata += cfgbytes

            # 代码
            UnityCodeGen.Process(filename, fields, table)
            print("do " + filename)

        # 后处理
        ConfigDataGen.Save(allbytesdata, UnityDataDir)
        # UnityCodeGen.GenConfigMangerCode(self.mExcelFiles) Manager就不用自动生成了。
        UnityCodeGen.GenTableListCode(self.mExcelFiles)

    # 筛选字段数据
    def FilterFieldData(self, table, fieldfilter):
        fields = []
        for index in range(table.ncols):
            row = table.cell(1, index).value
            for field in fieldfilter:
                if row == field:
                    fields.append(index)

        return fields


# 删除文件夹
def deldir(dir):
    if not os.path.exists(dir):
        return False
    if os.path.isfile(dir):
        os.remove(dir)
        return
    for i in os.listdir(dir):
        t = os.path.join(dir, i)
        if os.path.isdir(t):
            deldir(t)  # 重新调用次方法
        else:
            os.unlink(t)
    if os.path.exists(dir):
        os.removedirs(dir)  # 递归删除目录下面的空文件夹