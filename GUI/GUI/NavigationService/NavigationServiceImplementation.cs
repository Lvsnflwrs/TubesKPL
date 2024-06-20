using HalamanUtama;
using GUIWishlist;
using System.Windows.Forms;

namespace NavigationService
{
    public class NavigationServiceImplementation : navigationService
    {
        private Form mainForm;
        private Form wishlistForm;

        public NavigationServiceImplementation(Form mainForm, Form wishlistForm)
        {
            this.mainForm = mainForm;
            this.wishlistForm = wishlistForm;
        }

        public void NavigateToWishlist(int loginId)
        {
            var wishlist = new GUIWishlist.Form1(loginId, this);
            wishlist.StartPosition = FormStartPosition.CenterScreen;
            wishlist.Show();
            mainForm.Hide();
        }

        public void NavigateToMain(int loginId)
        {
            var main = new HalamanUtama.Form1(loginId, this);
            main.StartPosition = FormStartPosition.CenterScreen;
            main.Show();
            wishlistForm.Hide();
        }
    }
}
