using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal.Entidades;
using TrabalhoFinal.Excecoes;
using TrabalhoFinal.Servicos;
using System.Globalization;

namespace TrabalhoFinal
{
    internal class Menu
    {
        Locadora locadora;
        string fabricante;
        string modelo;
        float valor;
        int id;
        string finalidade;
        string cpf;
        string nome;
        int telefone;
        float salario;
        string cargo;
        Funcionario vendedor;
        Funcionario gerente;
        Cliente cliente;
        Carro carro;
        int aux = 0;

        public Menu(Locadora locadora)
        {
            this.locadora = locadora;
        }

        public string MsgMenuInicial()
        {
            return "Bem vindo à Locadora Sampaio, qual ação você deseja iniciar?\n\n" +
                "[1] Procurar carros disponíveis no estoque \n" +
                "[2] Adicionar novo carro ao estoque \n" +
                "[3] Procurar funcionários admitidos \n" +
                "[4] Admitir novo funcionário \n" +
                "[5] Procurar clientes cadastrados \n" +
                "[6] Cadastrar novo clente \n" +
                "[7] Iniciar operação de venda \n" +
                "[8] Iniciar operação de aluguel \n\n" +
                "Sua Escolha: ";
        }

        public void MenuInicial()
        {
            Console.Write(MsgMenuInicial());

            int escolha = int.Parse(Console.ReadLine());

            Console.WriteLine();

            try
            {
                switch (escolha)
                {
                    case 1:
                        MenuBuscaCarro();
                        break;

                    case 2:
                        AdicionarId();
                        break;

                    case 3:
                        MenuBuscarFuncionarios();
                        break;

                    case 4:
                        MenuAdicionarFuncionario();
                        break;

                    case 5:
                        BuscarClientesCadastrados();
                        break;

                    case 6:
                        CadastrarCliente();
                        break;

                    case 7:
                        MenuOperacaoVenda();
                        break;

                    case 8:
                        MenuOperacaoAluguel();
                        break;

                    default:
                        throw new MenuIndexNotFoundException("Index inserido inválido, tente novamente");
                }
            }
            catch (MenuIndexNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine();
                MenuInicial();
            }
        }

        public string MsgMenuBuscaCarro()
        {
            return "Qual tipo de carro você deseja procurar?\n\n" +
                "[1] Carros disponíveis para aluguel\n" +
                "[2] Carros disponíveis para venda\n\n" +
                "Sua Escolha: ";
        }

        public void MenuBuscaCarro()
        {
            Console.Write(MsgMenuBuscaCarro());

            int escolha = int.Parse(Console.ReadLine());

            Console.WriteLine();

            try
            {
                switch (escolha)
                {
                    case 1:
                        locadora.BuscarCarroAluguel();
                        break;

                    case 2:
                        locadora.BuscarCarroVenda();
                        break;

                    default:
                        throw new MenuIndexNotFoundException("Index inserido inválido, tente novamente");
                }
            }
            catch (MenuIndexNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                var a = Console.ReadKey();
                MenuBuscaCarro();
            }
            finally
            {
                var a = Console.ReadKey();
                Console.WriteLine();
                MenuInicial();
            }


        }

        public void AdicionarId()
        {
            Console.WriteLine("Para adicionar um carro ao estoque informe as características:");
            Console.Write("Id: ");
            id = int.Parse(Console.ReadLine());
            AdicionarFinalidade();
        }

        public void AdicionarFinalidade()
        {
            try
            {
                Console.Write("Finalidade: ");
                finalidade = Console.ReadLine();
                if (finalidade != "Aluguel" && finalidade != "Venda") throw new MenuCaracteristicaInvalidaException("Caracteristica digitada inválida(Tente 'Aluguel' ou 'Venda'");

            }
            catch (MenuCaracteristicaInvalidaException ex)
            {
                Console.WriteLine();
                Console.WriteLine(ex.Message);
                AdicionarFinalidade();
            }
            finally
            {
                AdicionarFabricante();
            }
        }

        public void AdicionarFabricante()
        {
            Console.Write("Fabricante: ");
            fabricante = Console.ReadLine();
            AdicionarModelo();
        }

        public void AdicionarModelo()
        {
            Console.Write("Modelo: ");
            modelo = Console.ReadLine();
            AdicionarValor();
        }

        public void AdicionarValor()
        {
            if(finalidade == "Venda") Console.Write("Valor de Venda: ");
            else Console.Write("Diária: ");

            valor = float.Parse(Console.ReadLine());

            try
            {
                Console.WriteLine();
                if (finalidade == "Aluguel") locadora.AdicionarCarro(new CarroAluguel(fabricante, modelo, valor, id));
                if (finalidade == "Venda") locadora.AdicionarCarro(new CarroVenda(fabricante, modelo, valor, id));
            }
            catch (ParametroInvalidoException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Operação Cancelada");
                var a = Console.ReadKey();
                Console.WriteLine();
            }
            finally
            {
                MenuInicial();
            }
        }

        public string MsgMenuBuscarFuncionarios()
        {
            return "Qual tipo de fumcionário você deseja buscar?\n" +
                "[1] Gerentes\n" +
                "[2] Vendedores\n\n" +
                "Sua Escolha: ";
        }

        public void MenuBuscarFuncionarios()
        {

            Console.Write(MsgMenuBuscarFuncionarios());

            int escolha = int.Parse(Console.ReadLine());

            Console.WriteLine();
            try
            {
                switch (escolha)
                {
                    
                    case 1:
                        Console.WriteLine("Gerentes Admitidos:");
                        Console.WriteLine();
                        locadora.ProcurarFuncionarioPorCago("Gerente");
                        break;
                    case 2:
                        Console.WriteLine("Vendedores Admitidos:");
                        Console.WriteLine();
                        locadora.ProcurarFuncionarioPorCago("Vendedor");
                        break;
                    default:
                        throw new MenuIndexNotFoundException("Index inserido inválido, tente novamente");
                }
            }
            catch (MenuIndexNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine();
                MenuBuscarFuncionarios();
            }
            finally
            {
                var a = Console.ReadKey();
                Console.WriteLine();
                MenuInicial();
            }
        }

        public void AdicionarCPF()
        {
            Console.Write("CPF: ");
            cpf = Console.ReadLine();
            AdicionarNome();
        }

        public void AdicionarNome()
        {
            Console.Write("Nome: ");
            nome = Console.ReadLine();
            AdicionarTelefone();
        }

        public void AdicionarTelefone()
        {
            Console.Write("Telefone: ");
            telefone = int.Parse(Console.ReadLine());

            if(aux == 1) AdicionarSalario();
            else
            {
                try
                {
                    locadora.AdicionarCliente(new Cliente(cpf, nome, telefone));
                    Console.WriteLine();
                    Console.WriteLine("Cliente cadastrado!");
                }
                catch(ParametroInvalidoException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Operação Cancelada");
                }
                finally
                {
                    var a = Console.ReadKey();
                    Console.WriteLine();
                    MenuInicial();
                }

            }
        }

        public void AdicionarSalario()
        {
            Console.Write("Salario: ");
            salario = float.Parse(Console.ReadLine());
            AdicionarCargo();
        }

        public void AdicionarCargo()
        {
            try
            {
                Console.Write("Cargo: ");
                cargo = Console.ReadLine();
                if (cargo != "Gerente" && cargo != "Vendedor") throw new MenuCaracteristicaInvalidaException("Caracteristica digitada inválida (Tente 'Gerente' ou 'Vendedor')");

            }
            catch (MenuCaracteristicaInvalidaException ex)
            {
                Console.WriteLine();
                Console.WriteLine(ex.Message);
                AdicionarCargo();
            }
            finally
            {
                try
                {
                    Console.WriteLine();
                    if (cargo == "Gerente") locadora.AdicionarFuncionario(new Gerente(cpf, nome, telefone, salario));
                    if (cargo == "Vendedor") locadora.AdicionarFuncionario(new Vendedor(cpf, nome, telefone, salario));
                    Console.WriteLine("Funcionario admitido");
                }
                catch (ParametroInvalidoException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Operação Cancelada");
                }
                finally
                {
                    
                    var a = Console.ReadKey();
                    Console.WriteLine();
                    MenuInicial();
                }
            }
        }

        public void MenuAdicionarFuncionario()
        {
            Console.WriteLine("Para admitir um funcionário resposta dos campos abaixo da maneira correta: ");
            aux = 1;
            AdicionarCPF();
        }

        public void BuscarClientesCadastrados()
        {
            Console.WriteLine("Lista de clientes cadastrados: ");
            locadora.BuscarClientes();
            var a = Console.ReadKey();
            MenuInicial();
        }

        public void CadastrarCliente()
        {
            Console.WriteLine("Para cadastrar um cliente responda os campos abaixo:");
            aux = 0;
            AdicionarCPF();
        }

        public void AdicionarVendedor()
        {
            try
            {
                Console.Write("Digite o cpf do vendedor: ");
                cpf = Console.ReadLine();
                vendedor = locadora.ProcurarFuncionarioPorCPF(cpf);
                AdicionarGerente();
            } 
            catch (ObjectNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                var a = Console.ReadKey();
                Console.WriteLine();
                AdicionarVendedor();
            }
        }

        public void AdicionarGerente()
        {
            try
            {
                Console.Write("Digite o cpf do gerente: ");
                cpf = Console.ReadLine();
                gerente = locadora.ProcurarFuncionarioPorCPF(cpf);
                AdicionarClienteVenda();
            }
            catch (ObjectNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                var a = Console.ReadKey();
                Console.WriteLine();
                AdicionarGerente();
            }
        }

        public void AdicionarClienteVenda()
        {
            try
            {
                Console.Write("Digite o cpf do cliente: ");
                cpf = Console.ReadLine();
                cliente = locadora.BuscarClientePorCPF(cpf);
                AdicionarCarro();
            }
            catch (ObjectNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                var a = Console.ReadKey();
                Console.WriteLine();
                AdicionarClienteVenda();
            }
        }

        public void AdicionarCarro()
        {
            try
            {
                Console.Write("Digite o id do carro: ");
                id = int.Parse(Console.ReadLine());
                carro = locadora.BuscarCarroPorId(id);
            }
            catch (ObjectNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                var a = Console.ReadKey();
                Console.WriteLine();
                AdicionarCarro();
            }
            finally
            {
                if (aux == 0) adicionarDevolucao();
                else
                {
                    try
                    {
                        locadora.OperacaoVenda(new ServicoVenda(vendedor, gerente, cliente, carro));
                    }
                    catch (ParametroInvalidoException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("Operação Cancelada");
                    }
                    finally
                    {
                        Console.WriteLine("Venda efetuado!");
                        var a = Console.ReadKey();
                        Console.WriteLine();
                        MenuInicial();
                    }
                } 
            }
        }

        public void adicionarDevolucao()
        {
            var adq = CultureInfo.InvariantCulture;
            Console.WriteLine("Data de retirada (dd/MM/yyyy):");
            DateTime retirada = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", adq);

            try
            {
                locadora.OperacaoAluguel(new ServicoAluguel(retirada,vendedor, gerente, cliente, carro));
            }
            catch (ParametroInvalidoException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Operação Cancelada");
            }
            finally
            {
                Console.WriteLine("Aluguel efetuado!");
                var a = Console.ReadKey();
                Console.WriteLine();
                MenuInicial();
            }
        }

        public void MenuOperacaoVenda()
        {
            Console.WriteLine("Para iniciar uma operação de venda responda os campos abaixo:");
            var a = Console.ReadKey();
            aux = 1;
            AdicionarVendedor();
        }

        public void MenuOperacaoAluguel()
        {
            Console.WriteLine("Para iniciar uma operação de aluguel responda os campos abaixo:");
            var a = Console.ReadKey();
            aux = 0;
            AdicionarVendedor();
        }
    }
}
