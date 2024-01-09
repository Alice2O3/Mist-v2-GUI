using Mist启动器.Properties;

namespace Mist启动器
{
    public partial class Form_Mist启动器 : Form
    {
        public Form_Mist启动器()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Mist启动器));
            imageButtonInstallPython = new ImageButton();
            imageButtonInstallGit = new ImageButton();
            imageButtonChangeSource = new ImageButton();
            imageButtonResetSource = new ImageButton();
            imageButtonRunMist = new ImageButton();
            imageButtonPrepareEnv = new ImageButton();
            imageButtonTestEnv = new ImageButton();
            imageButtonClearEnv = new ImageButton();
            imageButtonKnowMore = new ImageButton();
            SuspendLayout();
            // 
            // imageButtonInstallPython
            // 
            imageButtonInstallPython.BackgroundImage = Resources.button_download;
            resources.ApplyResources(imageButtonInstallPython, "imageButtonInstallPython");
            imageButtonInstallPython.ClickedBackgroundImage = Resources.button_download_clicked;
            imageButtonInstallPython.DefaultBackgroundImage = Resources.button_download;
            imageButtonInstallPython.HoveredBackgroundImage = Resources.button_download_hovered;
            imageButtonInstallPython.Name = "imageButtonInstallPython";
            imageButtonInstallPython.Click += ImageButtonInstallPython_Click;
            // 
            // imageButtonInstallGit
            // 
            imageButtonInstallGit.BackgroundImage = Resources.button_download;
            resources.ApplyResources(imageButtonInstallGit, "imageButtonInstallGit");
            imageButtonInstallGit.ClickedBackgroundImage = Resources.button_download_clicked;
            imageButtonInstallGit.DefaultBackgroundImage = Resources.button_download;
            imageButtonInstallGit.HoveredBackgroundImage = Resources.button_download_hovered;
            imageButtonInstallGit.Name = "imageButtonInstallGit";
            imageButtonInstallGit.Click += ImageButtonInstallGit_Click;
            // 
            // imageButtonChangeSource
            // 
            imageButtonChangeSource.BackgroundImage = Resources.button_change_source;
            resources.ApplyResources(imageButtonChangeSource, "imageButtonChangeSource");
            imageButtonChangeSource.ClickedBackgroundImage = Resources.button_change_source_clicked;
            imageButtonChangeSource.DefaultBackgroundImage = Resources.button_change_source;
            imageButtonChangeSource.HoveredBackgroundImage = Resources.button_change_source_hovered;
            imageButtonChangeSource.Name = "imageButtonChangeSource";
            imageButtonChangeSource.Click += ImageButtonChangeSource_Click;
            // 
            // imageButtonResetSource
            // 
            imageButtonResetSource.BackgroundImage = Resources.button_reset_source;
            resources.ApplyResources(imageButtonResetSource, "imageButtonResetSource");
            imageButtonResetSource.ClickedBackgroundImage = Resources.button_reset_source_clicked;
            imageButtonResetSource.DefaultBackgroundImage = Resources.button_reset_source;
            imageButtonResetSource.HoveredBackgroundImage = Resources.button_reset_source_hovered;
            imageButtonResetSource.Name = "imageButtonResetSource";
            imageButtonResetSource.Click += ImageButtonResetSource;
            // 
            // imageButtonRunMist
            // 
            imageButtonRunMist.BackgroundImage = Resources.button_run_mist;
            resources.ApplyResources(imageButtonRunMist, "imageButtonRunMist");
            imageButtonRunMist.ClickedBackgroundImage = Resources.button_run_mist_clicked;
            imageButtonRunMist.DefaultBackgroundImage = Resources.button_run_mist;
            imageButtonRunMist.HoveredBackgroundImage = Resources.button_run_mist_hovered;
            imageButtonRunMist.Name = "imageButtonRunMist";
            imageButtonRunMist.Click += ImageButtonRunMist_Click;
            // 
            // imageButtonPrepareEnv
            // 
            imageButtonPrepareEnv.BackgroundImage = Resources.button_prepare_environment;
            resources.ApplyResources(imageButtonPrepareEnv, "imageButtonPrepareEnv");
            imageButtonPrepareEnv.ClickedBackgroundImage = Resources.button_prepare_environment_clicked;
            imageButtonPrepareEnv.DefaultBackgroundImage = Resources.button_prepare_environment;
            imageButtonPrepareEnv.HoveredBackgroundImage = Resources.button_prepare_environment_hovered;
            imageButtonPrepareEnv.Name = "imageButtonPrepareEnv";
            imageButtonPrepareEnv.Click += ImageButtonPrepareEnv_Click;
            // 
            // imageButtonTestEnv
            // 
            imageButtonTestEnv.BackgroundImage = Resources.button_test_environment;
            resources.ApplyResources(imageButtonTestEnv, "imageButtonTestEnv");
            imageButtonTestEnv.ClickedBackgroundImage = Resources.button_test_environment_clicked;
            imageButtonTestEnv.DefaultBackgroundImage = Resources.button_test_environment;
            imageButtonTestEnv.HoveredBackgroundImage = Resources.button_test_environment_hovered;
            imageButtonTestEnv.Name = "imageButtonTestEnv";
            imageButtonTestEnv.Click += ImageButtonTestEnv_Click;
            // 
            // imageButtonClearEnv
            // 
            imageButtonClearEnv.BackgroundImage = Resources.button_clear_environment;
            resources.ApplyResources(imageButtonClearEnv, "imageButtonClearEnv");
            imageButtonClearEnv.ClickedBackgroundImage = Resources.button_clear_environment_clicked;
            imageButtonClearEnv.DefaultBackgroundImage = Resources.button_clear_environment;
            imageButtonClearEnv.HoveredBackgroundImage = Resources.button_clear_environment_hovered;
            imageButtonClearEnv.Name = "imageButtonClearEnv";
            imageButtonClearEnv.Click += ImageButtonClearEnv_Clicked;
            // 
            // imageButtonKnowMore
            // 
            imageButtonKnowMore.BackgroundImage = Resources.know_more;
            resources.ApplyResources(imageButtonKnowMore, "imageButtonKnowMore");
            imageButtonKnowMore.ClickedBackgroundImage = Resources.know_more;
            imageButtonKnowMore.DefaultBackgroundImage = Resources.know_more;
            imageButtonKnowMore.HoveredBackgroundImage = Resources.know_more;
            imageButtonKnowMore.Name = "imageButtonKnowMore";
            imageButtonKnowMore.Click += ImageButtonKnowMore_Click;
            // 
            // Form_Mist启动器
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            BackgroundImage = Resources.background;
            resources.ApplyResources(this, "$this");
            Controls.Add(imageButtonKnowMore);
            Controls.Add(imageButtonClearEnv);
            Controls.Add(imageButtonTestEnv);
            Controls.Add(imageButtonPrepareEnv);
            Controls.Add(imageButtonRunMist);
            Controls.Add(imageButtonResetSource);
            Controls.Add(imageButtonChangeSource);
            Controls.Add(imageButtonInstallGit);
            Controls.Add(imageButtonInstallPython);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form_Mist启动器";
            ResumeLayout(false);
        }

        private ImageButton imageButtonInstallGit;
        private ImageButton imageButtonChangeSource;
        private ImageButton imageButtonResetSource;
        private ImageButton imageButtonRunMist;
        private ImageButton imageButtonPrepareEnv;
        private ImageButton imageButtonTestEnv;
        private ImageButton imageButtonClearEnv;
        private ImageButton imageButtonKnowMore;
        private ImageButton imageButtonInstallPython;

        private void ImageButtonInstallPython_Click(object sender, EventArgs e)
        {
            envManager.InstallPython(this);
        }

        private void ImageButtonInstallGit_Click(object sender, EventArgs e)
        {
            envManager.InstallGit(this);
        }

        private void ImageButtonChangeSource_Click(object sender, EventArgs e)
        {
            envManager.ChangeSource(this);
        }

        private void ImageButtonResetSource(object sender, EventArgs e)
        {
            envManager.ResetSource(this);
        }

        private void ImageButtonPrepareEnv_Click(object sender, EventArgs e)
        {
            envManager.PrepareEnvironment(this);
        }

        private void ImageButtonTestEnv_Click(object sender, EventArgs e)
        {
            envManager.TestEnvironment(this);
        }

        private void ImageButtonClearEnv_Clicked(object sender, EventArgs e)
        {
            envManager.ClearEnvironment(this);
        }

        private void ImageButtonRunMist_Click(object sender, EventArgs e)
        {
            envManager.RunMist(this);
        }

        private void ImageButtonKnowMore_Click(object sender, EventArgs e)
        {
            ShowLink();
        }
    }
}