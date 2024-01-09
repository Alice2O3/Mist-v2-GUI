namespace Mist启动器
{
	public partial class ImageButton : UserControl
	{
		private Image defaultBackgroundImage;

		private Image hoveredBackgroundImage;

		private Image clickedBackgroundImage;

		public Image DefaultBackgroundImage
		{
			get
			{
				return defaultBackgroundImage;
			}
			set
			{
				defaultBackgroundImage = value;
				BackgroundImage = defaultBackgroundImage;
			}
		}

		public Image HoveredBackgroundImage
		{
			get
			{
				return hoveredBackgroundImage;
			}
			set
			{
				hoveredBackgroundImage = value;
			}
		}

		public Image ClickedBackgroundImage
		{
			get
			{
				return clickedBackgroundImage;
			}
			set
			{
				clickedBackgroundImage = value;
			}
		}

		public ImageButton()
		{
			InitializeComponent();
			MouseEnter += ImageButton_MouseEnter;
			MouseLeave += ImageButton_MouseLeave;
			MouseDown += ImageButton_MouseDown;
			MouseUp += ImageButton_MouseUp;
		}

		private void ImageButton_MouseEnter(object sender, EventArgs e)
		{
			BackgroundImage = hoveredBackgroundImage;
		}

		private void ImageButton_MouseLeave(object sender, EventArgs e)
		{
			BackgroundImage = defaultBackgroundImage;
		}

		private void ImageButton_MouseDown(object sender, EventArgs e)
		{
			BackgroundImage = clickedBackgroundImage;
		}

		private void ImageButton_MouseUp(object sender, EventArgs e)
		{
			BackgroundImage = hoveredBackgroundImage;
		}
	}
}
