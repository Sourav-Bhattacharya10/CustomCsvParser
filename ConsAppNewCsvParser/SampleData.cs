using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsAppNewCsvParser
{
    //Always create fields and properties
    //otherwise CsvParser won't work
    public class SampleData
    {
        private int _id;
        private string _dept;
        private string _Name;
        private int _count;

        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Dept
        {
            get
            {
                return _dept;
            }

            set
            {
                _dept = value;
            }
        }

        public string Name
        {
            get
            {
                return _Name;
            }

            set
            {
                _Name = value;
            }
        }

        public int Count
        {
            get
            {
                return _count;
            }

            set
            {
                _count = value;
            }
        }
    }
}
