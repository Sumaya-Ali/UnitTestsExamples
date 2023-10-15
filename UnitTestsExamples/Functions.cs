using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestsExamples
{
    public class MyObject {
        public string fname;
        public string lname;
    }

    public class Sub_Functions {
        public bool func_return_bool() {
            return false;
        }

        public MyObject func_params_return_my_object(string fname,string lname) {
            return new MyObject()
            {
                fname = fname,
                lname = lname
            };
        }

        public List<MyObject> func_return_List_new_object() {
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

    public class Functions
    {
        private readonly Sub_Functions sub_Functions;
        public Functions(Sub_Functions sub_Functions)
        {
            this.sub_Functions = sub_Functions;
        }
        public string func_return_string(int num) {
            if (num == 0)
            {
                return "Syrien";
            }
            else {
                return "Deutschland";
            }
        }

        public string func_without_params_return_string() {
            return "Palestine";
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
         
        public MyObject func_call_sub_functions_class_return_my_object() {
            var _object = sub_Functions.func_params_return_my_object("Samar", "Sous");
            return _object;
        }

        public List<MyObject> func_call_sub_functions_class_return_list_my_object() {
            var _listobject = sub_Functions.func_return_List_new_object();
            return _listobject;
        }
    }
}
