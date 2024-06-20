using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentLibrary_
{
    public class PaymentCalculator
    {
        //menghitung harga dikali kuantitas barang yang dibeli
        public static double subtotal(int hargaProduk, int jumlah)
        {
            return hargaProduk * jumlah;
        }

        //menghitung discount denngan nilai acak diantara 5% - 15% menggunakan Random()
        public static double discount(double subtotal)
        {
            Random random = new Random();
            double disc = 0.05 + (0.15 - 0.05) * random.NextDouble();
            disc = subtotal * disc;
            return disc;
        }

        //menghitung tax dengan nilai yang tetap yaitu 5%
        public static double tax(double subtotal)
        {
            return subtotal * 0.05;
        }

        //menghitung Total dengan menjumlahkan subtotal dengan tax dan mengurai dengan discount
        public static double Total(double subtotal, double disc, double tax)
        {
            return subtotal - disc + tax; 
        }

    }
}
