using EscuelaWPF.Service;
using Ninject;

namespace EscuelaWPF.Core
{
    /// <summary>
    /// The invertion of control container for our app
    /// </summary>
    public static class IoC
    {

        #region Public Properties
        /// <summary>
        /// The kernel for our IoC Container
        /// </summary>
        public static IKernel Kernel { get; private set; } = new StandardKernel();

        public static IUIManager UI => Get<IUIManager>();

        public static ApplicationViewModel App => Get<ApplicationViewModel>();

        public static SettingsViewModel Settings => Get<SettingsViewModel>();

        public static TeacherService TeacherService => Get<TeacherService>();

        public static LoginService LoginService => Get<LoginService>();

        public static StudentService StudentService => Get<StudentService>();

        public static GuardianService GuardianService => Get<GuardianService>();

        public static SectionService SectionService => Get<SectionService>();

        public static AccessService AccessService => Get<AccessService>();

        public static AuthorizationService AuthorizationService => Get<AuthorizationService>();

        public static AttendanceService AttendanceService => Get<AttendanceService>();

        public static SearchService SearchService => Get<SearchService>();

        #endregion

        #region Init
        /// <summary>
        /// Sets up the IoC container, binds all information required
        /// NOTE: Must be called as soon as your app starts to ensure all services can be found
        /// </summary>
        public static void Setup()
        {
            // Bind all required view models
            BindViewModels();
        }

        private static void BindViewModels()
        {
            // Binds to a single instance of Application VM
            Kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel());

            Kernel.Bind<SettingsViewModel>().ToConstant(new SettingsViewModel());


        }

        #endregion
        /// <summary>
        /// Type T gets a service from IoC of the specified type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }
    }
}
