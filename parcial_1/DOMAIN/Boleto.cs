using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DOMAIN
{
    public abstract class Boleto
    {
        public Guid IdBoleto { get; set; }
        public int Numero { get; }

        public DateTime FechaSalida { get; set; }

        public int TiempoDias {  get; set; }

        public float CostoEmbarque {  get; set; }

        public TipoBoleto TipoBoleto { get; }

        public float Costo_total {  get; set; }

        public Boleto()
        {
           
        }
        
    }
}
