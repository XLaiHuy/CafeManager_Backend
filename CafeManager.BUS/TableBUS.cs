using CafeManager.DAL;
using CafeManager.DAL.Models;
using CafeManager.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManager.BUS
{
    public class TableBUS
    {
        private readonly TableDAL _tableDal;
         public TableBUS(TableDAL tableDAL)
        {
            _tableDal = tableDAL;
        }
        public List<DTO.TableDTO> GetListTables()
        {
            var tables = _tableDal.GetListTables();
            return tables.Select(t => new DTO.TableDTO
            {
                Id = t.Id,
                Name = t.Name,
                Status = t.Status
            }).ToList();
        }
        public void createTable(TableDTO input)
        {
            if (string.IsNullOrWhiteSpace(input.Name) || input.Name == "string")
            {
                throw new Exception("Tên bàn không được để trống!");
            }
            var existingTable = _tableDal.GetTablebyName(input.Name);
            if (existingTable != null)
            {
                throw new Exception("Tên bàn này đã tồn tại, vui lòng chọn tên khác!");
            }
            var table = new Tablefood
            {
                Name = input.Name,
                Status = (string.IsNullOrWhiteSpace(input.Status) || input.Status == "string")
                         ? "Trống"
                         : input.Status,
                Isdeleted = false
            };
            _tableDal.AddTable(table);
        }
        public void DeleteTable(int id)
        {
            var table = _tableDal.GetTablebyid(id);
            if (table == null) throw new Exception("Bàn không tồn tại");
            if (table.Status == "Có người")
            {
                throw new Exception("Bàn đang có người, không thể xóa!");
            }
            _tableDal.DeleteTable(table);
        }
        public void UpdateTable(TableDTO input)
        {
            var table = _tableDal.GetTablebyid(input.Id);
            if (table == null) throw new Exception("Bàn không tồn tại");
            if (!string.IsNullOrWhiteSpace(input.Name) && input.Name != "string")
            {
                var checkName = _tableDal.GetTablebyName(input.Name);
                if (checkName != null && checkName.Id != input.Id)
                {
                    throw new Exception("Tên bàn này đã tồn tại!");
                }
                table.Name = input.Name;
            }
            if (!string.IsNullOrWhiteSpace(input.Status) && input.Status != "string")
            {
                table.Status = input.Status;
            }
            _tableDal.UpdateTable(table);
        }
    }
}
