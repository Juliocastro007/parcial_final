using DOMAIN;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
 public class BoletoLogic
 { 
   float total = 0;



        Turista pturista = new Turista();
        Base pbase = new Base();
        Ejecutivo pejecutivo = new Ejecutivo();

        public BoletoLogic()
        {

        }
            public float GetCostoBoleto(int tipo)
            {
            if (tipo == (int)TipoBoleto.Base) // Tipo base
            {
                total = pbase.CostoEmbarque + pbase.CostoBase;
                return total;
            }
            else if (tipo == (int)TipoBoleto.Turista) // Tipo turista
            {
                total = pbase.CostoEmbarque + pbase.CostoBase + pturista.CostoTurista;
                return total;
            }
            else if (tipo == (int)TipoBoleto.Ejecutivo) // Tipo ejecutivo
            {
                total = pbase.Costoembarque + pbase.CostoBase + pejecutivo.CostoEjecutivo;
                return total;
            }
            else
            {
                throw new ArgumentException("Tipo de boleto no válido");
            }
            }

            public string CalcularRegreso (int cant,DateTime fecha)
            {
                string fecharegreso;

                fecharegreso = fecha.AddDays(cant).ToString();

                return fecharegreso;
            }
          public void SaveOrUpdate(Boleto boleto)
          {
                


          }
          public void Delete(Boleto boleto)
            {

            }
          public Boleto GetById(int id)
            {
                return null;
            }
          public List<Boleto> GetAll()
           {
                return null;
           }

    }
    }

