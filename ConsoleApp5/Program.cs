using Hangfire;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using LuaTableToCsSharp;


namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            string luatable = @"{1=0,2=0,3=0,4=0,5={},6=0,7={s010GameConfig={s008wPayType=0,s009wCostType=2,s015dwReservedRule2=2,s006ClubId=0,s010wCostValue=0,s010wCellScore=1,s014wPlayCountRule=8,s013wHadPlayCount=0,s010dwPlayRule=738459648,s010wSubGameID=112,s009wMaxScore=0,s015dwReservedRule1=0,s015sPrivateTableID=0},s006GameID=112},8=1}";

            SharpluaTable lua = new SharpluaTable();
            var dic = lua.Parse(luatable.Trim());
            Console.WriteLine(dic["7"]);
            SharpluaTable luaitem = new SharpluaTable();
            var items = luaitem.Parse(dic["7"]);
            var gameconfig = new SharpluaTable().Parse(items["s010GameConfig"]);

            string str = "{s010GameConfig={s008wPayType=0,s009wCostType=2,s015dwReservedRule2=2,s006ClubId=0,s010wCostValue=0,s010wCellScore=1,s014wPlayCountRule=8,s013wHadPlayCount=0,s010dwPlayRule=738459648,s010wSubGameID=112,s009wMaxScore=0,s015dwReservedRule1=0,s015sPrivateTableID=0},s006GameID=112}";
            var item = new SharpluaTable().Parse(str);

        }
    }

    
}
