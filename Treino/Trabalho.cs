using System;
using System.Collections.Generic;
using System.Text;

namespace Treino
{
    class Trabalho
    {
        private string _nome;
        public int Id { get; set; }
        public double Salario { get; set; }
        public DateTime Tempo { get; set; }

        public Trabalho(int id, string nome, double salario, DateTime horario)
        {
            Id = id;
            _nome = nome;
            Salario = salario;
            Tempo = horario;
        }
        public string Nome
        {
            get { return _nome; }
            set
            {
                if (value != null && value.Length > 1)
                {
                    _nome = Nome;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Informe um nome válido!");
                    Console.ResetColor();
                }
            }
        }
        public override string ToString()
        {
            return "ID: "
                + Id
                + " | Nome: "
                + Nome
                + " | Salário: "
                + Salario
                + " Reais"
                + "  -  Criado em: "
                + Tempo;
        }
    }
}