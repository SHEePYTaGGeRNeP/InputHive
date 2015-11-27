using System.Windows.Forms;

namespace InputHiveClient
{
    using System;
    using System.Drawing;
    using System.IO;

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
        public static Image Base64ToImage(string base64String)
        {
            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0,
              imageBytes.Length);

            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }

        #endregion

        #region Private Methods

        #endregion


    }
}