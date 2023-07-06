using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreinandoBasico
{
    internal class Tarefa
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataVencimento { get; set; }

        public override string ToString()
        {
            return $"Título: {Titulo}\nDescrição: {Descricao}\nData de Vencimento: {DataVencimento}";
        }

    }
}
