namespace MvcDesignMode
{
    /// <summary>
    /// Options for running in design mode
    /// </summary>
    public class DesignModeOptions
    {   
        private static readonly DesignModeOptions _defaults = new DesignModeOptions
        {
            ControllerSuffix = "Designer",
        };

        public static DesignModeOptions Defaults
        {
            get { return _defaults.Clone(); }
        }

        /// <summary>
        /// Suffix used for designer controllers
        /// </summary>
        /// <remarks>
        /// In order to hide designer controller types from the default 
        /// controller factory a suffix other than "Controller" is used.
        /// </remarks>
        public string ControllerSuffix { get; set; }



        internal DesignModeOptions Clone()
        {
            return new DesignModeOptions
            {
                ControllerSuffix = ControllerSuffix,
            };
        }
    }
}
