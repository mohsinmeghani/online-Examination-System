using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES_BAL
{
    class Program
    {
        public int ID { get; set; }
        public String Code { get; set; }
        public string Name { get; set; }
        public String Details { get; set; }


        public Program()
        {
            
        }

        public Program(int ID)
        {
            var p = Get(ID);
            this.ID = p.ID;
            this.Name = p.Name;
            this.Code = p.Code;
            this.Details = p.Details;
        }

        public Program Get(int ID)
        {
            var context = new OES_DALDataContext();
            var rs = context.db_programs.Where(x => x.program_id == ID).FirstOrDefault();
            Program p = new Program();
            p.ID = rs.program_id;
            p.Name = rs.program_name;
            p.Code = rs.program_code;
            p.Details = rs.program_details;

            return p;
        }


        public List<Program> GetAll()
        {
            List<Program> list = new List<Program>();
            var context = new OES_DALDataContext();
            var programs = (from p in context.db_programs
                            select p);
            foreach (var program in programs)
            {
                var p = new Program();
                p.ID = program.program_id;
                p.Name = program.program_name;
                p.Code = program.program_details;
                list.Add(p);
            }

            return list;

        }


        public void Add()
        {
            var context = new OES_DALDataContext();
            var p = new db_program();
            p.program_id = GetNewID();
            p.program_name = Name;
            p.program_code = Code;
            p.program_details = Details;

            context.db_programs.InsertOnSubmit(p);
            context.SubmitChanges();

        }

        public void Delete(int ID)
        {
            var context = new OES_DALDataContext();
            var rs = context.db_programs.Where(x => x.program_id == ID).FirstOrDefault();
            context.db_programs.DeleteOnSubmit(rs);
            context.SubmitChanges();
        }

        public void Update(int ID)
        {
            var context = new OES_DALDataContext();
            var rs = context.db_programs.Where(x => x.program_id == ID).FirstOrDefault();
        }

        private int GetNewID()
        {
            var context = new OES_DALDataContext();
            var id = context.db_programs.Max(x => x.program_id);
            if (id!=null)
            {
                return id + 1;

            }

            return 1;
        }
    }
}
