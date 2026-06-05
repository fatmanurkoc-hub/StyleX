using System.Drawing.Drawing2D;

namespace StyleX
{
    public partial class Form1 : Form
    {
        private Panel mainCard = null!;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            this.Text = "StyleX";
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.Sizable;

          
            this.BackColor = Color.FromArgb(70, 0, 20);

            
            mainCard = new Panel();
            mainCard.Size = new Size(520, 620);
            mainCard.BackColor = Color.FromArgb(120, 20, 40);

            mainCard.Location = new Point(
                (this.ClientSize.Width - mainCard.Width) / 2,
                (this.ClientSize.Height - mainCard.Height) / 2
            );

            
            mainCard.Paint += (s, e2) =>
            {
                GraphicsPath path = new GraphicsPath();
                int r = 50;

                path.AddArc(0, 0, r, r, 180, 90);
                path.AddArc(mainCard.Width - r, 0, r, r, 270, 90);
                path.AddArc(mainCard.Width - r, mainCard.Height - r, r, r, 0, 90);
                path.AddArc(0, mainCard.Height - r, r, r, 90, 90);
                path.CloseAllFigures();

                mainCard.Region = new Region(path);
            };

            this.Controls.Add(mainCard);

            
            this.Resize += (s, e2) =>
            {
                mainCard.Location = new Point(
                    (this.ClientSize.Width - mainCard.Width) / 2,
                    (this.ClientSize.Height - mainCard.Height) / 2
                );
            };

            
            Label title = new Label();
            title.Text = "StyleX";
            title.Font = new Font("Segoe UI", 54, FontStyle.Bold);
            title.ForeColor = Color.FromArgb(255, 120, 120);
            title.AutoSize = true;

            title.Location = new Point(
                (mainCard.Width - title.PreferredWidth) / 2,
                60
            );

            mainCard.Controls.Add(title);

            
            Panel logoBox = new Panel();
            logoBox.Size = new Size(230, 230);
            logoBox.Location = new Point(
                (mainCard.Width - logoBox.Width) / 2,
                180
            );
            logoBox.BackColor = Color.FromArgb(200, 40, 60);

            
            logoBox.Paint += (s, e2) =>
            {
                GraphicsPath path = new GraphicsPath();
                int r = 70;

                path.AddArc(0, 0, r, r, 180, 90);
                path.AddArc(logoBox.Width - r, 0, r, r, 270, 90);
                path.AddArc(logoBox.Width - r, logoBox.Height - r, r, r, 0, 90);
                path.AddArc(0, logoBox.Height - r, r, r, 90, 90);
                path.CloseAllFigures();

                logoBox.Region = new Region(path);
            };

            mainCard.Controls.Add(logoBox);

            
            Label sLabel = new Label();
            sLabel.Text = "S";
            sLabel.Font = new Font("Segoe UI Black", 110, FontStyle.Bold);
            sLabel.ForeColor = Color.White;
            sLabel.AutoSize = true;

            sLabel.Location = new Point(
                (logoBox.Width - sLabel.PreferredWidth) / 2,
                (logoBox.Height - sLabel.PreferredHeight) / 2
            );

            logoBox.Controls.Add(sLabel);

            
            Button startBtn = new Button();
            startBtn.Text = "BAŞLA";
            startBtn.Size = new Size(280, 75);
            startBtn.Location = new Point(
                (mainCard.Width - startBtn.Width) / 2,
                460
            );

            startBtn.BackColor = Color.FromArgb(255, 80, 80);
            startBtn.ForeColor = Color.White;
            startBtn.FlatStyle = FlatStyle.Flat;
            startBtn.FlatAppearance.BorderSize = 0;
            startBtn.Font = new Font("Segoe UI", 15, FontStyle.Bold);

            startBtn.Click += StartBtn_Click;

            mainCard.Controls.Add(startBtn);
        }

        private void StartBtn_Click(object? sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}










