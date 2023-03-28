﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Verwaltungsprogramm
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (tb_password.Text.Equals(tb_confirmpw.Text))
            {
                if (SQLClass.Register(tb_username.Text, tb_password.Text, tb_prename.Text, tb_lastname.Text))
                {
                    Menu menu = new Menu();
                    this.Hide();
                    menu.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Dieser Benutzername ist bereits vergeben!", "Registrierungsfehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Die eingegebenen Passwörter stimmen nicht überein!", "Registrierungsfehler",  MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txt_mail_TextChanged(object sender, EventArgs e)
        {
            IsValidEmail(txt_mail.Text);
        }

        bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false; // suggested by @TK-421
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }
    }
}
