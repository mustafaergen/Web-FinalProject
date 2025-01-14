using FinalProject_Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_Entities.Abstracts
{
    public abstract class BaseEntity
    {
        // abstract neden yapıyoruz inctance alınmasın nesnesi oluşturulmasın diye
        //kalıtım almak için tasarladığımmız bir sınıftır.
        // kalıtım aldığımız diğer yerlerde aynı şeyleri yazmamak için 
        // generic bir mimari kullanıldığında güvenlik açuısından kolaylık sağlar.

        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public Status Status { get; set; } = Status.Active;

    }
}
