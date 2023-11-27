#include <a_samp>
#define DIALOG_ID_DM 13454
#define WORLD_DM 500
enum DmInfoEnum
{
	dmCmd[32],
	dmName[32],
	dmWeapon,
	dmInt,
	Float:dmX[8],
	Float:dmY[8],
	Float:dmZ[8],
	Float:dmA[8]
}
new DmInfo[][DmInfoEnum] =
{
	{"/Mini", "Minigun area", 38, 0, {2681.9373, 2692.6274, 2688.9919, 2618.5803, 2618.9507, 2545.8357, 2555.6338, 2526.0496},{2817.6272, 2788.0679, 2704.4971, 2721.6584, 2766.8984, 2838.0811, 2805.8989, 2856.5972},{38.3222,59.0234,28.1563 ,36.5386 ,23.8222 ,10.8203 ,19.9922 ,10.8203},{180.0, 90.0, 270.0, 180.0, 0.0, 270.0}},
	{"/Sawn", "King of SAWN", 26, 0, {1080.2170, 1094.0522, 1041.2982, 1035.4536, 1088.4838, 1063.3312, 1067.5992, 1069.2407},{1359.7446, 1360.0500, 1349.6641, 1328.0459, 1226.0048, 1225.4615, 1265.8745, 1326.1544},{10.8203, 10.8203, 10.8203, 10.8203, 10.8203, 10.8203, 10.8203, 10.8203},{180.0, 180.0, 270.0, 270.0, 0.0, 0.0, 0.0, 180.0}},
	{"/RPG", "Bazooka fight", 35, 16, {-1399.7554, -1364.2175, -1372.3873, -1415.5365, -1394.4240, -1389.7380, -1408.8557, -1400.1998},{1400.1998, 1267.4897, 1214.3397, 1210.5013, 1262.8108, 1245.9320, 1248.7517, 1249.3044},{1039.8741, 1039.8741, 1039.8741, 1039.8741, 1039.8741, 1039.8741, 1039.8741, 1039.8741},{180.0, 90.0, 0.0, 0.0, 180.0, 90.0, 270.0, 270.0}},
	{"/Sniper", "Eye of sniper", 34, 0, {1369.9824, 1395.5688, 1391.1073, 1304.6593, 1304.9692, 1391.1683, 1359.5121, 1329.6956},{2195.5518, 2165.1992, 2106.7166, 2106.3118, 2192.8420, 2192.7415, 2208.1697, 2208.7217},{9.7578, 9.7578, 11.0156, 11.0156, 11.0156, 11.0156, 12.3795, 12.3795},{180.0, 90.0, 90.0, 0.0, 180.0, 180.0, 180.0, 180.0}}
};
new DmArea[MAX_PLAYERS] = {-1, ...};
new DmPlayers[sizeof(DmInfo)];
public OnPlayerConnect(playerid)
{
	DmArea[playerid] = -1;
	return 1;
}
public OnPlayerDisconnect(playerid, reason)
{
	if(DmArea[playerid] == -1)
	{
	    DmPlayers[DmArea[playerid]] --;
	    DmArea[playerid] = -1;
	}
	return 1;
}
public OnPlayerSpawn(playerid)
{
	if(DmArea[playerid] != -1)
	{
	    SetPlayerVirtualWorld(playerid, WORLD_DM);
	    SetPlayerInterior(playerid, DmInfo[DmArea[playerid]][dmInt]);
	    new rand = random(8);
	   	SetPlayerPos(playerid, DmInfo[DmArea[playerid]][dmX][rand], DmInfo[DmArea[playerid]][dmY][rand], DmInfo[DmArea[playerid]][dmZ][rand]);
	    GivePlayerWeapon(playerid, DmInfo[DmArea[playerid]][dmWeapon], 9999);
	    SetPlayerArmour(playerid, 100.0);
	    SendClientMessage(playerid, 0x44ff44, "[DM] /QDm - ùåâøú áçæøä ìàéæåø ä÷øáåú, ìéöéàä ä÷ù");
	}
	return 1;
}
public OnPlayerCommandText(playerid, cmdtext[])
{
	if(DmArea[playerid] != -1 && strcmp(cmdtext, "/QDm", true) != 0) return SendClientMessage(playerid, 0x44ff44, "[DM] /QDm - àéðê éëåì ìáöò ô÷åãåú áàéæåø äîìçîä, ìéöéàä ä÷ù");
	if(!strcmp(cmdtext, "/QDm", true))
	{
	    if(DmArea[playerid] == -1) return SendClientMessage(playerid, 0x44ff44, "[DM] /Dm - àéðê áàéæåø äîìçîä, ìùéâåø ìàéæåø ä÷ù");
		DmPlayers[DmArea[playerid]] --;
		DmArea[playerid] = -1;
		SetPlayerVirtualWorld(playerid, 0);
		SetPlayerInterior(playerid, 0);
		SpawnPlayer(playerid);
        SendClientMessage(playerid, 0x44ff44, "[DM] /Dm - éöàú îàéæåø äîìçîä, ìçæøä ä÷ù");
	    return 1;
	}
	for(new iPos; iPos < sizeof(DmInfo); iPos ++) if(!strcmp(cmdtext, DmInfo[iPos][dmCmd], true))
	{
	    SetPlayerVirtualWorld(playerid, WORLD_DM);
	    SetPlayerInterior(playerid, DmInfo[iPos][dmInt]);
	    new rand = random(8);
	    SetPlayerPos(playerid, DmInfo[iPos][dmX][rand], DmInfo[iPos][dmY][rand], DmInfo[iPos][dmZ][rand]);
	    GivePlayerWeapon(playerid, DmInfo[iPos][dmWeapon], 9999);
	    SetPlayerArmour(playerid, 100.0);
	    DmArea[playerid] = iPos;
	    DmPlayers[iPos] ++;
	    SendClientMessage(playerid, 0x44ff44, "[DM] /QDm - ùåâøú ìàéæåø ä÷øáåú, ìéöéàä ä÷ù");
	    return 1;
	}
	if(!strcmp(cmdtext, "/Dm", true))
	{
	    new dmString[256];
	    for(new iPos; iPos < sizeof(DmInfo); iPos ++) format(dmString, 256, "%s%s [%d]\n", dmString, DmInfo[iPos][dmName], DmPlayers[iPos]);
	    ShowPlayerDialog(playerid, DIALOG_ID_DM, DIALOG_STYLE_LIST, "ùéâåø ìàéæåøé äîìçîä ùì äùøú", dmString, "äùúâø", "çæåø");
		return 1;
	}
	return 0;
}
public OnDialogResponse(playerid, dialogid, response, listitem, inputtext[])
{
	if(dialogid == DIALOG_ID_DM && response) return CallLocalFunction("OnPlayerCommandText", "is", playerid, DmInfo[listitem][dmCmd]), SetPlayerSpecialAction(playerid, SPECIAL_ACTION_USEJETPACK);
	return 1;
}