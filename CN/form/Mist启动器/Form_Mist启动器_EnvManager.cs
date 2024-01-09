using System.Diagnostics;

namespace Mist启动器
{
	partial class Form_Mist启动器
	{
		partial class EnvManager
		{
			private void WriteFileBytes(string rootDirectory, string fileName, byte[] content)
			{
				var fullFileName = Path.Join(rootDirectory, fileName);
				File.WriteAllBytes(fullFileName, content);
			}

			private void WriteFileLines(string rootDirectory, string fileName, params string[] lines)
			{
				var fullFileName = Path.Join(rootDirectory, fileName);

				using (StreamWriter batFile = new StreamWriter(fullFileName))
				{
					foreach (string line in lines)
					{
						batFile.WriteLine(line);
					}
				}
			}

			private int RunProcess(
				string rootDirectory,
				string batFileName,
				bool useShellExecute,
				params string[] commands
			)
			{
				var rootDirectoryFull = Path.GetFullPath(rootDirectory);
				var fullBatFileName = Path.Join(rootDirectoryFull, batFileName);

				using (StreamWriter file = new StreamWriter(fullBatFileName))
				{
					foreach (string command in commands)
					{
						file.WriteLine(command);
					}
				}

				ProcessStartInfo processStartInfo = new ProcessStartInfo(fullBatFileName);
				processStartInfo.WorkingDirectory = rootDirectoryFull;
				processStartInfo.UseShellExecute = useShellExecute;
				processStartInfo.CreateNoWindow = true;
				processStartInfo.WindowStyle = ProcessWindowStyle.Normal;

				Process p = new Process();
				p.StartInfo = processStartInfo;
				p.Start();
				p.WaitForExit();

				File.Delete(fullBatFileName);

				return p.ExitCode;
			}

			private void RunFile(string rootDirectory, string fileName, byte[] content)
			{
				var rootDirectoryFull = Path.GetFullPath(rootDirectory);
				var fullFileName = Path.Join(rootDirectoryFull, fileName);
				File.WriteAllBytes(fullFileName, content);

				ProcessStartInfo processStartInfo = new ProcessStartInfo(fullFileName);
				processStartInfo.WorkingDirectory = rootDirectoryFull;

				Process p = new Process();
				p.StartInfo = processStartInfo;
				p.Start();
				p.WaitForExit();

				File.Delete(fullFileName);
			}

			private void CopyResourceFiles()
			{
				WriteFileBytes(scriptDir, "build.py", Properties.Resources.build);
				WriteFileBytes(scriptDir, "env_test.py", Properties.Resources.env_test);
				WriteFileBytes(scriptDir, "preparing_env.py", Properties.Resources.preparing_env);
				WriteFileBytes(scriptDir, "requirements.txt", Properties.Resources.requirements);
			}

			private string GetTorchIndex(string cudaVersion)
			{
				return cudaVersion switch
				{
					"" => "",
					"12.1" => "https://download.pytorch.org/whl/cu121",
					"11.8" => "https://download.pytorch.org/whl/cu118",
					"11.7" => "https://download.pytorch.org/whl/cu117",
					"11.6" => "https://download.pytorch.org/whl/cu116",
					"11.3" => "https://download.pytorch.org/whl/cu113",
					"10.2" => "https://download.pytorch.org/whl/cu102",
					_ => "https://download.pytorch.org/whl/cpu"
				};
			}

			private void DeleteDirectoryIfExists(string filePath)
			{
				if (Directory.Exists(filePath))
				{
					Directory.Delete(filePath, true);
				}
			}

			internal void OnLoad()
			{
				Directory.CreateDirectory(scriptDir);

				tmpPath = Path.Join(scriptDir, tmpDir);
				Directory.CreateDirectory(tmpPath);

				venvPath = Path.Join(scriptDir, venv);
				CopyResourceFiles();
			}

			internal void InstallPython(Form_Mist启动器 form_Mist_GUI)
			{
				form_Mist_GUI.Log("Installing Python...");
				RunFile(tmpPath, "python_installer.exe", Properties.Resources.python_installer);
			}

			internal void InstallGit(Form_Mist启动器 form_Mist_GUI)
			{
				form_Mist_GUI.Log("Installing Git...");
				RunFile(tmpPath, "git_installer.exe", Properties.Resources.git_installer);
			}

			internal void ChangeSource(Form_Mist启动器 form_Mist_GUI)
			{
				Thread thread = new Thread(() =>
				{
					form_Mist_GUI.Log("Changing source...");

					form_Mist_GUI.DisableButtons();

					var exitCode = RunProcess(scriptDir, "change_source.bat", false, 
						$"@echo off",
						$"pip config set global.index-url https://pypi.tuna.tsinghua.edu.cn/simple"
					);

					if (exitCode == 0)
					{
						form_Mist_GUI.Log($"Source changed!");
						MessageBox.Show("安装源变更成功！", "变更源", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else
					{
						form_Mist_GUI.Log($"Error changing source!");
						MessageBox.Show("安装源变更失败！", "变更源", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}

					form_Mist_GUI.EnableButtons();

					WriteFileLines(scriptDir, "change_source.bat",
						$"@echo off",
						$"pip config set global.index-url https://pypi.tuna.tsinghua.edu.cn/simple",
						$"@echo on",
						$"pause"
					);
				});

				thread.Start();
			}

			internal void ResetSource(Form_Mist启动器 form_Mist_GUI)
			{
				Thread thread = new Thread(() =>
				{
					form_Mist_GUI.Log("Resetting source...");

					form_Mist_GUI.DisableButtons();

					var exitCode = RunProcess(scriptDir, "reset_source.bat", false,
						$"@echo off",
						$"pip config unset global.index-url"
					);

					if (exitCode == 0)
					{
						form_Mist_GUI.Log($"Source reset!");
						MessageBox.Show("安装源已经重置！", "重置源", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else
					{
						form_Mist_GUI.Log($"Error resetting source!");
						MessageBox.Show("重置安装源失败！", "重置源", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}

					form_Mist_GUI.EnableButtons();

					WriteFileLines(scriptDir, "reset_source.bat",
						$"@echo off",
						$"pip config unset global.index-url",
						$"@echo on",
						$"pause"
					);
				});

				thread.Start();
			}

			internal void PrepareEnvironment(Form_Mist启动器 form_Mist_GUI)
			{
				Thread thread = new Thread(() =>
				{
					form_Mist_GUI.Log("Preparing pytorch environment...");

					form_Mist_GUI.DisableButtons();

					var exitCode_Build = RunProcess(scriptDir, "build.bat", true,
						$"@echo off",
						$"set INSTALL_TORCH=",
						$"set TORCH_INDEX_URL=",
						$"set TORCH_VERSION=",
						$"set TORCHVISION_VERSION=",
						$"set REQS_FILE=",
						$"set INSTALL_XFORMERS=",
						$"set XFORMERS_PACKAGE=",
						$"set PYTHON=python",
						$"set VENV_DIR=%~dp0%{venv}",
						$"mkdir {tmpDir} 2>NUL",
						$"%PYTHON% -c \"\" >{tmpDir}/stdout.txt 2>{tmpDir}/stderr.txt",
						$"if %ERRORLEVEL% == 0 goto :check_pip",
						$"echo Couldn't launch python",
						$"goto :error",
						$":check_pip",
						$"%PYTHON% -mpip --help >{tmpDir}/stdout.txt 2>{tmpDir}/stderr.txt",
						$"if %ERRORLEVEL% == 0 goto :start_venv",
						$"if \"%PIP_INSTALLER_LOCATION%\" == \"\" goto :error",
						$"%PYTHON% \"%PIP_INSTALLER_LOCATION%\" >{tmpDir}/stdout.txt 2>{tmpDir}/stderr.txt",
						$"if %ERRORLEVEL% == 0 goto :start_venv",
						$"echo Couldn't install pip",
						$"goto :error",
						$":start_venv",
						$"if [\"%VENV_DIR%\"] == [\"-\"] goto :build",
						$"if [\"%SKIP_VENV%\"] == [\"1\"] goto :build",
						$"dir \"%VENV_DIR%\\Scripts\\Python.exe\" >{tmpDir}/stdout.txt 2>{tmpDir}/stderr.txt",
						$"if %ERRORLEVEL% == 0 goto :activate_venv",
						$"for /f \"delims=\" %%i in ('CALL %PYTHON% -c \"import sys; print(sys.executable)\"') do set PYTHON_FULLNAME=\"%%i\"",
						$"echo Creating venv in directory %VENV_DIR% using python %PYTHON_FULLNAME%",
						$"%PYTHON_FULLNAME% -m venv \"%VENV_DIR%\" >{tmpDir}/stdout.txt 2>{tmpDir}/stderr.txt",
						$"if %ERRORLEVEL% == 0 goto :activate_venv",
						$"echo Unable to create venv in directory \"%VENV_DIR%\"",
						$"goto :error",
						$":activate_venv",
						$"set PYTHON=\"%VENV_DIR%\\Scripts\\Python.exe\"",
						$"echo venv %PYTHON%",
						$":build",
						$"%PYTHON% build.py",
						$"pause",
						$"exit /b",
						$":error",
						$"echo.",
						$"echo Launch unsuccessful. Exiting.",
						$"pause"
					);

					form_Mist_GUI.Log($"Environment prepared!");

					form_Mist_GUI.EnableButtons();

					WriteFileLines(scriptDir, "build.bat",
						$"@echo off",
						$"",
						$"set INSTALL_TORCH=",
						$"set TORCH_INDEX_URL=",
						$"set TORCH_VERSION=",
						$"set TORCHVISION_VERSION=",
						$"set REQS_FILE=",
						$"set INSTALL_XFORMERS=",
						$"set XFORMERS_PACKAGE=",
						$"",
						$"set PYTHON=python",
						$"set VENV_DIR=%~dp0%{venv}",
						$"",
						$"mkdir {tmpDir} 2>NUL",
						$"",
						$"%PYTHON% -c \"\" >{tmpDir}/stdout.txt 2>{tmpDir}/stderr.txt",
						$"if %ERRORLEVEL% == 0 goto :check_pip",
						$"echo Couldn't launch python",
						$"goto :error",
						$"",
						$":check_pip",
						$"%PYTHON% -mpip --help >{tmpDir}/stdout.txt 2>{tmpDir}/stderr.txt",
						$"if %ERRORLEVEL% == 0 goto :start_venv",
						$"if \"%PIP_INSTALLER_LOCATION%\" == \"\" goto :error",
						$"%PYTHON% \"%PIP_INSTALLER_LOCATION%\" >{tmpDir}/stdout.txt 2>{tmpDir}/stderr.txt",
						$"if %ERRORLEVEL% == 0 goto :start_venv",
						$"echo Couldn't install pip",
						$"goto :error",
						$"",
						$":start_venv",
						$"if [\"%VENV_DIR%\"] == [\"-\"] goto :build",
						$"if [\"%SKIP_VENV%\"] == [\"1\"] goto :build",
						$"",
						$"dir \"%VENV_DIR%\\Scripts\\Python.exe\" >{tmpDir}/stdout.txt 2>{tmpDir}/stderr.txt",
						$"if %ERRORLEVEL% == 0 goto :activate_venv",
						$"",
						$"for /f \"delims=\" %%i in ('CALL %PYTHON% -c \"import sys; print(sys.executable)\"') do set PYTHON_FULLNAME=\"%%i\"",
						$"echo Creating venv in directory %VENV_DIR% using python %PYTHON_FULLNAME%",
						$"%PYTHON_FULLNAME% -m venv \"%VENV_DIR%\" >{tmpDir}/stdout.txt 2>{tmpDir}/stderr.txt",
						$"if %ERRORLEVEL% == 0 goto :activate_venv",
						$"echo Unable to create venv in directory \"%VENV_DIR%\"",
						$"goto :error",
						$"",
						$":activate_venv",
						$"set PYTHON=\"%VENV_DIR%\\Scripts\\Python.exe\"",
						$"echo venv %PYTHON%",
						$"",
						$":build",
						$"%PYTHON% build.py",
						$"pause",
						$"exit /b",
						$"",
						$":error",
						$"echo.",
						$"echo Launch unsuccessful. Exiting.",
						$"pause"
					);
				});

				thread.Start();
			}

			internal void TestEnvironment(Form_Mist启动器 form_Mist_GUI)
			{
				Thread thread = new Thread(() =>
				{
					if (Directory.Exists(venvPath))
					{
						form_Mist_GUI.Log("Running program...");

						form_Mist_GUI.DisableButtons();

						var exitCode = RunProcess(scriptDir, "env_test.bat", true,
							$"@echo off",
							$"set VENV_DIR=%~dp0%{venv}",
							$"set PYTHON=\"%VENV_DIR%\\Scripts\\Python.exe\"",
							$"%PYTHON% env_test.py",
							$"@echo on",
							$"pause"
						);

						if (exitCode == 0)
						{
							form_Mist_GUI.Log($"Environment configured successfully!");
						}
						else
						{
							form_Mist_GUI.Log($"Error testing environment!");
						}

						form_Mist_GUI.EnableButtons();
					}
					else
					{
						form_Mist_GUI.Log("Environment not set!");
						MessageBox.Show("环境没有配置！", "测试环境", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}

					WriteFileLines(scriptDir, "env_test.bat",
						$"@echo off",
						$"",
						$"set VENV_DIR=%~dp0%{venv}",
						$"set PYTHON=\"%VENV_DIR%\\Scripts\\Python.exe\"",
						$"",
						$":: Put your codes here",
						$"",
						$"%PYTHON% env_test.py",
						$"",
						$"@echo on",
						$"pause"
					);
				});

				thread.Start();
			}

			internal void ClearEnvironment(Form_Mist启动器 form_Mist_GUI)
			{
				DeleteDirectoryIfExists(venvPath);
				form_Mist_GUI.Log($"Environment cleared!");
				MessageBox.Show("环境已清除！", "清除环境", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}

			internal void RunMist(Form_Mist启动器 form_Mist_GUI)
			{
				var startFile = "mist-webui.py";
				var batName = "mist-webui.bat";

				Thread thread = new Thread(() =>
				{
					if (Directory.Exists(venvPath))
					{
						form_Mist_GUI.Log("Running program...");

						form_Mist_GUI.DisableButtons();

						var exitCode = RunProcess(scriptDir, batName, true,
							$"@echo off",
							$"set VENV_DIR=%~dp0%{venv}",
							$"set PYTHON=\"%VENV_DIR%\\Scripts\\Python.exe\"",
							$"cd {sourceDir}",
							$"%PYTHON% {startFile}",
							$"@echo on",
							$"pause"
						);

						if (exitCode == 0)
						{
							form_Mist_GUI.Log($"Program finished successfully!");
						}
						else
						{
							form_Mist_GUI.Log($"Error running program!");
						}

						form_Mist_GUI.EnableButtons();
					}
					else
					{
						form_Mist_GUI.Log("Environment not set!");
						MessageBox.Show("环境没有配置！", "启动Mist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}

					WriteFileLines(scriptDir, batName,
						$"@echo off",
						$"",
						$"set VENV_DIR=%~dp0%{venv}",
						$"set PYTHON=\"%VENV_DIR%\\Scripts\\Python.exe\"",
						$"",
						$":: Switch to the project",
						$"",
						$"cd {sourceDir}",
						$"",
						$":: Put your codes here",
						$"",
						$"%PYTHON% {startFile}",
						$"",
						$"@echo on",
						$"pause"
					);
				});

				thread.Start();
			}
		}
	}
}
