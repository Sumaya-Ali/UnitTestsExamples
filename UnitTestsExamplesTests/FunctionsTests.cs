using FakeItEasy;
using FluentAssertions;
using FluentAssertions.Extensions;
using System.Xml.Linq;
using UnitTestsExamples;

namespace UnitTestsExamplesTests;

public class FunctionsTests //: IClassFixture<Functions>
{
    // for more build_in assertion function visit: https://fluentassertions.com/

    #region "Initialization"
    /*
      when we choose to use dependency injection to define the testclass instance and pass it throught testing constructer and not create
     it locally in every single unittest function then we must implement the interface ((: IClassFixture<Functions>))
     and we must be sure that the testingclass (function) constructer does ((NOT)) have any external dependencies
     or we must use Mocking to these dependencies too !!
    In case having external dependencies do not use dependency injection or : IClassFixture<Functions> at All !!
     */
    private readonly Functions functions;
    private readonly ISub_Functions sub_Functions; //Must be Interface because FakeItEasy just faking and mocking interfaces !!
    public FunctionsTests()
    {
        //Dependencies
        sub_Functions = A.Fake<ISub_Functions>();

        //SUT
        functions = new Functions(sub_Functions);
    }
    #endregion


    #region "Normal Unit Tests"

    [Fact]
    public void func_return_string_return_true()
    {
        //Arrange
        int num = 0;
        //    Functions functions = new Functions();
        //Act
        var result = functions.func_return_string(num);
        //Assert
        result.Should().NotBeNullOrWhiteSpace();
        result.Should().Contain("Syrien", Exactly.Once());
        result.Should().Be("Ich mag Syrien");
    }


    [Fact]
    public void func_without_params_return_string_return_Palestine() {
        //Arrange
        //Act
        var result = functions.func_without_params_return_string();
        //Assert
        result.Should().BeUpperCased();
        result.Should().EndWith("INE");
    }
    [Theory]
    [InlineData(3, 5, 8)]
    [InlineData(7, 3, 10)]
    public void func_adding_num_return_int_return_sum(int a, int b, int expected) {
        //Arrange
        //Act
        var result = functions.func_adding_num_return_int(a, b);

        //Assert
        result.Should().Be(expected);
        result.Should().BeLessThanOrEqualTo(10);
        result.Should().NotBeInRange(-10, 0);
    }

    [Fact]
    public void func_return_date_now_return_datetime() {
        //Arrange
        //Act
        var result = functions.func_return_date_now();

        //Assert

        result.Should().BeAfter(11.November(2021));
        result.Should().BeBefore(30.December(2023));
    }

    [Fact]
    public void func_get_my_object_return_object() {
        //Arrange
        MyObject expected = new MyObject {
            fname = "Sumaya",
            lname = "Ali"
        };
        //Act
        var result = functions.func_get_my_object();
        //Assert
        result.Should().BeOfType<MyObject>();
        result.Should().BeEquivalentTo(expected);
        result.fname.Should().Be("Sumaya");
    }

    [Fact]
    public void func_return_list_my_object_return_list()
    {
        //Arrange
        MyObject expected = new MyObject
        {
            fname = "Sarah",
            lname = "Ali"
        };
        //Act
        var result = functions.func_return_list_my_object();
        //Assert
        result.Should().BeOfType<List<MyObject>>();
        result.Should().ContainEquivalentOf(expected);
        result.Should().Contain(x => x.lname == "Ali");
    }
    #endregion

    #region "Mocking Unit Tests"

    [Fact]
    public void func_call_sub_function_class_return_string() {
        //Arrange
        A.CallTo(()=> sub_Functions.func_return_bool()).Returns(true);
        //Act
        var result = functions.func_call_sub_function_class();
        //Assert
        result.Should().Contain("passed");
    }
    [Fact]
    public void func_call_sub_functions_class_return_my_object_return_object() {
        //Arrange
        var myobject = A.Fake<IMyObject>(); // Again Must be Intetface (:
        A.CallTo(()=> sub_Functions.func_params_return_my_object("Samar", "Sous")).Returns(myobject);
        //Act
        var result = functions.func_call_sub_functions_class_return_my_object();
        //Assert
        result.Should().NotBeNull();
    }
    [Fact]
    public void func_call_sub_functions_class_return_list_my_object_return_list() {
        //Arrange
        var listofobjects = A.Fake<IEnumerable<MyObject>>(); // Must be Interface IEnumerable so we can fake it (: 
        A.CallTo(()=> sub_Functions.func_return_List_new_object()).Returns(listofobjects);
        //Act
        var result = functions.func_call_sub_functions_class_return_list_my_object();
        //Assert
        result.Should().NotBeNull();
    }
    #endregion

}