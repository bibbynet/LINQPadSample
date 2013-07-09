<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	//test void method
	TestHelper.DoSomething();
	
	//test value method
	//TestHelper.DoGetSomething();
}


public static class TestHelper
{
	public static void DoSomething()
	{
		var tc=new TestClass();
		"Test Start".ToTitle();
		tc.DoSomething();
		"Test End".ToTitle();
	}
	
	async public static void DoGetSomething()
	{
		var tc=new TestClass();
		"Test Start".ToTitle();
		var ss = await tc.GetSomething();
		ss.Dump();
		"Test End".ToTitle();
	}	
	
	public static void ToTitle(this string st)
	{
		string.Format("==={0}===",st).Dump();
	}
}

public class TestClass 
{
	public Task DoSomething()
	{
		var t=new Task(()=>{		
			Thread.Sleep(3000);
			"DoSomethingMethod..".Dump();
		});
		t.Start();
		return t;
	}
	
	public Task<string> GetSomething()
	{
		var t=new Task<string>(()=>{
			Thread.Sleep(3000);
			return "GetSomethingMethod..";
		});
		t.Start();
		return t;
	}
}

// Define other methods and classes here
