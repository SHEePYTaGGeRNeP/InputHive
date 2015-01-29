using System.Windows.Forms;

namespace InputHiveClient
{
    public static class StaticHelper
    {

        #region Private fields

        #endregion

        #region Constructors

        #endregion

        #region Public Properties

        #endregion

        #region Public Methods

        public static Keys ConvertKeycodeToString(char pCode)
        {
            return (Keys)char.ToUpper(pCode);
        }

        #endregion

        #region Private Methods

        #endregion

         
    }
}