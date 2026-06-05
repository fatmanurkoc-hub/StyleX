using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
#pragma warning disable CS8602

namespace StyleX
{
    public partial class ExploreForm : Form
    {
        private Panel scrollArea = null!;
        private Panel bottomBar = null!;

        public ExploreForm()
        {
            InitializeComponent();
        }

        private void ExploreForm_Load(object sender, EventArgs e)
        {
            
            this.Text = "StyleX Explore";
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(45, 0, 10);
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;

            this.Resize += ExploreForm_Resize;

            
            Label title = new Label();
            title.Text = "StyleX Explore";
            title.Font = new Font("Segoe UI", 24, FontStyle.Bold);
            title.ForeColor = Color.FromArgb(255, 90, 90);
            title.AutoSize = true;
            title.Location = new Point(25, 20);
            this.Controls.Add(title);

            
            scrollArea = new Panel();
            scrollArea.Location = new Point(20, 80);
            scrollArea.Size = new Size(this.ClientSize.Width - 40, this.ClientSize.Height - 180);
            scrollArea.AutoScroll = true;
            scrollArea.BackColor = Color.FromArgb(45, 0, 10);
            scrollArea.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            this.Controls.Add(scrollArea);

            
            Panel post1 = CreatePost("Nur", "@nurstyle");
            post1.Location = new Point(10, 10);
            scrollArea.Controls.Add(post1);

            
            Panel post2 = CreatePost("Beren", "@berenfashion");
            post2.Location = new Point(10, 530);
            scrollArea.Controls.Add(post2);

            
            Panel post3 = CreatePost("Reyhan", "@reyhanfit");
            post3.Location = new Point(10, 1050);
            scrollArea.Controls.Add(post3);

            
            CreateBottomBar();
        }

        private Panel CreatePost(string username, string usertag)
        {
            Panel post = new Panel();
            post.Size = new Size(this.ClientSize.Width - 60, 500);
            post.BackColor = Color.FromArgb(80, 10, 20);
            post.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            
            PictureBox profile = new PictureBox();
            profile.Size = new Size(50, 50);
            profile.Location = new Point(20, 20);
            profile.BackColor = Color.DarkRed;

            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(0, 0, profile.Width - 1, profile.Height - 1);
            profile.Region = new Region(gp);

            
            Label user = new Label();
            user.Text = username;
            user.ForeColor = Color.White;
            user.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            user.AutoSize = true;
            user.Location = new Point(85, 20);

            Label tag = new Label();
            tag.Text = usertag;
            tag.ForeColor = Color.LightGray;
            tag.Font = new Font("Segoe UI", 9);
            tag.AutoSize = true;
            tag.Location = new Point(87, 48);

            
            PictureBox postImage = new PictureBox();
            postImage.Size = new Size(post.Width - 60, 320);
            postImage.Location = new Point(30, 90);
            postImage.BackColor = Color.FromArgb(120, 20, 30);
            postImage.SizeMode = PictureBoxSizeMode.StretchImage;

            
            Button likeBtn = new Button();
            likeBtn.Text = "❤ Beğen";
            likeBtn.Size = new Size(120, 40);
            likeBtn.Location = new Point(30, 430);
            likeBtn.FlatStyle = FlatStyle.Flat;
            likeBtn.FlatAppearance.BorderSize = 0;
            likeBtn.BackColor = Color.FromArgb(220, 40, 70);
            likeBtn.ForeColor = Color.White;

            
            Button commentBtn = new Button();
            commentBtn.Text = "💬 Yorum";
            commentBtn.Size = new Size(120, 40);
            commentBtn.Location = new Point(170, 430);
            commentBtn.FlatStyle = FlatStyle.Flat;
            commentBtn.FlatAppearance.BorderSize = 0;
            commentBtn.BackColor = Color.FromArgb(160, 30, 50);
            commentBtn.ForeColor = Color.White;

            likeBtn.MouseEnter += (s, e) => likeBtn.BackColor = Color.FromArgb(255, 70, 100);
            likeBtn.MouseLeave += (s, e) => likeBtn.BackColor = Color.FromArgb(220, 40, 70);

            post.Controls.Add(profile);
            post.Controls.Add(user);
            post.Controls.Add(tag);
            post.Controls.Add(postImage);
            post.Controls.Add(likeBtn);
            post.Controls.Add(commentBtn);

            return post;
        }

        private void CreateBottomBar()
        {
            bottomBar = new Panel();
            bottomBar.Size = new Size(this.ClientSize.Width, 80);
            bottomBar.Location = new Point(0, this.ClientSize.Height - 80);
            bottomBar.BackColor = Color.FromArgb(70, 0, 20);
            bottomBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            this.Controls.Add(bottomBar);

            string[] icons = { "✨", "🔍", "➕", "👤" };

            for (int i = 0; i < 4; i++)
            {
                Button navButton = new Button();
                navButton.Text = icons[i];
                navButton.Font = new Font("Segoe UI Emoji", 20);
                navButton.Size = new Size(80, 60);
                navButton.FlatStyle = FlatStyle.Flat;
                navButton.FlatAppearance.BorderSize = 0;
                navButton.BackColor = Color.FromArgb(120, 10, 30);
                navButton.ForeColor = Color.White;

                int index = i;

                navButton.Location = new Point(
                    (this.ClientSize.Width / 5) * (i + 1) - 40,
                    10
                );

                navButton.MouseEnter += (s, e) =>
                {
                    navButton.BackColor = Color.FromArgb(200, 40, 70);
                };

                navButton.MouseLeave += (s, e) =>
                {
                    navButton.BackColor = Color.FromArgb(120, 10, 30);
                };

                if (index == 1)
                {
                    navButton.Click += (sender, e) =>
                    {
                        SearchForm searchForm = new SearchForm();
                        searchForm.WindowState = FormWindowState.Maximized;
                        searchForm.FormClosed += (s, args) => this.Show();
                        searchForm.Show();
                        this.Hide();
                    };
                }

                if (index == 2)
                {
                    navButton.Click += (sender, e) =>
                    {
                        AddItemForm addItemForm = new AddItemForm();
                        addItemForm.FormClosed += (s, args) => this.Show();
                        addItemForm.Show();
                        this.Hide();
                    };
                }
                if (index == 3)
                {
                    navButton.Click += (sender, e) =>
                    {
                        ProfilePanelForm profilePanelForm = new ProfilePanelForm();
                        profilePanelForm.FormClosed += (s, args) => this.Show();
                        profilePanelForm.Show();
                        this.Hide();
                    };
                }

                bottomBar.Controls.Add(navButton);
            }
        }

        private void ExploreForm_Resize(object? sender, EventArgs e)
        {
            if (scrollArea != null)
            {
                scrollArea.Size = new Size(this.ClientSize.Width - 40, this.ClientSize.Height - 180);
            }

            if (bottomBar != null)
            {
                bottomBar.Location = new Point(0, this.ClientSize.Height - 80);
                bottomBar.Width = this.ClientSize.Width;
            }
        }
    }
}







