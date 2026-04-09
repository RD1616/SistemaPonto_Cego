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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // 1. A mesma string de conexão que você usará na aula
            string conexao = @"Data Source=NOMEDOSERVIDOR;Initial Catalog=SistemaPonto_Cego;Integrated Security=True";

            // 2. Transformamos a senha digitada no Login em SHA256
            // Isso é necessário porque no banco a senha está criptografada
            string senhaLoginHash = "";
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(txtSenhaLogin.Text));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                senhaLoginHash = builder.ToString();
            }

            // 3. Verificação no Banco de Dados
            using (SqlConnection conn = new SqlConnection(conexao))
            {
                try
                {
                    conn.Open();
                    // Buscamos um usuário que tenha o e-mail E a senha hash iguais
                    string sql = "SELECT Nome FROM Usuarios WHERE Email = @Email AND Senha = @Senha";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", txtEmailLogin.Text);
                        cmd.Parameters.AddWithValue("@Senha", senhaLoginHash);

                        // Executa a consulta e retorna o primeiro resultado (o nome do usuário)
                        object resultado = cmd.ExecuteScalar();

                        if (resultado != null)
                        {
                            string nomeUsuario = resultado.ToString();
                            MessageBox.Show($"Bem-vindo, {nomeUsuario}! Login realizado com sucesso.");

                            // Aqui você abriria sua tela principal
                            // FormPrincipal principal = new FormPrincipal();
                            // principal.Show();
                            // this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("E-mail ou senha incorretos.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro técnico: " + ex.Message);
                }
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
