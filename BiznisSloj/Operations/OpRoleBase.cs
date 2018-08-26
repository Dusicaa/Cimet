using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using Sajt.BiznisSloj.DTO;
using Sajt.DataSloj;

namespace Sajt.BiznisSloj.Operations
{
    public class RoleCriteria : SelectCriteria
    {

        public string Name { get; set; }
    }

    public class OpRoleBase : Operation
    {
        public RoleDto Role = new RoleDto();
        public RoleCriteria criteria = new RoleCriteria();

        public override OperationResult execute(CimetEntities entities)
        {

            IEnumerable<RoleDto> ieRole =
                from uloga in entities.AspNetRoles
                select new RoleDto
                {
                    Id = uloga.Id,
                    Name = uloga.Name

                };
            //ovde prosirujemo upit
            if (!criteria.Uuid.IsNullOrWhiteSpace())
            {
                ieRole = ieRole.Where(r => r.Id == criteria.Uuid);

            }

            if (!criteria.Name.IsNullOrWhiteSpace())
            {
                ieRole = ieRole.Where(r => r.Name == criteria.Name);

            }

            OperationResult result = new OperationResult();
            result.Items = ieRole.ToArray();
            result.Status = true;
            return result;
        }

    }


    public class OpRoleInsert : OpRoleBase
    {

        public override OperationResult execute(CimetEntities entities)
        {
        AspNetRoles role = new AspNetRoles();
        role.Name= this.Role.Name;
        role.Id= this.Role.Uuid;
            entities.AspNetRoles.Add(role);
            entities.SaveChanges();
            return base.execute(entities);
        }
    }

    public class OpRoleDelete : OpRoleBase
    {     public string Uuid { get; set; }
        public override OperationResult execute(CimetEntities entities)
        {
            base.criteria.Uuid = Uuid;
            AspNetRoles role = entities.AspNetRoles.Where(r=>r.Id==Uuid && r.AspNetUsers.Count()==0).FirstOrDefault();
            if(role!=null){

                entities.AspNetRoles.Remove(role);
                entities.SaveChanges();
                return base.execute(entities);
            }
            else
            {

                OperationResult result = new OperationResult();
                result.Status = false;
                result.Message = "Uloga ne postoji ili sadrzi korisnike!";
                return result;
            }

           
          
        }
    }

    public class OpRoleUpdate : OpRoleBase
    {
        public override OperationResult execute(CimetEntities entities)
        {
            AspNetRoles role = entities.AspNetRoles.Where(r => r.Id == Role.Uuid).FirstOrDefault();
            if (role != null)
            {
                role.Name = Role.Name;
                entities.SaveChanges();
                return base.execute(entities);
            }

            OperationResult result = new OperationResult();
            result.Status = false;
            result.Message = "Uloga ne postoji.";
            return result;
        }
    }
}