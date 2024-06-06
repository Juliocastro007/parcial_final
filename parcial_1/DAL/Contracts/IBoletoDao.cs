using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOMAIN;

namespace DAL.Contracts
{
    public interface IBoletoDao : IGenericDao<Boleto>
    {
        //Boleto GetBoleto(int id);  

        //Boleto GetByCode(int code);

        

        //List<Boleto> GetByName(string name);
    }
}
