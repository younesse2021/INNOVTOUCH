using System;

namespace XForms.Interfaces
{
    public interface IToast
    {
        void Alert(string message, ToastLength toastLength, bool showActionButtons);
    }

    public enum ToastLength
    {
        SHORT = 0,
        LONG = 1,
    }
}