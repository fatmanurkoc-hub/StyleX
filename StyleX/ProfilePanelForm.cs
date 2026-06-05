using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace StyleX
{
    public partial class ProfilePanelForm : Form
    {
        private Color bg = Color.FromArgb(15, 15, 15);
        private Color darkRed = Color.FromArgb(180, 0, 0);
        private Color burgundy = Color.FromArgb(95, 0, 0);
        private Color accent = Color.FromArgb(230, 50, 50);

        private Panel center;

        public ProfilePanelForm()
        {
            this.Load += ProfilePanelForm_Load;
        }

        private void ProfilePanelForm_Load(object sender, EventArgs e)
        {
            BuildUI();
        }

        private void BuildUI()
        {
            this.Text = "Hesabım";
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = bg;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoScaleMode = AutoScaleMode.None;

            
            Button backBtn = new Button
            {
                Text = "← Geri",
                ForeColor = Color.White,
                BackColor = burgundy,
                Size = new Size(100, 40),
                Location = new Point(20, 20),
                FlatStyle = FlatStyle.Flat
            };
            backBtn.FlatAppearance.BorderSize = 0;
            backBtn.Click += (s, e) => this.Close();
            this.Controls.Add(backBtn);

            
            Panel settings = new Panel
            {
                Size = new Size(160, 200),
                BackColor = burgundy,
                Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - 190, 20),
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };

            settings.Controls.Add(MenuBtn("Dil", 10));
            settings.Controls.Add(MenuBtn("Yardım", 55));
            settings.Controls.Add(MenuBtn("Bize Ulaş", 100));
            settings.Controls.Add(MenuBtn("Çıkış", 145));

            this.Controls.Add(settings);

            
            center = new Panel
            {
                Size = new Size(1200, 800),
                BackColor = burgundy
            };

            center.Location = new Point(
                (Screen.PrimaryScreen.WorkingArea.Width - center.Width) / 2,
                (Screen.PrimaryScreen.WorkingArea.Height - center.Height) / 2
            );

            this.Controls.Add(center);

            
            PictureBox pic = new PictureBox
            {
                Size = new Size(140, 140),
                BackColor = Color.Gray,
                Location = new Point(center.Width / 2 - 70, 20),
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            MakeCircle(pic);
            center.Controls.Add(pic);

            Button changePic = new Button
            {
                Text = "Profil Fotoğrafı Değiştir",
                BackColor = darkRed,
                ForeColor = Color.White,
                Size = new Size(220, 32),
                Location = new Point(center.Width / 2 - 110, 170),
                FlatStyle = FlatStyle.Flat
            };
            center.Controls.Add(changePic);

            
            Panel follow = new Panel
            {
                Size = new Size(300, 60),
                Location = new Point(center.Width / 2 - 150, 210),
                BackColor = Color.Transparent
            };

            follow.Controls.Add(Stat("Takipçi", "120", 0));
            follow.Controls.Add(Stat("Takip", "85", 150));
            center.Controls.Add(follow);

            
            center.Controls.Add(new Label
            {
                Text = "Ad Soyad",
                ForeColor = Color.White,
                Location = new Point(center.Width / 2 - 40, 280),
                AutoSize = true
            });

            center.Controls.Add(new Label
            {
                Text = "@kullaniciadi",
                ForeColor = Color.FromArgb(255, 220, 220),
                Location = new Point(center.Width / 2 - 45, 305),
                AutoSize = true
            });

            
            Panel left = new Panel
            {
                Size = new Size(320, 650),
                BackColor = Color.FromArgb(70, 0, 0),
                Location = new Point(20, 80),
                AutoScroll = true
            };

            int y = 20;

            left.Controls.Add(Title("Profil Düzenle", y)); y += 40;
            left.Controls.Add(Input("Ad Soyad", y)); y += 40;
            left.Controls.Add(Input("Kullanıcı Adı", y)); y += 40;
            left.Controls.Add(ButtonDark("Güncelle", y)); y += 60;

            left.Controls.Add(Title("Şifre İşlemleri", y)); y += 40;
            left.Controls.Add(InputPass("Eski Şifre", y)); y += 40;
            left.Controls.Add(InputPass("Yeni Şifre", y)); y += 40;
            left.Controls.Add(InputPass("Tekrar Yeni Şifre", y)); y += 40;

            left.Controls.Add(ButtonDark("Şifre Güncelle", y)); y += 60;

            left.Controls.Add(Input("Telefon Numarası", y)); y += 40;
            left.Controls.Add(ButtonAccent("SMS Kod Gönder", y)); y += 60;

            center.Controls.Add(left);

            
            FlowLayoutPanel posts = new FlowLayoutPanel
            {
                Size = new Size(760, 390),
                Location = new Point(400, 360),
                BackColor = Color.Transparent,
                AutoScroll = true,
                WrapContents = true
            };

            for (int i = 1; i <= 6; i++)
                posts.Controls.Add(Post(i));

            center.Controls.Add(posts);
        }

        
        private Button MenuBtn(string text, int y)
        {
            return new Button
            {
                Text = text,
                Size = new Size(140, 30),
                Location = new Point(10, y),
                BackColor = accent,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
        }

        
        private Label Title(string text, int y)
        {
            return new Label
            {
                Text = text,
                ForeColor = Color.White,
                Location = new Point(15, y),
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };
        }

        private TextBox Input(string placeholder, int y)
        {
            return new TextBox
            {
                PlaceholderText = placeholder,
                Location = new Point(15, y),
                Width = 280
            };
        }

        private TextBox InputPass(string placeholder, int y)
        {
            return new TextBox
            {
                PlaceholderText = placeholder,
                PasswordChar = '*',
                Location = new Point(15, y),
                Width = 280
            };
        }

        private Button ButtonDark(string text, int y)
        {
            return new Button
            {
                Text = text,
                BackColor = darkRed,
                ForeColor = Color.White,
                Location = new Point(15, y),
                Width = 280,
                FlatStyle = FlatStyle.Flat
            };
        }

        private Button ButtonAccent(string text, int y)
        {
            return new Button
            {
                Text = text,
                BackColor = accent,
                ForeColor = Color.White,
                Location = new Point(15, y),
                Width = 280,
                FlatStyle = FlatStyle.Flat
            };
        }

        private Panel Stat(string title, string value, int x)
        {
            Panel p = new Panel
            {
                Size = new Size(140, 60),
                Location = new Point(x, 0)
            };

            p.Controls.Add(new Label
            {
                Text = title,
                ForeColor = Color.White,
                Location = new Point(35, 5),
                AutoSize = true
            });

            p.Controls.Add(new Label
            {
                Text = value,
                ForeColor = accent,
                Font = new Font("Arial", 10, FontStyle.Bold),
                Location = new Point(55, 30),
                AutoSize = true
            });

            return p;
        }

        private void MakeCircle(Control c)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(0, 0, c.Width, c.Height);
            c.Region = new Region(gp);
        }

        
        private Panel Post(int i)
        {
            Panel p = new Panel
            {
                Size = new Size(240, 190),
                BackColor = Color.FromArgb(120, 0, 0),
                Margin = new Padding(10)
            };

            p.Controls.Add(new Label
            {
                Text = "Gönderi " + i,
                ForeColor = Color.White,
                Location = new Point(10, 10)
            });

            p.Controls.Add(new Button
            {
                Text = "❤ 0",
                Location = new Point(10, 130),
                Width = 60
            });

            p.Controls.Add(new Button
            {
                Text = "Yorumlar",
                Location = new Point(80, 130),
                Width = 120
            });

            p.Controls.Add(new Button
            {
                Text = "⋮",
                Location = new Point(200, 10),
                Width = 30,
                BackColor = accent,
                ForeColor = Color.White
            });

            return p;
        }

        private void ProfilePanelForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}