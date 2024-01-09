namespace Mist启动器
{
	internal static class MyApp
	{
		[STAThread]
		static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form_Mist启动器().Init(args));
		}
	}
}
