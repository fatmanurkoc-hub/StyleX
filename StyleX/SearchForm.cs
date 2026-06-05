using System;
using System.Drawing;
using System.Windows.Forms;
#pragma warning disable

namespace StyleX
{
    public partial class SearchForm : Form
    {
        private FlowLayoutPanel flowResults = null!;
        private TextBox searchBox = null!;
        private Button searchBtn = null!;

        private Button userBtn = null!;
        private Button outfitBtn = null!;
        private Button placeBtn = null!;

        public SearchForm()
        {
            BuildUI();
            this.Resize += SearchForm_Resize;
        }

        private void BuildUI()
        {
            // FORM
            this.Text = "StyleX - Keşfet";
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.BackColor = Color.FromArgb(40, 10, 30);
            this.StartPosition = FormStartPosition.CenterScreen;

            // SEARCH
            searchBox = new TextBox();
            searchBox.Size = new Size(250, 35);
            searchBox.Location = new Point(20, 20);
            searchBox.BackColor = Color.FromArgb(120, 20, 40);
            searchBox.ForeColor = Color.White;
            searchBox.BorderStyle = BorderStyle.FixedSingle;

            this.Controls.Add(searchBox);

            searchBtn = new Button();
            searchBtn.Text = "ARA";
            searchBtn.Size = new Size(120, 35);
            searchBtn.BackColor = Color.FromArgb(200, 40, 60);
            searchBtn.ForeColor = Color.White;
            searchBtn.FlatStyle = FlatStyle.Flat;
            searchBtn.FlatAppearance.BorderSize = 0;

            searchBtn.Click += SearchBtn_Click;
            this.Controls.Add(searchBtn);

            // FILTER BUTTONS
            userBtn = CreateFilterButton("Kullanıcı");
            outfitBtn = CreateFilterButton("Kombin");
            placeBtn = CreateFilterButton("Mekan");

            this.Controls.Add(userBtn);
            this.Controls.Add(outfitBtn);
            this.Controls.Add(placeBtn);

            // RESULTS
            flowResults = new FlowLayoutPanel();
            flowResults.Location = new Point(20, 230);
            flowResults.Size = new Size(390, 520);
            flowResults.AutoScroll = true;
            flowResults.BackColor = Color.FromArgb(35, 20, 35);

            flowResults.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            this.Controls.Add(flowResults);

            AddDefaultUsers();
            LayoutUI();
        }

        private Button CreateFilterButton(string text)
        {
            Button btn = new Button();
            btn.Text = text;
            btn.Size = new Size(120, 35);

            btn.BackColor = Color.FromArgb(120, 20, 40);
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;

            btn.Click += (s, e) =>
            {
                MessageBox.Show(text + " araması aktif");
            };

            return btn;
        }

        private void SearchBtn_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Arama: " + searchBox.Text);
        }

        private void AddDefaultUsers()
        {
            flowResults.Controls.Add(CreateCard("Nur Koç", "@nurstyle"));
            flowResults.Controls.Add(CreateCard("Reyhan Kaya", "@reyhanfit"));
            flowResults.Controls.Add(CreateCard("Beren Deniz", "@berenfashion"));
        }

        private Panel CreateCard(string name, string username)
        {
            Panel card = new Panel();
            card.Size = new Size(360, 90);
            card.BackColor = Color.FromArgb(60, 30, 60);
            card.Margin = new Padding(8);

            PictureBox pic = new PictureBox();
            pic.Size = new Size(50, 50);
            pic.Location = new Point(10, 20);
            pic.BackColor = Color.FromArgb(220, 60, 90);
            card.Controls.Add(pic);

            Label lblName = new Label();
            lblName.Text = name;
            lblName.ForeColor = Color.White;
            lblName.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblName.Location = new Point(75, 15);
            lblName.AutoSize = true;
            card.Controls.Add(lblName);

            Label lblUser = new Label();
            lblUser.Text = username;
            lblUser.ForeColor = Color.LightGray;
            lblUser.Location = new Point(75, 40);
            lblUser.AutoSize = true;
            card.Controls.Add(lblUser);

            Button btn = new Button();
            btn.Text = "Takip Et";
            btn.Size = new Size(80, 30);
            btn.Location = new Point(270, 28);
            btn.BackColor = Color.FromArgb(220, 60, 90);
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;

            card.Controls.Add(btn);

            return card;
        }

        private void SearchForm_Resize(object? sender, EventArgs e)
        {
            LayoutUI();
        }

        private void LayoutUI()
        {
            int w = this.ClientSize.Width;

            // SEARCH FIX
            searchBox.Location = new Point(20, 20);
            searchBox.Width = w - 180;

            searchBtn.Location = new Point(w - 140, 20);

            // FILTER BUTTONS (YAKINLAŞTIRILDI)
            int center = w / 2;

            userBtn.Location = new Point(center - 160, 70);
            outfitBtn.Location = new Point(center - 60, 70);
            placeBtn.Location = new Point(center + 40, 70);
        }
    }
}