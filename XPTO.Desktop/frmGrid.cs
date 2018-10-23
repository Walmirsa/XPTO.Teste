using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XPTO.Negocios;
using XPTO.Entidades;

namespace XPTO.Desktop
{
    public partial class frmGrid : Form
    {
        public frmGrid()
        {
            InitializeComponent();
        }

        private void frmGrid_Load(object sender, EventArgs e)
        {

            List<Venda> vendas = new List<Venda>();
            Produto produto = new Produto();
            Cliente cliente = new Cliente();

            using (VendaNegocios vendanegocios = new VendaNegocios())
            {
                using (ClienteNegocios clientenegocios = new ClienteNegocios())
                {
                    using (ProdutoNegocios produtoNegocios = new ProdutoNegocios())
                    {
                        vendas = vendanegocios.Listar();
                        foreach (Venda venda in vendas)
                        {
                            DataGridViewRow row = new DataGridViewRow();
                            row.ReadOnly = true;

                            produto = produtoNegocios.Selecionar(venda.idProduto);
                            cliente = clientenegocios.Selecionar(venda.idCliente);

                            DataGridViewCell pos01 = new DataGridViewTextBoxCell();
                            pos01.Value = cliente.PrimeiroNome;
                            row.Cells.Add(pos01);

                            DataGridViewCell pos02 = new DataGridViewTextBoxCell();
                            pos02.Value = cliente.SegundoNome;
                            row.Cells.Add(pos02);

                            DataGridViewCell pos03 = new DataGridViewTextBoxCell();
                            pos03.Value = cliente.Sexo;
                            row.Cells.Add(pos03);

                            DataGridViewCell pos04 = new DataGridViewTextBoxCell();
                            pos04.Value = cliente.Email;
                            row.Cells.Add(pos04);

                            DataGridViewCell pos05 = new DataGridViewTextBoxCell();
                            pos05.Value = cliente.Nascimento.ToString("dd/MM/yyyy");
                            row.Cells.Add(pos05);

                            DataGridViewCell pos06 = new DataGridViewTextBoxCell();
                            pos06.Value = produto.Descricao;
                            row.Cells.Add(pos06);


                            dgvCaixas.Rows.Add(row);
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
