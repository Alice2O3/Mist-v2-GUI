namespace Mist启动器
{
	partial class Form_Mist启动器
	{
		internal static string officialWebsite { get; } = @"https://mist-project.github.io";

		private EnvManager envManager { get; } = new EnvManager();

		internal partial class EnvManager
		{
			internal static string scriptDir { get; } = @"mist-v2";

			internal static string tmpDir { get; } = @"tmp";

			internal static string sourceDir { get; } = @"src";

			internal static string mist_project { get; } = @"mist-v2";

			internal static string venv { get; } = @"venv";

			private string tmpPath { get; set; }

			private string venvPath { get; set; }
		}
	}
}
