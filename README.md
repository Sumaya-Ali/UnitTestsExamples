# UnitTestsExamples   
UnitTests/Fluent Assertions/ Mocking using FakeItEasy/ InMemory/ DBContext (code first) for Console Application   
There are three types of testing: (Unit tests (do not hit the DB)/ Integration tests (hit the DB)/ end-t-end test ( ex: selenium)   
There are three types of unit tests (same concept, different syntax): MsTest/ NUnit/ XUnit   
In this project, I have used XUnit   
All UnitTests are public void functions and contain the following sections:    
Arrange ==> to collect necessary data and objects    
Act ==> to call the tested functions    
Assert ==> to evaluate the result    
====================================================
Fluent Assertions is not necessary, we can use the build-in Assert in dot net, but it makes the world easier   
====================================================
we use mocking to fake API & objects (in & out) because we want to test one level (ex: the controller class) and not to go in-depth in details and function calls.   
We fake the external dependencies of the constructer of the tested class, the called functions in the tested method, and the object/ list parameters that we pass to the tested
method and the return object/ list after calling the tested method.    
we specify that this object /class /function does not create it and go into detail however return this faked object/ class/ function instead of it.    
## important note: FakeItEasy fake just interfaces and you have to modify code to work with that!!    
there are three common libraries for mocking: Mock/ FakeItEasy/ NSubstitute (same concept, different syntax)    
In this project, I have used FakeItEasy   
===================================================
UnitTest must not modify DB, that is why we use (in Memory package) to do operations on virtual memory   
===================================================
