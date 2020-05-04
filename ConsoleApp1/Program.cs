using System;
using System.Data;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            test dbbtest=new test(); ;
            dbbtest.TestDataRowChanges();
            Console.ReadLine();
        }
       
    }

    public class test
    {
        DataRow dr;
        private DataSet dataSet;
        public test()
        {
           
        }

        public void TestDataSetChanges()
        {
            GetDataSet();
            AddDataRow();
           // changeDataSet();
            Console.WriteLine(CheckDataSetState().ToString());
        }

        public void TestDataRowChanges()
        {
            GetDataSet();
            AddDataRow();
            changeDataRow();
        }
        public void GetDataSet()
        {
            DataSet dataSetLocal = new DataSet();
            DataTable table = new DataTable();
            table.Columns.Add("name", typeof(string));
            dataSetLocal.Tables.Add(table);
            this.dataSet= dataSetLocal;
        }
        public string returnnvalue(int a)
        {
            return returnnvalue(a + 1);
        }
        private void changeDataSet()
        {
            dataSet.Tables[0].Rows[0].Delete();
        }

        public void AddDataRow()
        {
            DataTable table = dataSet.Tables[0];
            DataRow newRow = table.NewRow();
            newRow[0] = "raman";
          
            table.Rows.Add(newRow);
            newRow.AcceptChanges();
            table.AcceptChanges();
        }
        public void changeDataRow()
        {
            Console.WriteLine("Fetch Row from table"); 

            dr = dataSet.Tables[0].Rows[0];

            Console.WriteLine("Before Edit Starts");
            Console.WriteLine(dr.RowState.ToString());

           
            Console.WriteLine("Begin Edit Starts");
            dr.BeginEdit();
            Console.WriteLine("Begin Edit End  " + dr.RowState.ToString());

            Console.WriteLine("Value Edit Ends " + dr.RowState.ToString());
            dr[0] = "middha";
            Console.WriteLine("Value Edit State " + dr.RowState.ToString());

            Console.WriteLine("End Edit Start " + dr.RowState.ToString());
            dr.EndEdit();
            Console.WriteLine("End Edit  Ends");

            string current=dr[0, DataRowVersion.Proposed].ToString();
            string Original = dr[0, DataRowVersion.Original].ToString();
          

            Int32 action = Convert.ToInt32(Console.ReadLine());
            if(action==1)
            {
                Console.WriteLine("Commit  Starts");
                dr.AcceptChanges();
                Console.WriteLine("After Commit State " + dr.RowState.ToString());

            }
            else
            {
                Console.WriteLine("Reject  Starts");
                dr.RejectChanges();
                Console.WriteLine("After Commit State " + dr.RowState.ToString());

            }



        }
        public bool CheckDataSetState()
        {
            return dataSet.HasChanges();

        }
        public string DataTableWithoutRowAdded()
        {
            //if (newRow.HasVersion(DataRowVersion.Proposed))
            //{
            //    return "Proposed";
            //}
            //else if(newRow.HasVersion(DataRowVersion.Current))
            //{

            //    return "Current";
            //}
            return "not changed";
        }

    }
}
