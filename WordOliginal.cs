using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.AccessControl;

namespace Editor_de_Texto
{
    public partial class frmWord : Form
    {
        protected StreamReader leitura = null;
        public frmWord()
        {
            InitializeComponent();
        }
        protected void novoArquivo(RichTextBox rtc)
        {
            
        }

        private void btnNegrito_Click(object sender, EventArgs e)
        {
            String texto = rctTxb.Text;
            
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        
        private void salvarDocumento() {
            FileStream arquivo;
            try
            {
                if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    arquivo = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter escreverArquivo = new StreamWriter(arquivo);
                    escreverArquivo.Flush();
                    //posiciona no inicio do arquivo
                    escreverArquivo.BaseStream.Seek(0, SeekOrigin.Begin);
                    escreverArquivo.Write(this.rctTxb.Text);
                    escreverArquivo.Flush();
                    //so conclui gravação se usarmos essa função:
                    escreverArquivo.Close();
                }
                else
                {
                    rctTxb.Clear();
                    rctTxb.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Descrição:  "+ex.Message,"Erro ao gravar", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            novoArquivo(this.rctTxb);
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            novoArquivo(this.rctTxb);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            salvarDocumento();
        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            salvarDocumento();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
