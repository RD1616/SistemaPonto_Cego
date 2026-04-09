using System;
using System.Windows.Forms;

namespace SistemaPontoCego.UI
{
    public partial class Pagamento : Form
    {
        // Esse é o CONSTRUTOR. Ele DEVE ter o nome da classe e receber a string.
        public Pagamento(string valorTotal)
        {
            InitializeComponent();

            // Aqui você joga o valor que recebeu na label da tela de pagamento
            // Verifique se o nome é 'label1' mesmo. Se for outro nome, troque aqui.
            label1.Text = "Total a Pagar: " + valorTotal;
        }

        // Você pode deixar o Load vazio ou apagá-lo se não estiver usando
        private void Pagamento_Load(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Método de pagamento PIX foi escolhido!", "Pagamento");
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Método de pagamento Boleto Bancário foi escolhido!", "Pagamento");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Método de pagamento Cartão de Crédito foi escolhido!", "Pagamento");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. Criamos uma nova instância da tela de compras (carrinho)
            Comprar telaCarrinho = new Comprar();

            // 2. Mostramos a tela do carrinho
            telaCarrinho.Show();

            // 3. Fechamos a tela de pagamento atual
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 1. Exibe uma mensagem amigável de sucesso
            MessageBox.Show("Pagamento confirmado com sucesso! Obrigado pela compra.", "Sucesso");

            // 2. Cria a instância da tela de Produtos (Vitrine)
            // Verifique se o nome da classe é 'Produtos' ou 'Form3' como apareceu antes
            Produtos telaProdutos = new Produtos();

            // 3. Mostra a vitrine
            telaProdutos.Show();

            // 4. Fecha a tela de pagamento atual
            this.Close();
        }
    }
}