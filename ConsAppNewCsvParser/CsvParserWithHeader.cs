using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsAppNewCsvParser
{
    public class CsvParserWithHeader
    {
        private string _file;
        private string[] _csvData;
        private string[] _headers;
        private string[][] _rows;

        public CsvParserWithHeader(string filepath)
        {
            File = filepath;

            try
            {
                ReadFile();
            }
            catch (Exception ex)
            {
                _csvData = null;
            }
        }

        public string File
        {
            get
            {
                return _file;
            }

            set
            {
                _file = value;
            }
        }

        public string[] Headers
        {
            get
            {
                return _headers;
            }

            set
            {
                _headers = value;
            }
        }

        public string[][] Rows
        {
            get
            {
                return _rows;
            }

            set
            {
                _rows = value;
            }
        }

        private void ReadFile()
        {
            _csvData = System.IO.File.ReadAllLines(File);
            AssignHeaders();
            AssignRows();
        }

        private void AssignHeaders()
        {
            Headers = _csvData[0].Split(',');
        }

        private void AssignRows()
        {
            Rows = new string[_csvData.Length - 1][];
            for (int i = 1; i < _csvData.Length; i++)
            {
                Rows[i - 1] = _csvData[i].Split(',');
            }
        }

        public List<T> Deserialize<T>() where T : new()
        {
            List<T> ResultData = null;

            var type = typeof(T);
            var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            try
            {
                ResultData = new List<T>();

                for (int i = 0; i < Rows.Length; i++)
                {
                    var obj = new T();

                    for (int j = 0; j < Headers.Length; j++)
                    {
                        string fieldName = Headers[j];
                        var prop = props.FirstOrDefault(x => x.Name.ToLower() == fieldName.ToLower());
                        if (prop != null)
                        {
                            var val = Convert.ChangeType(Rows[i][j], prop.PropertyType.GetTypeInfo());
                            prop.SetValue(obj, val);
                        }
                    }

                    ResultData.Add(obj);
                }
            }
            catch (Exception ex)
            {
                ResultData = null;
            }

            return ResultData;
        }
    }
}
