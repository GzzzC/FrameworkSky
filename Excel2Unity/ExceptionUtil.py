import os.path
import string
import sys


class ExceptionUtil:

    # 关键字不能为空
    @staticmethod
    def error_key(file_path, row):
        filename = os.path.basename(file_path)
        str = "ERROR  ------------------表格【{}】， 第 【{}】 行的Key不能为空！！！------------------".format(filename, row + 1)
        raise Exception(str)
