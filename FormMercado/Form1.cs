using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormMercado
{
    public partial class Form1 : Form
    {
        int id_venda = 1;
        int qntd;
        double valor_unit;
        double total;

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_inserir_Click(object sender, EventArgs e)
        {
            qntd = int.Parse(txt_qntd.Text);
            valor_unit = double.Parse(txt_valor_unit.Text);

            total += qntd * valor_unit;

            lbl_total.Text = total.ToString("C");

            dgv_venda.Rows.Add(txt_descricao.Text, txt_qntd.Text, txt_valor_unit.Text);

            txt_descricao.Clear();
            txt_qntd.Clear();
            txt_valor_unit.Clear();

            MessageBox.Show("Venda inserida", "Inserido",
                             MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            lbl_item.Text = dgv_venda.RowCount.ToString();
        }

        private void btn_remover_Click(object sender, EventArgs e)
        {
            if(dgv_venda.RowCount > 0)
            {
                dgv_venda.Rows.RemoveAt(dgv_venda.CurrentCell.RowIndex);
                MessageBox.Show("Venda removida", "Remover",
                                 MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                lbl_item.Text = dgv_venda.RowCount.ToString();
            }
        }

        private void btn_nova_venda_Click(object sender, EventArgs e)
        {
            id_venda += 1;
            txt_venda.Text = id_venda.ToString();
            Limpar();
        }

        private void dgv_venda_Cellclick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgv_venda.RowCount > 0)
            {
                txt_qntd_item.Text = dgv_venda.CurrentRow.Cells["col_qntd"].Value.ToString();
            }
        }

        private void btn_alterar_Click(object sender, EventArgs e)
        {
            if(txt_qntd_item.Text != "")
            {

                txt_qntd.Text = dgv_venda.CurrentRow.Cells["col_qntd"].Value.ToString();
                qntd = int.Parse(txt_qntd.Text);

                txt_valor_unit.Text = dgv_venda.CurrentRow.Cells["col_valor_unit"].Value.ToString();
                valor_unit = double.Parse(txt_qntd.Text);

                total -= qntd * valor_unit;
                dgv_venda.CurrentRow.Cells["col_qntd"].Value = txt_qntd_item.Text;

                MessageBox.Show("Quantidade alterada", "Alterar",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            txt_qntd.Text = dgv_venda.CurrentRow.Cells["col_qntd"].Value.ToString();
            qntd = int.Parse(txt_qntd.Text);

            txt_valor_unit.Text = dgv_venda.CurrentRow.Cells["col_valor_unit"].Value.ToString();
            valor_unit = double.Parse(txt_valor_unit.Text);

            total += qntd * valor_unit;
            lbl_total.Text = total.ToString("C");
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        void Limpar()
        {
            dgv_venda.RowCount = 0;

            lbl_item.Text = dgv_venda.RowCount.ToString();

            txt_descricao.Clear();
            txt_qntd.Clear();
            txt_valor_unit.Clear();
            total = 0;
            lbl_total.Text = "R$ 0,00";
        }


        private void btn_fechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
