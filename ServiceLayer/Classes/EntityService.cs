using ModelsLayer.Context;
using ModelsLayer.Models;
using RepositoryLayer.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Classes
{
    public class EntityService<T> : GenericRepository<T> where T : BaseEntity
    {
        public EntityService(ApplicationDbContext context) : base(context)
        {
        }
    }
}
