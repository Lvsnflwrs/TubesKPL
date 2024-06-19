using System.Reflection.Emit;

namespace paymentLibrary
{
    public class Class1
    {
        public static double CalculateTotal(int hargaProduk, int jumlah)
        {
            Random random = new Random();
            double disc = 0.05 + (0.15 - 0.05) * random.NextDouble();

            int subtotal = hargaProduk * jumlah;
            Label6.Text = subtotal.ToString;
            double discount = subtotal * disc;
            label7.Text = discount.ToString;
            double tax = subtotal * 0.05;
            label8.Text = tax.ToString;
            double Total = subtotal - discount + tax;
            label9.Text = Total.ToString;
            return Total; 
        }

        public static void ProcessPayment()
        {
            String selectedPaymentMethod = (String)jComboBox1.getSelectedItem();
            switch (selectedPaymentMethod)
            {
                case "Debit Card":
                    jLabel2.setIcon(new javax.swing.ImageIcon(getClass().getResource("/aset/debit card bni 1.png")));
                    method = "Debit";
                    break;
                case "Credit Card":
                    jLabel2.setIcon(new javax.swing.ImageIcon(getClass().getResource("/aset/credit.png")));
                    method = "Credit";
                    break;
                case "Ewallet":
                    jLabel2.setIcon(new javax.swing.ImageIcon(getClass().getResource("/aset/ewallet.png")));
                    method = "Ewallet";
                    break;
                default:
                    System.out.println("Pilihan tidak valid");
                    break;
            }
        }
    }
}
