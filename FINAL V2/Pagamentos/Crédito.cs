using System;
using System.Xml;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace FINAL_V2
{
    public partial class Crédito : Form
    {
        // Deve ser uma propriedade para armazenar a referência ao formulário Vendas
        private Vendas ValorTotalForm;

        private string valorFormatadoVendas;

        private string valorFormatadoDesconto;

        private string Empresa = "Book.in";

        private string CNPJ = "00000000000000";

        private List<Vendas.Produto> produtos;

        public Crédito(Vendas valorTotal, List<Vendas.Produto> produtos)
        {
            InitializeComponent();

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

        private void button1_Click(object sender, EventArgs e)
        {
            // Obtém o último número presente na coluna NotaID da tabela NumNotas
            int ultimoNumeroNotaID = ObterUltimoNumeroNotaIDDoBancoDeDados();

            // Incrementa o número para uso no nome do arquivo XML
            int numeroArquivoXML = ultimoNumeroNotaID;

            // Cria um novo SaveFileDialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // Define o filtro para mostrar apenas arquivos XML
            saveFileDialog.Filter = "Arquivos XML (*.xml)|*.xml";

            // Define o título da janela de diálogo
            saveFileDialog.Title = "Salvar Nota Fiscal";

            // Define o nome padrão do arquivo com base no último número da NotaID
            saveFileDialog.FileName = $"NotaFiscal_{numeroArquivoXML}.xml";

            // Exibe o diálogo e verifica se o usuário clicou em "OK"
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Obtém o caminho do arquivo escolhido pelo usuário
                string caminhoCompleto = saveFileDialog.FileName;

                // Chama a função para gerar a nota fiscal e passa o caminho escolhido
                GerarNotaFiscal(caminhoCompleto);

                // Outras ações que você deseja realizar ao clicar no botão
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
            Operador.InnerText = ultimoNumeroNotaID.ToString();
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

        private void Crédito_Load(object sender, EventArgs e)
        {

        }
    }
}
