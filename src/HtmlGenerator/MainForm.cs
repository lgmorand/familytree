using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HtmlGenerator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            DoubleBuffered = true;
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (LinearGradientBrush baseBrush = new LinearGradientBrush(ClientRectangle, Color.FromArgb(246, 248, 252), Color.FromArgb(238, 243, 248), 90f))
            {
                e.Graphics.FillRectangle(baseBrush, ClientRectangle);
            }

            using (GraphicsPath blueGlowPath = new GraphicsPath())
            {
                blueGlowPath.AddEllipse(-80, -70, 240, 170);
                using (PathGradientBrush blueGlow = new PathGradientBrush(blueGlowPath))
                {
                    blueGlow.CenterColor = Color.FromArgb(90, 176, 205, 255);
                    blueGlow.SurroundColors = new[] { Color.FromArgb(0, 176, 205, 255) };
                    e.Graphics.FillPath(blueGlow, blueGlowPath);
                }
            }

            using (GraphicsPath pinkGlowPath = new GraphicsPath())
            {
                pinkGlowPath.AddEllipse(ClientSize.Width - 180, -45, 260, 170);
                using (PathGradientBrush pinkGlow = new PathGradientBrush(pinkGlowPath))
                {
                    pinkGlow.CenterColor = Color.FromArgb(80, 255, 205, 220);
                    pinkGlow.SurroundColors = new[] { Color.FromArgb(0, 255, 205, 220) };
                    e.Graphics.FillPath(pinkGlow, pinkGlowPath);
                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            var people = new PeopleCollection();
            new GedcomImport().Import(people, txtPath.Text);
            new HtmlExporter().Export("index.html", people, txtAncestor.Text); //"I157"
            MessageBox.Show("Fichier généré: index.html", "Succès", MessageBoxButtons.OK);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofg = new OpenFileDialog();
            if (ofg.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = ofg.FileName;
            }
        }
    }
}