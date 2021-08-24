using EscuelaWPF.Core;
using System.Windows;
using System.Windows.Input;

namespace EscuelaWPF.ViewModel
{
    /// <summary>
    /// View Model For a Custom flat window
    /// </summary>
    public class WindowViewModel: BaseViewModel
    {
        #region Private Members
        /// <summary>
        /// Control for this window
        /// </summary>
        private readonly Window Window;
        /// <summary>
        /// Margin arount the window for drop shadow
        /// </summary>
        private int mOuterMarginSize = 10;
        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        private int mWindowRadius = 10;
        #endregion

        #region Public Members

        public bool DimmedOverlayVisible { get; set; } = false;

        /// <summary>
        /// The inner content padding thickness
        /// </summary>
        public Thickness InnerContentPadding { get { return new Thickness(0); } }
        public double WindowMinimumWidth { get; set; } = 800;

        public double WindowMinimumHeight { get; set; } = 400;
        /// <summary>
        /// The size of the resize border around the window
        /// </summary>
        public int ResizeBorder { get; set; } = 6;
        /// <summary>
        /// The border thickness of the resize border around the window taking the oyter margin into account
        /// </summary>
        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder + OuterMarginSize); } }
        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        public int OuterMarginSize
        {
            get
            {
                return Window.WindowState == WindowState.Maximized ? 0 : mOuterMarginSize;
            }
            set
            {
                mOuterMarginSize = value;
            }
        }
        /// <summary>
        /// The thickness around the window to allow for a drop shadow
        /// </summary>
        public Thickness OuterMarginSizeThickness
        {
            get
            {
                return new Thickness(OuterMarginSize);
            }
        }
        /// <summary>
        /// The radius of the edges around the window
        /// </summary>
        public int WindowRadius
        {
            get
            {
                return Window.WindowState == WindowState.Maximized ? 0 : mWindowRadius;
            }
            set
            {
                mWindowRadius = value;
            }
        }
        /// <summary>
        /// The thickness of the edges around the window
        /// </summary>
        public CornerRadius WindowCornerRadius
        {
            get { return new CornerRadius(WindowRadius); }
        }
        /// <summary>
        /// The height of the title bar
        /// </summary>
        public int TitleHeight { get; set; } = 30;

        public GridLength TitleHeightGridLenght { get { return new GridLength(TitleHeight + ResizeBorder); } }

        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Login;
        #endregion

        #region Commands
        /// <summary>
        /// The command to minimize the window
        /// </summary>
        public ICommand MinimizeCommand { get; set; }
        /// <summary>
        /// The command to maximize the window
        /// </summary>
        public ICommand MaximizeCommand { get; set; }
        /// <summary>
        /// The command to close the window
        /// </summary>
        public ICommand CloseCommand { get; set; }
        /// <summary>
        /// The command to open the menu
        /// </summary>
        public ICommand MenuCommand { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        public WindowViewModel(Window window)
        {
            Window = window;

            //Listen to the window resizing
            Window.StateChanged += (sender, e) =>
            {
                //Fire of event for all properties that are affected by a screen resize
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowCornerRadius));
            };

            MinimizeCommand = new RelayCommand(() => Window.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => Window.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => Window.Close());
            MenuCommand = new RelayCommand(()=> SystemCommands.ShowSystemMenu(Window, GetMousePosition()));
        }
        #endregion

        #region Helpers
        /// <summary>
        /// Gets the current mouse position on the screen
        /// </summary>
        /// <returns></returns>
        private Point GetMousePosition()
        {
            // Position of the mouse relative to the window
            var position = Mouse.GetPosition(Window);

            // Add the window position so its a "ToScreen"
            return new Point(position.X + Window.Left, position.Y + Window.Top);
        }
        #endregion
    }
}
