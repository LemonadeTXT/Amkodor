﻿using Amkodor.BusinessLogic.Interfaces;
using Amkodor.DAL.Interfaces;
using Amkodor.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amkodor.BusinessLogic.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public IEnumerable<Supplier> GetAllSuppliers()
        {
            return _supplierRepository.GetAllSuppliers();
        }

        public void Add(Supplier supplier)
        {
            _supplierRepository.Add(supplier);
        }

        public void Edit(Supplier supplier)
        {
            _supplierRepository.Edit(supplier);
        }

        public void Delete(Supplier supplier)
        {
            _supplierRepository.Delete(supplier);
        }
    }
}
