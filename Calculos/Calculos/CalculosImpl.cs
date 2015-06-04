using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculos
{
    public class CalculosImpl : ICalculos
    {
        public double Adicao(double op1, double op2)
        {
            return op1 + op2;
        }
        public double Subtracao(double op1, double op2)
        {
            return op1 - op2;
        }
        public double Multiplicacao(double op1, double op2)
        {
            return op1 * op2;
        }
        public double Divisao(double op1, double op2)
        {
            if (op2 != 0)
                return op1 / op2;
            else
                throw new ApplicationException("Divisão por zero");
        }
    }
}
