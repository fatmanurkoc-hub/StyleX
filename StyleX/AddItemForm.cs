using System;
using System.Drawing;
using System.Windows.Forms;

namespace StyleX
{
    public class AddItemForm : Form
    {
        private ComboBox categoryBox = null!;
        private PictureBox preview = null!;
        private TextBox descriptionBox = null!;
        private string imagePath = "";

        public AddItemForm()
        {
            BuildUI();
        }

        private void BuildUI()
        {
            this.Text = "Parça Ekle";
            this.Size = new Size(420, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(40, 10, 30);
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.Sizable;

            categoryBox = new ComboBox();
            categoryBox.Items.AddRange(new string[]
            {
                "Pantolon","Ceket","Kazak","Ayakkabı","Kaban","Aksesuar","Eşarp_Şal","Gömlek-Tshirt"
            });

            categoryBox.Location = new Point(30, 30);
            categoryBox.Size = new Size(340, 30);
            categoryBox.BackColor = Color.FromArgb(120, 20, 40);
            categoryBox.ForeColor = Color.White;
            this.Controls.Add(categoryBox);

            preview = new PictureBox();
            preview.Size = new Size(340, 200);
            preview.Location = new Point(30, 80);
            preview.BackColor = Color.FromArgb(60, 30, 60);
            preview.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(preview);

            Button imgBtn = new Button();
            imgBtn.Text = "Fotoğraf Seç";
            imgBtn.Size = new Size(340, 40);
            imgBtn.Location = new Point(30, 290);
            imgBtn.BackColor = Color.FromArgb(220, 60, 90);
            imgBtn.ForeColor = Color.White;
            imgBtn.FlatStyle = FlatStyle.Flat;
            imgBtn.FlatAppearance.BorderSize = 0;

            imgBtn.Click += (s, e) =>
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Images|*.jpg;*.png;*.jpeg";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    imagePath = ofd.FileName;
                    preview.Image = Image.FromFile(imagePath);
                }
            };

            this.Controls.Add(imgBtn);

            descriptionBox = new TextBox();
            descriptionBox.Multiline = true;
            descriptionBox.Size = new Size(340, 120);
            descriptionBox.Location = new Point(30, 350);
            descriptionBox.BackColor = Color.FromArgb(120, 20, 40);
            descriptionBox.ForeColor = Color.White;

            this.Controls.Add(descriptionBox);

            Button postBtn = new Button();
            postBtn.Text = "PAYLAŞ";
            postBtn.Size = new Size(340, 40);
            postBtn.Location = new Point(30, 490);
            postBtn.BackColor = Color.FromArgb(220, 60, 90);
            postBtn.ForeColor = Color.White;
            postBtn.FlatStyle = FlatStyle.Flat;
            postBtn.FlatAppearance.BorderSize = 0;

            postBtn.Click += (s, e) =>
            {
                if (categoryBox.SelectedIndex == -1 || imagePath == "")
                {
                    MessageBox.Show("Kategori ve fotoğraf seç!");
                    return;
                }

                MessageBox.Show("Paylaşıldı!");
                this.Close();
            };

            this.Controls.Add(postBtn);
            TableLayoutPanel mainTable = new TableLayoutPanel();
            mainTable.Dock = DockStyle.Fill;
            mainTable.Size = this.ClientSize;
            mainTable.ColumnCount = 1;
            mainTable.RowCount = 5;

            mainTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

            mainTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            mainTable.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            mainTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            mainTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            mainTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));

            this.Controls.Remove(categoryBox);
            this.Controls.Remove(preview);
            this.Controls.Remove(imgBtn);
            this.Controls.Remove(descriptionBox);
            this.Controls.Remove(postBtn);

            mainTable.Controls.Add(categoryBox, 0, 0);
            mainTable.Controls.Add(preview, 0, 1);
            mainTable.Controls.Add(imgBtn, 0, 2);
            mainTable.Controls.Add(descriptionBox, 0, 3);
            mainTable.Controls.Add(postBtn, 0, 4);

            foreach (Control ctrl in mainTable.Controls)
            {
                ctrl.Dock = DockStyle.Fill;
                ctrl.Margin = new Padding(20, 8, 20, 8);
            }

            this.Controls.Add(mainTable);
        }
    }
}


