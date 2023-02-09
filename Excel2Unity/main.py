import colorsys
import sys

from Excel2Unity import Excel2Unity


def main():
    print("开始执行")
    Excel2Unity().Process()
    print("执行成功！！！！！！")


if __name__ == '__main__':
    try:
        main()
    except Exception as e:
        print(e)




