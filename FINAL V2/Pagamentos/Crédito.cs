using System;
using System.Xml;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data.SqlClient;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using System.Threading;
using MimeKit;
using Google.Apis.Services;
using System.IO;

namespace FINAL_V2
{
    public partial class Crédito : Form
    {
       
        private Vendas ValorTotalForm;

        private string valorFormatadoVendas;

        private string valorFormatadoDesconto;

        private string Empresa = "Book.in";

        private string CNPJ = "00000000000000";

        private List<Vendas.Produto> produtos;

        private string Destinatario;
        public static TextBox TextBox2 { get; set; }

        public Crédito(Vendas valorTotal, List<Vendas.Produto> produtos)
        {
            InitializeComponent();

            TextBox2 = textBox2;

            // Corrija a inicialização aqui
            this.ValorTotalForm = valorTotal;
            this.produtos = produtos;

            // Carregue os valores formatados no construtor
            AtualizarValoresFormatados();
        }

        private void AtualizarValoresFormatados()
        {
            // Carregue os valores formatados a partir das propriedades do formulário Vendas
            decimal valorTotalVendas = ValorTotalForm.ValorTotal / 100;
            decimal valorTotalDesconto = ValorTotalForm.DescontoTotal / 100;

            // Formatar os valores para exibir apenas dois dígitos após a vírgula
            valorFormatadoVendas = valorTotalVendas.ToString("N2");
            valorFormatadoDesconto = valorTotalDesconto.ToString("N2");

        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {


                // Feche o formulário quando a tecla "Esc" for pressionada.
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void Crédito_KeyDown(object sender, KeyEventArgs e)
        {
            // Verifica se a tecla pressionada é a tecla F10
            if (e.KeyCode == Keys.F10)
            {
                // Chama a função do button1_Click
                button1_Click(sender, e);
            }
        }

        private decimal CalcularLucroTotal()
        {
            decimal lucroTotal = 0;

            string connectionString = "Data Source=26.170.34.113;Initial Catalog=SistemaYiG;User ID=sa;Password=123";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Consulta para somar o lucro dos produtos presentes na lista 'produtos'
                    string query = "SELECT SUM(CAST(Lucro AS decimal)) FROM Estoque WHERE Nome IN (";

                    // Adiciona parâmetros dinamicamente para cada produto na lista 'produtos'
                    for (int i = 0; i < produtos.Count; i++)
                    {
                        query += $"@Produto{i}";
                        if (i < produtos.Count - 1)
                        {
                            query += ", ";
                        }
                    }

                    query += ")";

                    // Criação do SqlCommand
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Define os parâmetros dinâmicos para os produtos presentes na lista 'produtos'
                        for (int i = 0; i < produtos.Count; i++)
                        {
                            command.Parameters.AddWithValue($"@Produto{i}", produtos[i].Nome);
                        }

                        // Executa a consulta e obtém o valor do lucro total
                        object resultado = command.ExecuteScalar();

                        if (resultado != null && resultado != DBNull.Value)
                        {
                            string lucroComoString = resultado.ToString();

                            if (decimal.TryParse(lucroComoString, out decimal valorLucro))
                            {
                                lucroTotal += valorLucro;
                            }
                            else
                            {
                                // Lida com valores que não puderam ser convertidos para decimal
                                // Pode ser um bom lugar para fazer log dos valores problemáticos
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao calcular o lucro total: " + ex.Message);
                }
            }

            return lucroTotal;
        }

        private static void SendEmailWithGmailAPI(string attachmentPath, string Destinatario)
        {
            string credPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            credPath = Path.Combine(credPath, ".credentials", "gmail-dotnet-quickstart.json");

            using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    new[] { GmailService.Scope.MailGoogleCom },
                    "user",
                    CancellationToken.None).Result;

                var gmailService = new GmailService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Gmail API .NET Quickstart"
                });

                var mimeMessage = new MimeMessage();
                mimeMessage.From.Add(new MailboxAddress("BOOK.IN", "yuribernardo@gmail.com"));
                mimeMessage.To.Add(new MailboxAddress("Client", Destinatario));
                mimeMessage.Subject = "BOOK.IN - NOTA FISCAL";

                // Adiciona o arquivo XML como anexo ao e-mail
                var attachment = new MimePart("application", "octet-stream")
                {
                    Content = new MimeContent(File.OpenRead(attachmentPath)),
                    ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                    ContentTransferEncoding = ContentEncoding.Base64,
                    FileName = Path.GetFileName(attachmentPath)
                };

                // Adiciona o anexo ao corpo do e-mail
                var body = new TextPart("plain")
                {
                    Text = "Ola,\n\n" +
                       "Segue em Anexo sua Nota Fiscal,\n" +
                       "Obrigado por compra na BOOK.IN,\n\n" +
                       "Volte sempre."
                };

                var multipart = new Multipart("mixed");
                multipart.Add(body);
                multipart.Add(attachment);

                mimeMessage.Body = multipart;

                var rawMessage = Base64UrlEncode(mimeMessage.ToString());

                var email = new Google.Apis.Gmail.v1.Data.Message // Usando a classe Message do Gmail API
                {
                    Raw = rawMessage
                };

                try
                {
                    gmailService.Users.Messages.Send(email, "me").Execute();
                    Console.WriteLine("Email sent successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }

        private static string Base64UrlEncode(string input)
        {
            var inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(inputBytes)
                .Replace('+', '-')
                .Replace('/', '_')
                .Replace("=", "");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Destinatario = TextBox2.Text;

            AtualizarEstoque();

            int ultimoNumeroNotaID = ObterUltimoNumeroNotaIDDoBancoDeDados();

            decimal lucroTotal = CalcularLucroTotal();

            // Obtém a data atual
            DateTime dataAtual = DateTime.Now;

            // Concatena todos os produtos em uma variável única para NomeProduto
            string todosProdutos = "";
            foreach (Vendas.Produto produto in produtos)
            {
                todosProdutos += produto.Nome + ", ";
            }
            todosProdutos = todosProdutos.TrimEnd(',', ' '); // Remove a última vírgula e espaço

            // Aqui você pode adicionar as informações à tabela NFADM
            AdicionarInformacoesNFADM(ultimoNumeroNotaID, dataAtual, todosProdutos, valorFormatadoVendas, lucroTotal);

            // Cria um novo SaveFileDialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // Define o filtro para mostrar apenas arquivos XML
            saveFileDialog.Filter = "Arquivos XML (*.xml)|*.xml";

            // Define o título da janela de diálogo
            saveFileDialog.Title = "Salvar Nota Fiscal";

            // Define o nome padrão do arquivo com base no último número da NotaID
            saveFileDialog.FileName = $"NotaFiscal_{ultimoNumeroNotaID}.xml";

            // Mostra a janela de diálogo para selecionar o caminho
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string caminhoCompleto = saveFileDialog.FileName;
                string destinatarioEmail = textBox2.Text; // Obtenha o texto do textBox2

                // Chama a função para gerar a nota fiscal e passa o caminho escolhido
                GerarNotaFiscal(caminhoCompleto);

                // Envie o e-mail após a geração da nota fiscal, passando o destinatarioEmail
                SendEmailWithGmailAPI(caminhoCompleto, Destinatario); // <-- Remova uma dessas linhas
            }
        }

        private void AdicionarInformacoesNFADM(int ultimoNumeroNotaID, DateTime dataAtual, string nomeProduto, string valorComercial, decimal lucroTotal)
        {
            string connectionString = "Data Source=26.170.34.113;Initial Catalog=SistemaYiG;User ID=sa;Password=123";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Convertendo a data para o formato string compatível com o SQL Server (yyyy-MM-dd HH:mm:ss)
                    string dataFormatada = dataAtual.ToString("yyyy-MM-dd HH:mm:ss");

                    // Convertendo o valor do lucro para string
                    string lucroTotalString = lucroTotal.ToString();

                    string query = "INSERT INTO NFADM (IDNota, Data, NomeProduto, ValorComercial, Lucro) " +
                    "VALUES (@UltimoNumeroNotaID, @DataFormatada, @NomeProduto, @ValorComercial, @LucroTotalString)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Defina os parâmetros
                        command.Parameters.AddWithValue("@UltimoNumeroNotaID", ultimoNumeroNotaID);
                        command.Parameters.AddWithValue("@DataFormatada", dataFormatada);
                        command.Parameters.AddWithValue("@NomeProduto", nomeProduto);
                        command.Parameters.AddWithValue("@ValorComercial", valorComercial);
                        command.Parameters.AddWithValue("@LucroTotalString", lucroTotalString);

                        command.ExecuteNonQuery();
                        
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao adicionar informações à tabela NFADM: " + ex.Message);
                }
            }
        }

        private int ObterUltimoNumeroNotaIDDoBancoDeDados()
        {
            int ultimoNumeroNotaID = 0;

            // Conectar ao banco de dados
            string connectionString = "Data Source=26.170.34.113;Initial Catalog=SistemaYiG;User ID=sa;Password=123";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Execute a instrução SQL para inserir um novo registro e obter o último valor inserido na coluna "NotaID"
                    string query = "SELECT MAX(NotaID) FROM NumNotas";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Obter o valor inserido na coluna "NotaID"
                        object resultado = command.ExecuteScalar();

                        // Verificar se o resultado não é nulo e pode ser convertido para um número inteiro
                        if (resultado != null && int.TryParse(resultado.ToString(), out ultimoNumeroNotaID))
                        {
                            // Sucesso
                        }
                        else
                        {
                            MessageBox.Show("Valor inválido retornado pela consulta.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao acessar o banco de dados: " + ex.Message);
                }
            }

            return ultimoNumeroNotaID;
        }
        // Método para codificar em Base64 URL Safe
        private void GerarNotaFiscal(string caminhoCompleto)
        {
            // Criação do documento XML
            XmlDocument xmlDoc = new XmlDocument();

            int ultimoNumeroNotaID = ObterUltimoNumeroNotaIDDoBancoDeDados();

            // Elemento raiz
            XmlElement root = xmlDoc.CreateElement("NotaFiscal");
            xmlDoc.AppendChild(root);

            XmlElement numero = xmlDoc.CreateElement("Numero");
            numero.InnerText = ultimoNumeroNotaID.ToString();
            root.AppendChild(numero);

            XmlElement empresa = xmlDoc.CreateElement("Empresa");
            empresa.InnerText = Empresa;
            root.AppendChild(empresa);

            XmlElement cnpj = xmlDoc.CreateElement("CNPJ");
            cnpj.InnerText = CNPJ;
            root.AppendChild(cnpj);


            XmlElement Operador = xmlDoc.CreateElement("Operador");
            Operador.InnerText = "Yuri";
            root.AppendChild(Operador);

            XmlElement data = xmlDoc.CreateElement("Data");
            data.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            root.AppendChild(data);

            XmlElement CPF = xmlDoc.CreateElement("CPF");
            CPF.InnerText = textBox1.Text;
            root.AppendChild(CPF);

            XmlElement email = xmlDoc.CreateElement("e-mail");
            email.InnerText = textBox2.Text;
            root.AppendChild(email);

            // Detalhes dos produtos
            XmlElement produtosElement = xmlDoc.CreateElement("Produtos");
            root.AppendChild(produtosElement);

            XmlElement desconto = xmlDoc.CreateElement("Desconto");
            desconto.InnerText = valorFormatadoDesconto;
            root.AppendChild(desconto);

            XmlElement valorTotalElement = xmlDoc.CreateElement("ValorTotal");
            valorTotalElement.InnerText = valorFormatadoVendas;
            root.AppendChild(valorTotalElement);

            XmlElement metodoElement = xmlDoc.CreateElement("MétodoDePagamento");
            valorTotalElement.InnerText = "Crédito";
            root.AppendChild(metodoElement);
            // Adicione cada produto à nota fiscal
            foreach (Vendas.Produto produto in produtos)
            {
                XmlElement produtoElement = xmlDoc.CreateElement("Produto");

                XmlElement nomeProduto = xmlDoc.CreateElement("Nome");
                nomeProduto.InnerText = produto.Nome;
                produtoElement.AppendChild(nomeProduto);

                XmlElement quantidade = xmlDoc.CreateElement("Quantidade");
                quantidade.InnerText = produto.Quantidade.ToString();
                produtoElement.AppendChild(quantidade);

                XmlElement precoUnitario = xmlDoc.CreateElement("PrecoUnitario");
                precoUnitario.InnerText = (produto.Valor).ToString("F2");
                produtoElement.AppendChild(precoUnitario);

                produtosElement.AppendChild(produtoElement);
            }



            // Salva o arquivo XML no caminho escolhido pelo usuário
            xmlDoc.Save(caminhoCompleto);

        }

        private void AtualizarEstoque()
        {
            string connectionString = "Data Source=26.170.34.113;Initial Catalog=SistemaYiG;User ID=sa;Password=123";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Loop pelos produtos para atualizar o estoque
                    foreach (Vendas.Produto produto in produtos)
                    {
                        string consultaQuantidadeAtual = $"SELECT Quantidade FROM Estoque WHERE Nome = '{produto.Nome}'";

                        using (SqlCommand command = new SqlCommand(consultaQuantidadeAtual, connection))
                        {
                            // Obtém a quantidade atual do banco de dados como um objeto
                            object quantidadeObj = command.ExecuteScalar();

                            // Verifica se a quantidadeObj não é nula antes de converter
                            if (quantidadeObj != null)
                            {
                                // Converte o valor retornado do banco de dados para inteiro
                                if (int.TryParse(quantidadeObj.ToString(), out int quantidadeAtual))
                                {
                                    if (quantidadeAtual >= int.Parse(produto.Quantidade.ToString()))
                                    {
                                        int novaQuantidade = quantidadeAtual - int.Parse(produto.Quantidade.ToString());

                                        string atualizarEstoqueQuery = $"UPDATE Estoque SET Quantidade = {novaQuantidade} WHERE Nome = '{produto.Nome}'";

                                        using (SqlCommand updateCommand = new SqlCommand(atualizarEstoqueQuery, connection))
                                        {
                                            updateCommand.ExecuteNonQuery();
                                        }

                                    }
                                    else
                                    {
                                        MessageBox.Show($"Quantidade insuficiente de '{produto.Nome}' no estoque.");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Erro ao converter a quantidade do banco de dados para um número inteiro.");
                                }
                            }
                            else
                            {
                                MessageBox.Show($"Não foi possível encontrar a quantidade para '{produto.Nome}' no banco de dados.");
                            }
                        }
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao acessar o banco de dados: " + ex.ToString());
                }
            }
        }
        private void Crédito_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Verifica se existem produtos para exibir informações
            if (produtos != null && produtos.Count > 0)
            {
                // Cria uma mensagem para exibir os detalhes dos produtos
                string mensagem = "Detalhes dos Produtos:\n\n";

                // Adiciona detalhes de cada produto à mensagem
                foreach (Vendas.Produto produto in produtos)
                {
                    mensagem += $"Nome: {produto.Nome}\n";
                    mensagem += $"Quantidade: {produto.Quantidade}\n";
                    mensagem += $"Valor Unitário: {produto.Valor}\n";
                    mensagem += "\n";
                }

                // Exibe os detalhes dos produtos em uma MessageBox
                MessageBox.Show(mensagem, "Detalhes dos Produtos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Se não houver produtos, exibe uma mensagem indicando que não há produtos para mostrar
                MessageBox.Show("Não há produtos para exibir.", "Sem Produtos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}