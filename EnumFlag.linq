<Query Kind="Program" />

void Main()
{
	//None Status
	var permission = Permissions.None;
	
	"Append create tag".ToTitle();
	permission = permission | Permissions.Create;
	permission.ToString().Dump();
	
	"Append update tag".ToTitle();
	permission = permission | Permissions.Update;
	permission.ToString().Dump();
	
	"Append delete, read, create".ToTitle();
	permission = permission | Permissions.Delete | Permissions.Read | Permissions.Create;
	((int)permission).Dump();
	
	"Get number to show all tags".ToTitle();
	int permissionNumbers = 7;
	var permissionObjects = Enum.ToObject(typeof(Permissions) , permissionNumbers);
	permissionObjects.Dump();
	permissionObjects
	.ToString()
	.Split(',')
	.Select(a=>new { Key =a,Value =(int)Enum.Parse(typeof(Permissions),a) })
	.Dump();
	
	"show permission to whether include Delete tag".ToTitle();
	permission.HasFlag(Permissions.Delete).Dump();
	
	"delete Delete tag".ToTitle();
	(permission & ~Permissions.Delete).ToString().Dump();
}

[FlagsAttribute]
public enum Permissions
{
    None = 0,
    Create = 1,
    Read = 2,
    Update = 4,
    Delete = 8,
    All = Create | Read | Update | Delete
}

public static class Helper
{
	public static void ToTitle(this string str)
	{
		"".Dump();
		string.Format("===={0}====",str).Dump();
	}
}
