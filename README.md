# LuaTableToCSharp
Convert lua table to C# Dictionary


Welcome to the LuaTableToCSharp wiki!
# **How to use it?**
`Install-Package LuaTableToCSharp -Version 1.0.2`

```  string luatable = "{1=0,2=0,3=0,4=2,5={},6=0,7={1=118,s010GameConfig={s008wPayType=0,s009wCostType=0,s015dwReservedRule3=3,s015dwReservedRule2=0,s006ClubId=0,s010wCostValue=0,s010wCellScore=1,s014wPlayCountRule=10,s013wHadPlayCount=0,s010dwPlayRule=0,s010wSubGameID=114,s009wMaxScore=0,s015dwReservedRule1=0,s015sPrivateTableID=0},s006GameID=114},8=1}";

SharpluaTable lua = new SharpluaTable();
var dic = lua.Parse(luatable);
Console.WriteLine(dic["7"]);
SharpluaTable luaitem = new SharpluaTable();
var items = luaitem.Parse(dic["7"]);``` 

[blog](http://www.cnblogs.com/boxrice/p/8512790.html)