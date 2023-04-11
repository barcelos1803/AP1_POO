using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Vaga
{
    // Propriedades
    public int Numero { get; set; }
    public bool Ocupada { get; private set; }
    public Veiculo Veiculo { get; private set; }

    // Construtor
    public Vaga(int numero)
    {
        Numero = numero;
        Ocupada = false;
    }

        public void Ocupar(Veiculo veiculo)
    {
        Ocupada = true;
        Veiculo = veiculo;
    }

        public void Desocupar()
    {
        Ocupada = false;
        Veiculo = null;
    }
}
