using System;
using DAL.Contracts;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOMAIN;
using DAL.Helpers;
using DAL.Implementations.SqlServer.Mappers;
using static DAL.Helpers.SqlHelpers;

namespace DAL.Implementations.SqlServer
{
    internal sealed class BoletoDao : IBoletoDao
    {
        #region singleton
        private readonly static BoletoDao _instance = new BoletoDao();

        public static BoletoDao Current
        {
            get
            {
                return _instance;
            }
        }

        private BoletoDao()
        {
            //Implent here the initialization of your singleton
        }
        #endregion


        #region Statements
        private string InsertStatement
        {
            get => "INSERT INTO [dbo].[Venta_boletos] (IdBoleto, Numero, FechaSalida, TiempoDias, CostoEmbarque) VALUES (@id, @numero, @Fecha, @Tiempo, @Costo); Select @@IDentity";
        }

        private string UpdateStatement
        {
            get => "UPDATE [dbo].[Venta_boletos] SET (FechaSalida = @Fecha, CostoEmbarque = @Costo) WHERE IdBoleto = @id";
        }

        private string DeleteStatement
        {
            get => "DELETE FROM [dbo].[Venta_boletos] WHERE IdBoleto = @id";
        }

        private string SelectOneStatement
        {
            get => "SELECT IdBoleto, Numero, FechaSalida, TiempoDias, CostoEmbarque  FROM [dbo].[Venta_boletos] WHERE IdBoleto = @id";
        }

        private string SelectAllStatement
        {
            get => "SELECT IdBoleto, Numero, FechaSalida, TiempoDias, CostoEmbarque FROM [dbo].[Venta_boletos]";
        }
        #endregion


        public void Add(Boleto obj)
        {
            //SqlParameter parameter = new SqlParameter("@IdCustomer", obj.IdCustomer);
            //parameter.Direction = ParameterDirection.Output;

            object returnValue = SqlHelper.ExecuteScalar("CustomerInsert", CommandType.StoredProcedure,
                new SqlParameter[] { new SqlParameter("@numero", obj.Numero),
                                     new SqlParameter("@Fecha", obj.FechaSalida),
                                     new SqlParameter("@Tiempo", obj.TiempoDias),
                                     new SqlParameter("@Costo", obj.CostoEmbarque) });
            // parameter});

            obj.IdBoleto = Guid.Parse(returnValue.ToString());
        }

        public void Update(Boleto obj)
        {
            //ExecuteNonQuery
        }

        public void Remove(Guid id)
        {
            //ExecuteNonQuery
        }

        public Boleto GetById(Guid id)
        {
            Boleto boleto = default;

            using (var reader = SqlHelper.ExecuteReader(SelectOneStatement, CommandType.Text,
              new SqlParameter[] { new SqlParameter("@Id", id) }))
            {
                //Mientras tenga algo en mi tabla de Customers
                if (reader.Read())
                {
                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);

                    if (boleto.TipoBoleto == TipoBoleto.Turista)
                    {
                        boleto = BoletoMappers.Current.FillTurista(data);
                    }
                    else if (boleto.TipoBoleto == TipoBoleto.Ejecutivo)
                    {
                        boleto = BoletoMappers.Current.FillEjecutivo(data);
                    }
                    else
                    {
                        boleto = BoletoMappers.Current.FillBase(data);
                    }
                    

                }
            }

            return boleto;
        }

        public List<Boleto> GetAll()
        {
            List<Boleto> boletos = new List<Boleto>();

            using (var reader = SqlHelper.ExecuteReader(SelectAllStatement, CommandType.Text,
                new SqlParameter[] { }))
            {
                //Mientras tenga algo en mi tabla de boletos
                while (reader.Read())
                {

                    object[] data = new object[reader.FieldCount];
                    reader.GetValues(data);
                    //Data Mapper...
                    Boleto boleto = BoletoMappers.Current.FillTurista(data);
                    boletos.Add(boleto);
                }
            }

            return boletos;

        }

        public Boleto GetByCode(int numero)
        {
            throw new NotImplementedException();
        }

        public List<Boleto> GetByFechaSalida(DateTime Fecha)
        {
            throw new NotImplementedException();
        }
    }
}

