using System;

namespace ProjetoFinal.Classes
{
    public class Cliente
    {
        private Cliente()
        { }
        public string Nome { get; private set; }
        
        public string CPF { get; private set; }
        
        public DateTime DataNascimento { get; private set; }
        
        public string Endereco { get; private set; }

       

        

        public bool EhMaiorIDade => ValidarSeClienteEMaiorDeIdade();

        public static Cliente CreateCliente(string nome, string cpf, DateTime dataNascimento, string endereco ) =>
            new Cliente { Nome = nome, CPF = cpf, DataNascimento = dataNascimento, Endereco = endereco };

        public override string ToString() => $"Nome...........: {Nome}\nDocumento......: {CPF} \nData de Nasc...: {DataNascimento:dd/MM/yyyy}\nEndereço..........: {Endereco}";

        private bool ValidarSeClienteEMaiorDeIdade() => DateTime.Now.Year - DataNascimento.Year >= 18;

    }
}