using PersonnelManagement.EntityFramework.Concrate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelManagement.Business.Abstract
{
    public interface IPersonnelService:IService<Personnel>
    {

        Task<Personnel> Authenticate(string kullaniciAdi, string sifre);
    }
}
