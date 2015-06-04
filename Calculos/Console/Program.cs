using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Calculos;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            double op1 = 5;
            double op2 = 10;
            // declarar objecto do tipo interface para cliente do serviço
            Calculos.ICalculos comp;
            // instanciar objecto da classe implementação do serviço
            comp = new Calculos.CalculosImpl();
            double resultado = comp.Adicao(op1, op2);
            System.Console.WriteLine("Adiçao {0} + {1} ={2}", op1, op2,
            resultado);
            System.Console.ReadKey();
        }
    }
}
