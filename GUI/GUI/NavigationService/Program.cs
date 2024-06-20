using System;
using System.Windows.Forms;
using HalamanUtama;
using GUIWishlist;
using NavigationService;

namespace YourNamespace
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var mainForm = new Form1(1, null); // Dummy initialization for demonstration
            var wishlistForm = new Form1(1, null); // Dummy initialization for demonstration

            var navigationService = new NavigationServiceImplementation(mainForm, wishlistForm);

            // Re-initialize forms with navigationService
            mainForm = new HalamanUtama.Form1(1, navigationService);
            wishlistForm = new GUIWishlist.Form1(1, navigationService);

            Application.Run(mainForm);
        }
    }
}
