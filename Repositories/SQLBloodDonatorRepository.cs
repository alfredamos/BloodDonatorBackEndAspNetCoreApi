
using BloodDonatorBackEndAspNetCoreApi.Models;
using BloodDonatorBackEndAspNetCoreApi.Contracts;
using BloodDonatorBackEndAspNetCoreApi.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodDonatorBackEndAspNetCoreApi.Repositories
{
    public class SQLBloodDonatorRepository : IBloodDonatorRepository
    {
        private readonly ApplicationDbContext _context;

        public SQLBloodDonatorRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<BloodDonator> AddEntity(BloodDonator newEntity)
        {
            var BloodDonator = await _context.BloodDonators.AddAsync(newEntity);
            await _context.SaveChangesAsync();
            return BloodDonator.Entity;
        }

        public async Task<BloodDonator> DeleteEntity(int id)
        {
            var BloodDonatorToDelete = await _context.BloodDonators.FindAsync(id);
            if (BloodDonatorToDelete != null)
            {
                _context.BloodDonators.Remove(BloodDonatorToDelete);
                await _context.SaveChangesAsync();
            }
            return BloodDonatorToDelete;
        }

        public async Task<IEnumerable<BloodDonator>> GetAll()
        {
            return await _context.BloodDonators.ToListAsync();
        }

        public async Task<BloodDonator> GetById(int id)
        {
            return await _context.BloodDonators.FindAsync(id);
        }

        public async Task<IEnumerable<BloodDonator>> Search(string searchKey)
        {
            IQueryable<BloodDonator> query = _context.BloodDonators;
            if (string.IsNullOrWhiteSpace(searchKey))
            {
                return await query.ToListAsync();
            }

            return await query.Where(x => x.Address.Contains(searchKey) ||
                         x.BloodGroup.Contains(searchKey) ||
                         x.Email.Contains(searchKey) ||
                         x.FullName.Contains(searchKey) ||
                         x.PhoneNumber.Contains(searchKey)
                         ).ToListAsync();
        }

        public async Task<BloodDonator> UpdateEntity(BloodDonator updateEntity)
        {
            var BloodDonatorToUpdate = _context.BloodDonators.Attach(updateEntity);
            BloodDonatorToUpdate.State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return BloodDonatorToUpdate.Entity;
        }
    }
}
