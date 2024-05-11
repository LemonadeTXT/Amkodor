﻿using Amkodor.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amkodor.BusinessLogic.Interfaces
{
    public interface IMaterialSupplierService
    {
        IEnumerable<MaterialSupplier> GetAllMaterialsSuppliers();

        IEnumerable<MaterialSupplier> GetAllMaterialsSupBySupplierId(int supplierId);
    }
}
