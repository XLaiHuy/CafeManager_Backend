using CafeManager.DAL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManager.DAL
{
    public class TableDAL
    {
        private readonly CafeContext _context;
        public TableDAL(CafeContext context)
        {
            _context = context;
        }
        public List<Tablefood> GetListTables()
        {
            return _context.Tablefoods
                .Where(t=> t.Isdeleted == false)
                .OrderBy(t => t.Id)
                .ToList();
        }
        public Tablefood GetTablebyid(int id)
        {
            return _context.Tablefoods.FirstOrDefault(t => t.Id == id && t.Isdeleted == false);
        }
        public Tablefood GetTablebyName(string name)
        {
            string cleanedName = name.Trim();
            return _context.Tablefoods.FirstOrDefault(t => t.Name.ToLower() == cleanedName.ToLower() && t.Isdeleted == false);
        }
       public void AddTable(Tablefood table)
        {
            _context.Tablefoods.Add(table);
            _context.SaveChanges();
        }
        public void UpdateTable(Tablefood table)
        {
           _context.Tablefoods.Update(table);
            _context.SaveChanges();
        }
        public void DeleteTable(Tablefood table)
        {
            table.Isdeleted = true;
            _context.Tablefoods.Update(table);
            _context.SaveChanges();
        }
    }
}
