using System;
using System.Text;
using System.Security.Cryptography;
using System.Data.SqlClient; // ESSA LINHA É A MAIS IMPORTANTE
using System.Windows.Forms;

namespace SistemaPontoCego.UI
{
    public partial class Cadastro : Form
    {
        private string emailCadastrado;
        private string senhaCadastrada;

        public Cadastro()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {

        }

        private void txtEmailCadastro_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            // 1. String de Conexão (Ajuste o 'Data Source' para o seu servidor)
            string conexao = @"Data Source=SEU_SERVIDOR;Initial Catalog=SistemaPonto_Cego;Integrated Security=True";

            // 2. Criptografia SHA256 (Transformando a senha aqui mesmo)
            string senhaHash = "";
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(txtSenhaCadastro.Text));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                senhaHash = builder.ToString();
            }

            // 3. Inserindo no Banco de Dados
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                try
                {
                    conn.Open();
                    string sql = "INSERT INTO Usuarios (Nome, Email, Senha, Ativo) VALUES (@Nome, @Email, @Senha, 1)";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        // Passando os valores das TextBoxes
                        cmd.Parameters.AddWithValue("@Nome", txtNomeCadastro.Text);
                        cmd.Parameters.AddWithValue("@Email", txtEmailCadastro.Text);
                        cmd.Parameters.AddWithValue("@Senha", senhaHash); // Gravando o HASH, não a senha limpa!

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Usuário cadastrado com sucesso usando SHA256!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao conectar no banco: " + ex.Message);
                }
            }
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            // 1. Validação do '@' no login
            if (!txtEmailLogin.Text.Contains("@"))
            {
                MessageBox.Show("Por favor, insira um e-mail válido para logar.", "Erro de Formato", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // 2. Comparação com os dados salvos
            if (txtEmailLogin.Text == emailCadastrado && txtSenhaLogin.Text == senhaCadastrada)
            {
                MessageBox.Show("Login realizado!");
                new Produtos().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Dados incorretos!");
            }
        }

        private void CadastrioeLogin_Load(object sender, EventArgs e)
        {

        }

        private void chkVerSenha_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVerSenha.Checked)
            {
                txtSenhaLogin.PasswordChar = '\0'; // Mostra a senha
            }
            else
            {
                txtSenhaLogin.PasswordChar = '*'; // Esconde a senha
            }
        }
        

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            // Se o CheckBox estiver marcado
            if (chkVerSenha2.Checked)
            {
                // '\0' é o caractere nulo, ele remove qualquer máscara e mostra o texto real
                txtSenhaCadastro.PasswordChar = '\0';
            }
            else
            {
                // Se desmarcar, volta a esconder com o asterisco (ou o caractere que preferir)
                txtSenhaCadastro.PasswordChar = '*';
            }
        }
    }
}
