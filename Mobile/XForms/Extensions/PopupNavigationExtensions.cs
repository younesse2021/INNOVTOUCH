using Rg.Plugins.Popup.Contracts;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XForms
{
    public static class PopNavigationExtensions
    {
        public static async Task PushSingleAsync(
            this IPopupNavigation nav,
            PopupPage page,
            bool animated = true)
        {
            if (nav.PopupStack.Count == 0 || nav.PopupStack.Last().GetType() != page.GetType())
            {
                await nav.PushAsync(page, animated).ConfigureAwait(false);
            }
        }

        public static async Task PopSafeAsync(
            this IPopupNavigation nav,
            bool animated = true)
        {
            if (nav.PopupStack.Count > 0)
            {
                await nav.PopAsync(animated).ConfigureAwait(false);
            }
        }
    }
}