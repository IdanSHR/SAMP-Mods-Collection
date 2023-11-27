//====================[ Includes ]====================//
#include <a_samp>
//====================[ News ]====================//
enum sVehicleInfo
{
	vModel,
	vObject,
	Float:vX,
	Float:vY,
	Float:vZ,
	Float:vA,
	vName[32]
}
new sVehicle[][sVehicleInfo] =
{
	{487, 19335, 2285.6890,555.4742,7.7802,180.0, "Hot air baloon"},
	{487, 19335, 2303.2649,554.3996,7.7813,180.0, "Hot air baloon"},
	{493, 1607, 2283.6665,540.5563,0.0,180.0, "Dolphin"},
	{493, 1607, 2279.5413,539.9816,0.0,180.0, "Dolphin"},
	{493, 1607, 2275.8286,539.4717,0.0,180.0, "Dolphin"},
	{493, 1608, 2318.6665,540.5563,0.0,180.0, "Shark"},
	{493, 1608, 2314.5413,539.9816,0.0,180.0, "Shark"},
	{493, 1608, 2309.8286,539.4717,0.0,180.0, "Shark"},
	{571, 1609, 2293.9534,546.8138,1.7944,180.0, "Turtle"}

};

public OnFilterScriptInit()
{
	print("Special vehicles v0.1 by DrPawn Loaded!");
	for(new i; i<sizeof(sVehicle); i++)
	{
	    new sVehicleObject, sVehicleId, Text3D:sVehicleText;
	    sVehicleId = CreateVehicle(sVehicle[i][vModel], sVehicle[i][vX], sVehicle[i][vY], sVehicle[i][vZ], sVehicle[i][vA], -1, -1, 60000);
		LinkVehicleToInterior(sVehicleId, 100);
		sVehicleText = Create3DTextLabel(sVehicle[i][vName], 0xFFF68FAA, sVehicle[i][vX], sVehicle[i][vY], sVehicle[i][vZ], 20.0, 0, 0);
		Attach3DTextLabelToVehicle(sVehicleText, sVehicleId, 0.0, 0.0, 2.0);
		sVehicleObject = CreateObject(sVehicle[i][vObject], 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 100.0);
		AttachObjectToVehicle(sVehicleObject, sVehicleId, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
	}
	return true;
}

public OnPlayerCommandText(playerid, cmdtext[])
{
	if(!strcmp(cmdtext, "/SpecialArea", true))
	{
  		SetPlayerPos(playerid, 2294.1836,554.9611,7.7483);
  		SetPlayerFacingAngle(playerid, 180.0);
  		SetPlayerVirtualWorld(playerid, 0);
  		SetPlayerInterior(playerid, 0);
  		SendClientMessage(playerid, 0xFF8C00AA, "על תכנות האיזור DrPawn - ברוכים הבאים לאיזור המיוחד של השרת, קרדיט ל");
		return true;
	}
	return false;
}