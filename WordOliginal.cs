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
        protected StringReader leitura = null;
        public frmWord()
        {
            InitializeComponent();
        }
        protected void novoArquivo(RichTextBox rtc)
        {
            
        }

        private void btnNegrito_Click(object sender, EventArgs e)
        {
            Negrito();
            
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir();
        }
        
        private void Copiar()
        {
            if(rctTxb.SelectionLength > 0)
            {
                rctTxb.Copy();
            }
        }
        private void Negrito()
        {
            string fonte=null;
            float tamanho;
            bool negrito, italico, sublinhado;
            negrito = rctTxb.SelectionFont.Bold;
            italico = rctTxb.SelectionFont.Italic;
            sublinhado = rctTxb.SelectionFont.Underline;
            tamanho = rctTxb.Font.Size;
            negrito = rctTxb.Font.Bold;
            if (! negrito) {
                if (italico == true && sublinhado == true)
                {
                    rctTxb.SelectionFont = new Font(fonte, tamanho, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);

                }
                else if(italico == false && sublinhado == true){
                    rctTxb.SelectionFont = new Font(fonte, tamanho, FontStyle.Bold | FontStyle.Underline);
                }
                else if (italico == true && sublinhado == false)
                {
                    rctTxb.SelectionFont = new Font(fonte, tamanho, FontStyle.Bold | FontStyle.Italic );

                }
                else if (italico == false && sublinhado == false)
                {
                    rctTxb.SelectionFont = new Font(fonte, tamanho, FontStyle.Bold);
                }
            }
            else
            {
                if (italico == true && sublinhado == true)
                {
                    rctTxb.SelectionFont = new Font(fonte, tamanho,  FontStyle.Italic | FontStyle.Underline);

                }
                else if (italico == false && sublinhado == true)
                {
                    rctTxb.SelectionFont = new Font(fonte, tamanho,  FontStyle.Underline);
                }
                else if (italico == true && sublinhado == false)
                {
                    rctTxb.SelectionFont = new Font(fonte, tamanho,  FontStyle.Italic);

                }
            }
        }

        private void Italico()
        {
            string fonte = null;
            float tamanho;
            bool negrito, italico, sublinhado;
            negrito = rctTxb.SelectionFont.Bold;
            italico = rctTxb.SelectionFont.Italic;
            sublinhado = rctTxb.SelectionFont.Underline;
            tamanho = rctTxb.Font.Size;
            negrito = rctTxb.Font.Bold;
            if (!italico)
            {
                if (negrito == true && sublinhado == true)
                {
                    rctTxb.SelectionFont = new Font(fonte, tamanho, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);

                }
                else if (negrito == false && sublinhado == true)
                {
                    rctTxb.SelectionFont = new Font(fonte, tamanho, FontStyle.Italic | FontStyle.Underline);
                }
                else if (negrito == true && sublinhado == false)
                {
                    rctTxb.SelectionFont = new Font(fonte, tamanho, FontStyle.Bold | FontStyle.Italic);

                }
                else if (negrito == false && sublinhado == false)
                {
                    rctTxb.SelectionFont = new Font(fonte, tamanho, FontStyle.Italic);
                }
            }
            else
            {
                if (negrito == true && sublinhado == true)
                {
                    rctTxb.SelectionFont = new Font(fonte, tamanho, FontStyle.Bold | FontStyle.Underline);

                }
                else if (negrito == false && sublinhado == true)
                {
                    rctTxb.SelectionFont = new Font(fonte, tamanho, FontStyle.Underline);
                }
                else if (negrito == true && sublinhado == false)
                {
                    rctTxb.SelectionFont = new Font(fonte, tamanho, FontStyle.Bold);
                }
            }
        }
        private void Colar()
        {
            rctTxb.Paste();
        }

        private void Sublinhado()
        {
            string fonte = null;
            float tamanho;
            bool negrito, italico, sublinhado;
            negrito = rctTxb.SelectionFont.Bold;
            italico = rctTxb.SelectionFont.Italic;
            sublinhado = rctTxb.SelectionFont.Underline;
            tamanho = rctTxb.Font.Size;
            negrito = rctTxb.Font.Bold;
            if (!sublinhado)
            {
                if (negrito == true && italico == true)
                {
                    rctTxb.SelectionFont = new Font(fonte, tamanho, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);

                }
                else if (negrito == false && italico == true)
                {
                    rctTxb.SelectionFont = new Font(fonte, tamanho, FontStyle.Italic | FontStyle.Underline);
                }
                else if (negrito == true && italico == false)
                {
                    rctTxb.SelectionFont = new Font(fonte, tamanho, FontStyle.Bold | FontStyle.Underline);

                }
                else if (negrito == false && italico == false)
                {
                    rctTxb.SelectionFont = new Font(fonte, tamanho, FontStyle.Underline);
                }
            }
            else
            {
                if (negrito == true && sublinhado == true)
                {
                    rctTxb.SelectionFont = new Font(fonte, tamanho, FontStyle.Bold | FontStyle.Italic);

                }
                else if (negrito == false && sublinhado == true)
                {
                    rctTxb.SelectionFont = new Font(fonte, tamanho, FontStyle.Italic);
                }
                else if (negrito == true && sublinhado == false)
                {
                    rctTxb.SelectionFont = new Font(fonte, tamanho, FontStyle.Bold);
                }
            }
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
        private void Abrir()
        {
            this.openFileDialog1.Title = "Abrir Arquivo";
            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;
            openFileDialog1.Filter="(*.rjs)|*.rjs";
            if(this.saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try {
                    FileStream arquivo = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                    StreamReader leitor = new StreamReader(arquivo);
                    leitor.BaseStream.Seek(0, SeekOrigin.Begin);
                    this.rctTxb.Text = "";
                    string linha = leitor.ReadLine();
                    //recebendo conteudo da linha + a proxima linha
                    while( linha != null )
                    {
                        this.rctTxb.Text+= linha+"\n";
                    }
                    leitor.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Erro de leitura:  " + ex.Message, "Erro ai ler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            Abrir();
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Copiar();
        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            Copiar();
        }

        private void btnColar_Click(object sender, EventArgs e)
        {
            Colar();
        }

        private void colarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Colar();
        }

        private void negritoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Negrito();
        }

        private void itálicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Italico();
        }

        private void btnItalico_Click(object sender, EventArgs e)
        {
            Italico();
        }

        private void sublinhadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sublinhado();
        }

        private void btnSublinhado_Click(object sender, EventArgs e)
        {
            Sublinhado();
        }

        private void AlinharEsquerda()
        {
            rctTxb.SelectionAlignment = HorizontalAlignment.Left;
        }
        private void AlinharDireita()
        {
            rctTxb.SelectionAlignment = HorizontalAlignment.Right;

        }
        private void Centralizar()
        {
            rctTxb.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void centralizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Centralizar();
        }

        private void btnEsquerda_Click(object sender, EventArgs e)
        {
            AlinharEsquerda();
        }

       private void btnCentro_Click(object sender, EventArgs e)
        {
            Centralizar();
        }

        private void btnDireita_Click(object sender, EventArgs e)
        {
            AlinharDireita();
        }

        private void aEsquerdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlinharEsquerda();
        }

        private void aDireitaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlinharDireita();
        }

        private void btnFonte_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
        }
        private  void Imprimir() {
            printDialog1.Document = printDocument1;
            string texto = this.rctTxb.Text;
            leitura = new StringReader(texto);
            if(printDialog1.ShowDialog() == DialogResult.OK)
            {
                this.printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float linhasPag = 0;
            float posY = 0;
            int cont = 0;
            //Definir margens para saber onde começa imprimir
            float margenEsq = e.MarginBounds.Left - 50;
            float margenSuperior = e.MarginBounds.Top - 50;
            if(margenEsq < 5)
            {
                margenEsq = 20;
            }
            if (margenSuperior < 5)
            {
                margenSuperior = 20;
            }
            //
            //configurar fonte, pincel altura linhas
            string linha = null;
            Font fonte = this.rctTxb.Font;
            SolidBrush pincel = new SolidBrush(Color.Black);
            //qnts linhas cabe na pagina dada altura e fonte
            linhasPag = e.MarginBounds.Height / fonte.GetHeight(e.Graphics);
            linha = leitura.ReadLine();
            while(cont < linhasPag)
            {
                //tamanho e altura da fonte para posicionar Y 
                posY = (margenSuperior + (cont * fonte.GetHeight(e.Graphics) ) );
                //define nova linha de acordo com tamanho, posição.. 
                e.Graphics.DrawString(linha, fonte,  pincel, margenEsq, posY, new StringFormat() );
                cont++;
                linha = leitura.ReadLine();
            }
            if(linha != null)
            {
                //se ainda tem linha define mais paginas como sim, pra continuar imprimindo
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }
            pincel.Dispose();

        }

        private void ImprimiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Imprimir();
        }
    }
}
