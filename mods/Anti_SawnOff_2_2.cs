#include <a_samp>
enum SawnInfo
{
	SawnChances,
	SawnWeapon,
	SawnAmmo
}
new Sawn[MAX_PLAYERS][SawnInfo], AllowSawn = true, Str[256];
#define MAX_CHANCES 3


public OnPlayerCommandText(playerid, cmdtext[])
{
	if(!strcmp("/Sawn2-2", cmdtext, true) && IsPlayerAdmin(playerid))
	{
	    AllowSawn = AllowSawn ? false : true;
	    SendClientMessageToAll(0xff0000ff, AllowSawn ? ("SawnOff 2-2 האדמין אפשר את שיטת ה") : ("SawnOff 2-2 האדמין חסם את שיטת ה"));
	    return 1;
	}
	return 0;
}
public OnPlayerConnect(playerid)
{
	Sawn[playerid][SawnChances] = 0;
	Sawn[playerid][SawnWeapon] = 0;
	Sawn[playerid][SawnAmmo] = 0;
}
public OnPlayerUpdate(playerid)
{
	if(!AllowSawn)
	{
		new Weapon = GetPlayerWeapon(playerid), Ammo;
		if(Sawn[playerid][SawnWeapon] != Weapon && (Weapon == 26 || Sawn[playerid][SawnWeapon] == 26))
		{
			new Check;
			GetPlayerWeaponData(playerid, 3, Check, Check);
   			Ammo = Sawn[playerid][SawnAmmo] - Check;
      		if(Ammo == 2)
		    {
      			SetPlayerVelocity(playerid, 0, 0, 0.15);
      			Sawn[playerid][SawnChances] ++;
      			format(Str, sizeof(Str), "(%d/%d) SawnOff 2-2 האדמין אסר על שיטת ה ", Sawn[playerid][SawnChances], MAX_CHANCES);
  				SendClientMessage(playerid, 0xff0000ff, Str);
  				if(Sawn[playerid][SawnChances] == MAX_CHANCES) Kick(playerid);
       		}
       		Sawn[playerid][SawnAmmo] = Check;
		    Sawn[playerid][SawnWeapon] = Weapon;
		}
	}
	return 1;
}