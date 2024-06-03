using System;
using Xamarin.Essentials;

namespace XForms
{
    public static class Settings
    {

        #region Code =>  In - Out
        public static string CodeIn
        {
            get { return Preferences.Get(nameof(CodeIn), string.Empty); }
            set { Preferences.Set(nameof(CodeIn), value); }
        }

        public static string CodeOut
        {
            get { return Preferences.Get(nameof(CodeOut), string.Empty); }
            set { Preferences.Set(nameof(CodeOut), value); }
        }
        #endregion


        public static string NomMagasin
        {
            get { return Preferences.Get(nameof(NomMagasin), string.Empty); }
            set { Preferences.Set(nameof(NomMagasin), value); }
        }


        public static int NumberEmplacement
        {
            get { return Preferences.Get(nameof(Emplacement),0); }
            set { Preferences.Set(nameof(Emplacement), value); }
        }

        public static string Emplacement
        {
            get { return Preferences.Get(nameof(Emplacement), string.Empty); }
            set { Preferences.Set(nameof(Emplacement), value); }
        }

        public static string Rayone
        {
            get { return Preferences.Get(nameof(Rayone), string.Empty); }
            set { Preferences.Set(nameof(Rayone), value); }
        }

        public static int IdInventaire
        {
            get { return Preferences.Get(nameof(IdInventaire),0); }
            set { Preferences.Set(nameof(IdInventaire), value); }
        }

        public static int IdRayone
        {
            get { return Preferences.Get(nameof(IdRayone), 0); }
            set { Preferences.Set(nameof(IdRayone), value); }
        }

        public static int TypeInventaire
        {
            get { return Preferences.Get(nameof(TypeInventaire), 0); }
            set { Preferences.Set(nameof(TypeInventaire), value); }
        }


        //IdInventaire = SelectedInventoryDto.Inventory.Id,
        //            IdRayone = SelectedInventoryDto.Rayone.Id,
        //            NomEmplacement = model,
        //            TypeInventaire = SelectedInventoryDto.Inventory.typeInventaire



        public static string NumAnvontair
        {
            get { return Preferences.Get(nameof(NumAnvontair), string.Empty); }
            set { Preferences.Set(nameof(NumAnvontair), value); }
        }


        public static string ProfileUser
        {
            get { return Preferences.Get(nameof(ProfileUser), string.Empty); }
            set { Preferences.Set(nameof(ProfileUser), value); }
        }


        public static string NomPortable
        {
            get { return Preferences.Get(nameof(NomPortable), string.Empty); }
            set { Preferences.Set(nameof(NomPortable), value); }
        }

        public static string UserName
        {
            get { return Preferences.Get(nameof(UserName), string.Empty); }
            set { Preferences.Set(nameof(UserName), value); }
        }

        public static string HashPass
        {
            get { return Preferences.Get(nameof(HashPass), string.Empty); }
            set { Preferences.Set(nameof(HashPass), value); }
        }

        public static string CurrentSiteId
        {
            get { return Preferences.Get(nameof(CurrentSiteId), string.Empty); }
            set { Preferences.Set(nameof(CurrentSiteId), value); }
        }

        public static string StoredDemarqueProductList
        {
            get { return Preferences.Get(nameof(StoredDemarqueProductList), string.Empty); }
            set { Preferences.Set(nameof(StoredDemarqueProductList), value); }
        }

        public static string SelectedDemarqueTypeId
        {
            get { return Preferences.Get(nameof(SelectedDemarqueTypeId), string.Empty); }
            set { Preferences.Set(nameof(SelectedDemarqueTypeId), value); }
        }

        public static string SelectedDemarqueTypeName
        {
            get { return Preferences.Get(nameof(SelectedDemarqueTypeName), string.Empty); }
            set { Preferences.Set(nameof(SelectedDemarqueTypeName), value); }
        }

        public static bool IsSignIn
        {
            get { return Preferences.Get(nameof(IsSignIn), false); }
            set { Preferences.Set(nameof(IsSignIn), value); }
        }

        public static string StoredSitesData
        {
            get { return Preferences.Get(nameof(StoredSitesData), string.Empty); }
            set { Preferences.Set(nameof(StoredSitesData), value); }
        }

        public static DateTime ValidSession
        {
            get { return Preferences.Get(nameof(ValidSession), new DateTime()); }
            set { Preferences.Set(nameof(ValidSession), value); }
        }

        public static void ClearSettings()
        {
            Preferences.Remove(nameof(CurrentSiteId));
            Preferences.Remove(nameof(IsSignIn));
            Preferences.Remove(nameof(StoredSitesData));
            Preferences.Remove(nameof(HashPass));
            //Preferences.Remove(nameof(ProductsInCartList));
        }
    }
}
