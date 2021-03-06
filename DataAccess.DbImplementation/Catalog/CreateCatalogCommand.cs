﻿using System.Threading.Tasks;
using AutoMapper;
using DB;
using Entities;
using ViewModel;


namespace DataAccess.DbImplementation
{
    public class CreateCatalogsCommand : ICreateCatalogsCommand
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CreateCatalogsCommand(AppDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }
        public async Task<CatalogsResponse> ExecuteAsync(CreateCatalogsRequest request)
        {
            var catalogofcatalogs = _mapper.Map<CreateCatalogsRequest, Catalog>(request);
            await _context.AddAsync(catalogofcatalogs);
            await _context.SaveChangesAsync();
            return _mapper.Map<Catalog, CatalogsResponse>(catalogofcatalogs);
        }
    }
}
