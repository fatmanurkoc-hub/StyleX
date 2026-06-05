using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StyleX
{
    public partial class Login : Form
    {
        private TextBox userBox = null!;
        private TextBox passBox = null!;

        private TextBox regUser = null!;
        private TextBox regMail = null!;
        private TextBox regPass = null!;

        private Panel card = null!;

        public Login()
        {
            BuildUI();
        }

        private void BuildUI()
        {
            
            this.Text = "StyleX Login";
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.Sizable;

            
            this.BackColor = Color.FromArgb(70, 0, 20);

            
            card = new Panel();
            card.Size = new Size(500, 600);
            card.BackColor = Color.FromArgb(120, 20, 40);

            card.Location = new Point(
                (this.ClientSize.Width - card.Width) / 2,
                (this.ClientSize.Height - card.Height) / 2
            );

            this.Controls.Add(card);

            
            this.Resize += (s, e) =>
            {
                card.Location = new Point(
                    (this.ClientSize.Width - card.Width) / 2,
                    (this.ClientSize.Height - card.Height) / 2
                );
            };

            
            Label title = new Label();
            title.Text = "StyleX";
            title.Font = new Font("Segoe UI", 40, FontStyle.Bold);
            title.ForeColor = Color.FromArgb(255, 120, 120);
            title.AutoSize = true;
            title.Location = new Point(170, 30);
            card.Controls.Add(title);

            

            userBox = CreateBox("Kullanıcı Adı", 150);
            card.Controls.Add(userBox);

            passBox = CreateBox("Şifre", 220);
            passBox.PasswordChar = '*';
            card.Controls.Add(passBox);

            Button loginBtn = new Button();
            loginBtn.Text = "BAŞLA";
            loginBtn.Size = new Size(300, 50);
            loginBtn.Location = new Point(100, 290);

            loginBtn.BackColor = Color.FromArgb(200, 40, 60);
            loginBtn.ForeColor = Color.White;
            loginBtn.FlatStyle = FlatStyle.Flat;
            loginBtn.FlatAppearance.BorderSize = 0;

            loginBtn.Click += LoginBtn_Click;
            card.Controls.Add(loginBtn);

            

            regUser = CreateBox("Yeni Kullanıcı", 360);
            card.Controls.Add(regUser);

            regMail = CreateBox("E-Mail", 420);
            card.Controls.Add(regMail);

            regPass = CreateBox("Yeni Şifre", 480);
            regPass.PasswordChar = '*';
            card.Controls.Add(regPass);

            Button regBtn = new Button();
            regBtn.Text = "KAYIT OL";
            regBtn.Size = new Size(300, 50);
            regBtn.Location = new Point(100, 540);

            regBtn.BackColor = Color.FromArgb(200, 40, 60);
            regBtn.ForeColor = Color.White;
            regBtn.FlatStyle = FlatStyle.Flat;
            regBtn.FlatAppearance.BorderSize = 0;

            regBtn.Click += RegisterBtn_Click;
            card.Controls.Add(regBtn);
        }

        
        private TextBox CreateBox(string placeholder, int y)
        {
            TextBox t = new TextBox();
            t.Size = new Size(300, 40);
            t.Location = new Point(100, y);

            t.BackColor = Color.FromArgb(120, 20, 40);
            t.ForeColor = Color.White;
            t.BorderStyle = BorderStyle.FixedSingle;

            t.Text = placeholder;

            t.GotFocus += (s, e) =>
            {
                if (t.Text == placeholder)
                    t.Text = "";
            };

            t.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(t.Text))
                    t.Text = placeholder;
            };

            return t;
        }

        
        private void LoginBtn_Click(object? sender, EventArgs e)
        {
            if (userBox.Text == "" || passBox.Text == "" ||
                userBox.Text == "Kullanıcı Adı" || passBox.Text == "Şifre")
            {
                MessageBox.Show("Kullanıcı adı ve şifre giriniz.");
                return;
            }

            ExploreForm ex = new ExploreForm();
            ex.Show();
            this.Hide();
        }

        
        private void RegisterBtn_Click(object? sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(regUser.Text))
            {
                userBox.Text = regUser.Text;
                passBox.Text = "";
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
        }
    }
}




























