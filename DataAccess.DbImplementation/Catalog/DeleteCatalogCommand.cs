﻿using System;
using System.Threading.Tasks;
using Entities;
using DB;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DbImplementation
{
    public class DeleteCatalogsCommand : IDeleteCatalogsCommand
    {
        private readonly AppDbContext _context;

        public DeleteCatalogsCommand(AppDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task ExecuteAsync(Guid catalogofcatalogsId)
        {
            Catalog catalogofcatalogsToDelete = await _context.Catalogs.FirstOrDefaultAsync(p => p.Id == catalogofcatalogsId);
            /*if (catalogofcatalogsToDelete?.CheapPlaces?.Count > 0)
            {
                throw new CannotDeleteCityWithCheapPlacesExeption();
            }*/

            if (catalogofcatalogsToDelete != null)
            {
                _context.Catalogs.Remove(catalogofcatalogsToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
