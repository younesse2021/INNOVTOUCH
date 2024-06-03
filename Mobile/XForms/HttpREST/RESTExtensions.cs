using System;
using System.Collections.Specialized;
using System.Text;

namespace XForms.HttpREST
{
    public static class RESTExtensions
    {
        #region Attach "NameValueCollection" Parameters
        public static Uri AttachParameters(this Uri uri, NameValueCollection parameters)
        {
            var stringBuilder = new StringBuilder();
            string str = "?";
            for (int index = 0; index < parameters.Count; ++index)
            {
                stringBuilder.Append(str + parameters.AllKeys[index] + "=" + parameters[index]);
                str = "&";
            }
            return new Uri(uri + stringBuilder.ToString());
        }
        #endregion
    }
}