namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {

        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();


        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        // Verifica se a placa esta no formato correto para os padroes Brasil (placas antigas cinzas) ou Mercosul.
        // Utilizado pelo AdicionarVeiculo()
        private bool VerificarPlaca(string placa, char formato) 
        {
            // Formato Brasil (LLL-NNNN) com 8 caracteres totais
            if (formato == '1' &&  placa.Length == 8)
            {
                for (int contador = 0; contador < placa.Length; contador++)
                {
                    if (contador < 3)
                    {
                        if (Char.IsLetter(placa[contador]) == false)
                        {
                            Console.WriteLine("Placa invalida para o formato escolhido.");
                            return false;
                        }
                    }
                    if (contador > 3)
                    {
                        if (Char.IsNumber(placa[contador]) == false)
                        {
                            Console.WriteLine("Placa invalida para o formato escolhido (numeros).");
                            return false;
                        }
                    }
                }
                return true;
            }

            // Formato Mercosul (LLLNLNN) com 7 caracteres totais
            if (formato == '2' && placa.Length == 7)
            {
                for (int contador = 0; contador < placa.Length; contador++)
                {
                    if (contador < 3 || contador == 4)
                    {
                        if (Char.IsLetter(placa[contador]) == false)
                        {
                            Console.WriteLine("Placa invalida para o formato escolhido.");
                            return false;
                        }
                    }
                    if (contador == 3 || contador == 5 || contador == 6)
                    {
                        if (Char.IsNumber(placa[contador]) == false)
                        {
                            Console.WriteLine("Placa invalida para o formato escolhido.");
                            return false;
                        }
                    }
                }
                return true;
            }
            Console.WriteLine("Placa em formato invalido devido a quantidade de caracteres (Faltou o (-) no formato Brasil?).");
            return false;
        }


        public void AdicionarVeiculo() // IMPLEMENTADO!
        {
            while (true)
            {
                Console.WriteLine("Qual e o formato da placa? (1 - Brasil, 2 - Mercosul, 0 - Cancelar)");
                string escolha = Console.ReadLine();
                if (escolha[0] == '0')
                {
                    Console.WriteLine("Operação cancelada pelo usuario.");
                    break;
                }
                if (escolha[0] == '1')
                {
                    Console.WriteLine("Digite a placa do veículo para estacionar: (Incluir o [-])");
                    string input = Console.ReadLine();
                    if (VerificarPlaca(input, '1') == true)
                    {
                        veiculos.Add(input);
                        Console.WriteLine("Veiculo adicionado com sucesso.");
                        break;
                    }
                }
                if (escolha[0] == '2')
                {
                    Console.WriteLine("Digite a placa do veículo para estacionar:");
                    string input = Console.ReadLine();
                    if (VerificarPlaca(input, '2') == true)
                    {
                        veiculos.Add(input);
                        Console.WriteLine("Veiculo adicionado com sucesso.");
                        break;
                    }
                }
            }
        }


        public void RemoverVeiculo() // IMPLEMENTADO!
        {
            while (true)
            {
                Console.WriteLine("Digite a placa do veículo para remover (0 para cancelar):");
                string placa = Console.ReadLine();
                // Se for '0' retorna ao menu principal
                if (placa[0] == '0')
                {
                    Console.WriteLine("Operação cancelada pelo usuario.");
                    break;
                }
                // Verificar se a placa tem o numero de caracteres certo para ser uma placa Brasil ou Mercosul (8, 7 respectivamente)
                if (placa.Length > 8 || placa.Length < 7)
                {
                    Console.WriteLine("Formato de placa invalido devido ao numero de caracteres.");
                }
                else
                {
                    // Verifica se o veículo existe
                    if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
                    {
                        Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                        int horas = 0;
                        decimal valorTotal = 0;
                        // ReadLine so recebe string, entao se usa variavel 'buffer' para armazenar e dar Parse para int
                        string buffer = Console.ReadLine();
                        int.TryParse(buffer, out horas);
                        // Verifica se horas retornou 0 (nulo) do Parse
                        if (horas == 0)
                        {
                            Console.WriteLine("Numero de horas invalido ou zero.");
                        }
                        else
                        {
                            valorTotal = precoInicial + (precoPorHora * horas);
                            veiculos.Remove(placa);
                            Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                    }
                }
            }
        }


        public void ListarVeiculos() //IMPLEMENTADO!
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (string placa in veiculos)
                {
                    Console.WriteLine($"{placa}");
                }
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                // *IMPLEMENTE AQUI*
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
