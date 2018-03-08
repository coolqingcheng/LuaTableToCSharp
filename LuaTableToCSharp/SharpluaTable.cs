using System;
using System.Collections.Generic;

namespace LuaTableToCsSharp
{
    /// <summary>
    /// lua table转C# Dictionary
    /// </summary>
    public class SharpluaTable
    {
        string luatable = "";

        //从{开始解析

        //然后按等号分割，等号前后为一个键值对

        //逗号之后，为另一个键值对

        //如果遇到中途遇到{，一直解析到}为止,都为值


        Dictionary<string, string> dic = new Dictionary<string, string>();

        /// <summary>
        /// luatable 反序列化后的字符串
        /// </summary>
        /// <param name="luatable"></param>
        /// <returns></returns>
        public Dictionary<string, string> Parse(string luatable)
        {
            this.luatable = luatable;
            //解析0位和最后一位，判断是否是luatable格式

            if (luatable[0] != '{')
            {
                throw new Exception("Parse failure， format error(Must begin with {)");
            }

            if (luatable[luatable.Length - 1] != '}')
            {
                throw new Exception("Parse failure， format error(Must end with})");
            }
            string luaKey = string.Empty, LuaValue = string.Empty;
            //标示解析Key还是Value，如果true，那么解析到Key里面，如果是false，那么解析到value里面
            bool iskey = true;


            for (int i = 1; i < luatable.Length; i++)
            {
                //如果是最后一个键值对，那么直接就完了
                if (i+1==luatable.Length&&luatable[i]=='}')
                {
                    dic.Add(luaKey, LuaValue);
                    luaKey = string.Empty;
                    LuaValue = string.Empty;
                    
                    break;
                }
                //如果是逗号，那么存储当前的key value ,跳过当前字符解析
                if (luatable[i] == ',')
                {
                    dic.Add(luaKey, LuaValue);
                    luaKey = string.Empty;
                    LuaValue = string.Empty;
                    iskey = true;  //跳过一个逗号，那么继续解析为key
                    continue;
                }
                else
                {
                    if (luatable[i] == '=')
                    {
                        iskey = false; //如果是等号，那么解析为key,并跳过当前
                        continue;
                    }
                    //如果是二级的{，那么解析到}为止，并把当前的i的值移动到}的下标位置
                    if (luatable[i] == '{')
                    {
                        //LuaValue += luatable[i];
                        int kuohaoCount = 0;
                        for (int j = i; j < luatable.Length; j++)
                        {
                            LuaValue += luatable[j];
                            if (luatable[j] == '{')
                            {
                                kuohaoCount += 1;
                            }
                            if (luatable[j] == '}')
                            {
                                kuohaoCount -= 1;

                                if (kuohaoCount == 0)
                                {
                                    i = j;
                                    break;
                                }
                                else
                                {
                                    //kuohaoCount -= 1;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (iskey)
                        {
                            luaKey += luatable[i];
                        }
                        else
                        {
                            LuaValue += luatable[i];
                        }
                    }

                }
            }

            return dic;

        }




    }
}
