using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LsMapasNet.Contexto
{

    public class LsMapaContextInitCreateDataBase : CreateDatabaseIfNotExists<LsMapaContext>
    {
        protected override void Seed(LsMapaContext context)
        {
            base.Seed(context);
        }
    }
}