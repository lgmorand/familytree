using System;
using System.Windows.Forms;

namespace HtmlGenerator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
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