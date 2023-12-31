﻿ using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestsExamples.Data;

namespace UnitTestsExamples
{
    #region "Helper Classes"

    public interface IMyObject { 
    
    }
    public class MyObject: IMyObject {
        public string fname;
        public string lname;
    }

    //Must be Interface because FakeItEasy just faking and mocking interfaces !!
    public interface ISub_Functions {
        public bool func_return_bool();
        public IMyObject func_params_return_my_object(string fname, string lname);
        public IEnumerable<MyObject> func_return_List_new_object();
    }

    public class Sub_Functions: ISub_Functions {
        public bool func_return_bool() {
            return false;
        }

        public IMyObject func_params_return_my_object(string fname,string lname) {
            return new MyObject()
            {
                fname = fname,
                lname = lname
            };
        }

        public IEnumerable<MyObject> func_return_List_new_object() {
            return new List<MyObject> {
                new MyObject()
                {
                    fname="Hamze",
                    lname="Yasin"
                },
                new MyObject(){
                    fname="Israa",
                    lname="yasin"
                }
            };
        }
    }
    #endregion
    public class Functions
    {
        
        #region "Initialization"
        private readonly ISub_Functions sub_Functions;
        private readonly ApplicationDBContext dbContext;
        public Functions(ISub_Functions sub_Functions)
        {
            this.sub_Functions = sub_Functions;
        }
        public Functions(ApplicationDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        #endregion

        

        #region "Normal Unit Tests"
        public string func_return_string(int num) {
            if (num == 0)
            {
                return "Ich mag Syrien";
            }
            else {
                return "Ich mag Deutschland";
            }
        }

        public string func_without_params_return_string() {
            return "PALESTINE";
        }

        public int func_adding_num_return_int(int a, int b) {
            return a + b;
        }

        public DateTime func_return_date_now() {
            return DateTime.Now;
        }

        public MyObject func_get_my_object() {
            return new MyObject()
            {
                fname = "Sumaya",
                lname = "Ali"
            };
        }

        public List<MyObject> func_return_list_my_object() {

            return new List<MyObject> {
                new MyObject(){
                    fname="Sarah",
                    lname="Ali"
                },
                new MyObject(){
                    fname="Salam",
                    lname="Ali"
                }
            };
        }
        #endregion

        
        #region "Mocking Unit Tests"
        public string func_call_sub_function_class() {

            var iscall = sub_Functions.func_return_bool();

            if (iscall)
            {
                return "true - passed";
            }
            else {
                return "false - failed";
            }
        }
         
        public IMyObject func_call_sub_functions_class_return_my_object() {
            var _object = sub_Functions.func_params_return_my_object("Samar", "Sous");
            return _object;
        }

        public IEnumerable<MyObject> func_call_sub_functions_class_return_list_my_object() {
            var _listobject = sub_Functions.func_return_List_new_object();
            return _listobject;
        }
        #endregion

        #region "In Memory Unit Tests"
        public bool func_add(MyObjectDataModel obj)
        {
            dbContext.myObjects.Add(obj);
            var result =  dbContext.SaveChanges();
            if (result == 1)
            {
                return true;
            }
            else {
                return false;
            }
        }
        public MyObjectDataModel func_get_by_id(int id)
        {
            var result = dbContext.myObjects.Find(id);
            return result;
        }
        #endregion

    }
}
