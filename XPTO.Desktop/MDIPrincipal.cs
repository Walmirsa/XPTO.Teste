using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XPTO.Negocios;
using XPTO.Entidades;


namespace XPTO.Desktop
{
    public partial class MDIPrincipal : Form
    {
        private int childFormNumber = 0;

        public MDIPrincipal()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Janela " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {                     

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Arquivos de texto (*.txt)|*.txt|Todos os arquivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
                
                using (StreamReader sr = new StreamReader(FileName))
                {
                    using (ImportacaoNegocios importacaoNegocios = new ImportacaoNegocios())
                    {
                        log log = new log();
                        log = importacaoNegocios.ImportarArquivo(sr);
                        MessageBox.Show(log.descricao, "Processamento", MessageBoxButtons.OK, log.Sucesso ? MessageBoxIcon.Information : MessageBoxIcon.Error ); 
                    }
                }                
            }          

        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Arquivos de texto (*.txt)|*.txt|Todos os arquivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void fileMenu_Click(object sender, EventArgs e)
        {

        }

        private void MDIPrincipal_Load(object sender, EventArgs e)
        {

        }
        private void ChamarForm(object sender, bool modal)
        {

            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == ((Form)sender).Name)
                {
                    f.Activate();
                    return;
                }
            }
            if (!modal)
            {
                ((Form)sender).MdiParent = this;
                ((Form)sender).Show();
            }
            else
            {
                ((Form)sender).ShowDialog(this);
            }
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChamarForm(new frmGrid(), false);
        }
    }
}
