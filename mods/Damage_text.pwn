#include <a_samp>
new Text:DamageText[MAX_PLAYERS];

public OnPlayerConnect(playerid)
{
	DamageText[playerid] = TextDrawCreate(135.0, 410.0, " ");
	TextDrawSetOutline(DamageText[playerid], 1);
	return 1;
}

public OnPlayerDisconnect(playerid, reason)
{
	TextDrawDestroy(DamageText[playerid]);
	return 1;
}

public OnPlayerTakeDamage(playerid, issuerid, Float: amount, weaponid)
{
	new String[8];
	format(String, sizeof(String), "%0.1f", amount);
	TextDrawColor(DamageText[playerid], 0xff0000aa);
	TextDrawSetString(DamageText[playerid], String);
	TextDrawShowForPlayer(playerid, DamageText[playerid]);
	SetTimerEx("HideDamageText", 1000, 0, "i", playerid);
	if(issuerid != INVALID_PLAYER_ID)
	{
		TextDrawColor(DamageText[issuerid], 0x00ff00aa);
		TextDrawSetString(DamageText[issuerid], String);
		TextDrawShowForPlayer(issuerid, DamageText[issuerid]);
		SetTimerEx("HideDamageText", 1000, 0, "i", issuerid);
	}
	return 1;
}
forward HideDamageText(playerid);
public HideDamageText(playerid) TextDrawHideForPlayer(playerid, DamageText[playerid]);