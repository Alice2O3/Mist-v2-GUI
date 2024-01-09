using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Mist启动器
{
	partial class Form_Mist启动器
	{
		internal Form_Mist启动器 Init(string[] args)
		{
			envManager.OnLoad();
			Log("Program started.");
			return this;
		}

		private void Log(object message)
		{
			Console.WriteLine(message);
		}

		private void OpenUrl(string url)
		{
			var runUrl = url.Replace("&", "^&");
			var processStartInfo = new ProcessStartInfo(runUrl);
			processStartInfo.UseShellExecute = true;
			Process.Start(processStartInfo);
		}

		private void ShowLink()
		{
			Log("Show link...");
			OpenUrl(officialWebsite);
		}

		private void DisableButtons()
		{
			imageButtonInstallPython.Enabled = false;
			imageButtonInstallGit.Enabled = false;
			imageButtonChangeSource.Enabled = false;
			imageButtonResetSource.Enabled = false;
			imageButtonPrepareEnv.Enabled = false;
			imageButtonTestEnv.Enabled = false;
			imageButtonClearEnv.Enabled = false;
			imageButtonRunMist.Enabled = false;
		}

		private void EnableButtons()
		{
			imageButtonInstallPython.Enabled = true;
			imageButtonInstallGit.Enabled = true;
			imageButtonChangeSource.Enabled = true;
			imageButtonResetSource.Enabled = true;
			imageButtonPrepareEnv.Enabled = true;
			imageButtonTestEnv.Enabled = true;
			imageButtonClearEnv.Enabled = true;
			imageButtonRunMist.Enabled = true;
        }
	}
}
