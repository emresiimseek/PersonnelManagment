using PersonnelManagement.EntityFramework.Concrate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelManagement.Business.Abstract
{
    public interface IPersonnelService
    {

        Task<Personnel> Authenticate(string kullaniciAdi, string sifre);
    }
}
