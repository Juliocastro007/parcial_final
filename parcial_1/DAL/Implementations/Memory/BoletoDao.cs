using DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOMAIN;

namespace DAL.Implementations.Memory
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
            _list = new List<Boleto>();

            for (int i = 1; i <= 10; i++)
            {
                //Boleto boleto = new Boleto(i + 1, i.ToString());
                //boleto.IdBoleto = Guid.NewGuid();
                //_list.Add(boleto);
            }
        }
        #endregion

        private static List<Boleto> _list;

        public void Add(Boleto obj)
        {
            //Qué debería hacer para agregar un customer?
            //Ver si existe? -> Lo validamos en negocio si es que yo
            //envío el id

            //Simulamos que el id es auto-incremental
            obj.IdBoleto = Guid.NewGuid();
            _list.Add(obj);
        }

        public List<Boleto> GetAll()
        {
            return _list;
        }

        public Boleto GetById(Guid idboleto)
        {
            //Estructurado, más adelante veremos funcional con Linq
            Boleto boleto = default;

            foreach (var item in _list)
            {
                if (item.IdBoleto == idboleto)
                {
                    boleto = item;
                    break;
                }
            }

            return boleto;
        }

        public void Remove(Guid idboleto)
        {
            _list.Remove(GetById(idboleto));
        }

        public void Update(Boleto obj)
        {
            Boleto boleto = GetById(obj.IdBoleto);

            boleto.CostoEmbarque = obj.CostoEmbarque;
            boleto.FechaSalida = obj.FechaSalida;

        }

        public Boleto GetByCode(int code)
        {
            throw new NotImplementedException();
        }

        public List<Boleto> GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}

