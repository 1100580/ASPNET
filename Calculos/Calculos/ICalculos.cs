using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculos
{
    public interface ICalculos
    {
        double Adicao(double op1, double op2);
        double Subtracao(double op1, double op2);
        double Multiplicacao(double op1, double op2);
        double Divisao(double op1, double op2);
    }
}
