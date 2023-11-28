if(!strcmp(cmd, "/Multi", true))
{
	new Pos = -1, Command[128];
	for(new i, l = strlen(cmdtext); i<=l ; i++) if(cmdtext[i] == '/' || i == l)
	{
  		if(Pos == -1) Pos = i;
  		else
    		{
			strmid(Command, cmdtext, Pos, i);
   			CallLocalFunction("OnPlayerCommandText", "ds", playerid, Command);
       			Pos = i;
 		}
	}
	return 1;
}