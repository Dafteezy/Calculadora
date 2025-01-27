namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Seja bem-vindo à Calculadora Simples!");
            Console.WriteLine("Digite 1 para Soma, 2 para Subtração, 3 para Multiplicação, 4 para Divisão ou 5 para sair.");

            if (short.TryParse(Console.ReadLine(), out short res))
            {
                switch (res)
                {
                    case 1: RealizarOperacao("soma", (a, b) => a + b); break;
                    case 2: RealizarOperacao("subtração", (a, b) => a - b); break;
                    case 3: RealizarOperacao("multiplicação", (a, b) => a * b); break;
                    case 4: RealizarOperacao("divisão", (a, b) => a / b); break;
                    case 5: Environment.Exit(0); break;
                    default: Menu(); break;
                }
            }
            else
            {
                Console.WriteLine("Entrada inválida. Pressione qualquer tecla para tentar novamente.");
                Console.ReadKey();
                Menu();
            }
        }

        static void RealizarOperacao(string operacao, Func<float, float, float> calculo)
        {
            Console.Clear();
            Console.WriteLine($"Você escolheu {operacao}.");

            Console.Write("Digite o primeiro valor: ");
            if (!float.TryParse(Console.ReadLine(), out float v1))
            {
                Console.WriteLine("Valor inválido. Pressione qualquer tecla para tentar novamente.");
                Console.ReadKey();
                Menu();
                return;
            }

            Console.Write("Digite o segundo valor: ");
            if (!float.TryParse(Console.ReadLine(), out float v2))
            {
                Console.WriteLine("Valor inválido. Pressione qualquer tecla para tentar novamente.");
                Console.ReadKey();
                Menu();
                return;
            }

            if (operacao == "divisão" && v2 == 0)
            {
                Console.WriteLine("Erro: Não é possível dividir por zero. Pressione qualquer tecla para tentar novamente.");
                Console.ReadKey();
                Menu();
                return;
            }

            float resultado = calculo(v1, v2);
            Console.WriteLine($"\nO resultado da {operacao} é: {resultado}");
            Console.ReadKey();
            Menu();
        }
    }
}
