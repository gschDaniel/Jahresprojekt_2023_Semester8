using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Verwaltungsprogramm.Classes;

namespace Verwaltungsprogramm
{
    public partial class Barcode : Form
    {
        public Barcode()
        {
            InitializeComponent();
        }

        private void btn_barcode_Click(object sender, EventArgs e)
        {
            string barcode = tb_scan.Text;
            Book book = SQLClass.GetBookByBarcode(barcode);

            if (book is null) 
            {
                MessageBox.Show("Buch mit folgendem Barcode konnte nicht gefunden werden: " + barcode, "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                lbl_resultauthor.Text = book.Author;
                lbl_resulttitle.Text = book.Title;
                lbl_resultrealeasedate.Text = book.ReleaseDate.ToString();
                lbl_resultdesc.Text = book.Description;
            }
        }
    }
}
