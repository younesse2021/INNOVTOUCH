using System;
using Xamarin.Forms;

namespace XForms.Models
{
    public class StoreModel
    {
        public Guid Id => Guid.NewGuid();
        public string Name { get; set; }
    }
}
