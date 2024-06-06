using DOMAIN;
using DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Factory;
using BLL;

namespace primer_parcial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IBoletoDao boletoDao = FactoryDao.BoletoDao;

            BoletoLogic total = new BoletoLogic();
            BoletoLogic fechaderegreso = new BoletoLogic();

            int tipo,cant_dias = 0;
            string fecha_regreso;
            DateTime fecha;

            Console.WriteLine("ingrese tipo de boleto: 0=Base , 1= Turista 2= Ejecutivo");
            tipo = int.Parse(Console.ReadLine());

            Console.WriteLine("ingrese Fecha de Salida: dd/mm/yyyy");
            fecha = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("ingrese Duración del Viaje en Dias: ");
            cant_dias = int.Parse(Console.ReadLine());

            fecha_regreso = fechaderegreso.CalcularRegreso(cant_dias, fecha);


            Turista demo = new Turista();
            demo.FechaSalida = fecha;
            demo.Costo_total = total.GetCostoBoleto(tipo);
            demo.TiempoDias = cant_dias;
            boletoDao.Add(demo);

            foreach (var item in boletoDao.GetAll())
            {
                Console.WriteLine($"Fecha de Salida: {item.FechaSalida}, Costo total: {item.Costo_total}, y su cantidad de dias es: {item.TiempoDias},Fecha de regreso es: {fecha_regreso}");
                Console.ReadKey();
            }



            //customerGonzalez = BoletoDao.GetById(Guid.Parse("F5705F68-1FBB-44C7-9DFF-ED98021BDE1E"));


            //customerDao.Add(new Customer(0, "Nuevo Producto"));

            //Customer customerById = customerDao.GetById(Guid.Parse("71154AF7-E604-446E-8BE3-2A41F5694AE3"));
            //customerById.Category = CategoryEnum.Standard;

            //customerDao.Remove(Guid.Parse("71154AF7-E604-446E-8BE3-2A41F5694AE3"));

            //customerById = customerDao.GetById(Guid.Parse("71154AF7-E604-446E-8BE3-2A41F5694AE3"));
            //customerById.Name = "Aprendiendo repository pattern";
            //customerDao.Update(customerById);
        }
    }
}
