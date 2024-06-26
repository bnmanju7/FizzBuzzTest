# Title - FizzBuzz
## Description 
   Program to get Result of multiples of 3 print “Fizz” instead of the number and for the multiples of 5 print “Buzz”. For numbers which are multiples of both 3 and 5 print “FizzBuzz”
## Architecture
  Application  is built in Web Api using C# language, It is designed and Developed with using SOLID principles and application has implement with Dependency Injection  in Controller, so its easy to modify if any changes. The application has its features of factory designed pattern makes feasibility and code consistence. 
  About the Application has input and output result in the bases of Action filters. In the program.cs all the services ahs been Registered and executed.
  FizzBuzz has input parameters in Array of string and Output result will be in List of Strings.
  Fizzbuzz controller receive the inputs from get method and pass the inputs using dependency injection interface to execute and return the Response.
  To execute Fizzbuzz implemented Swagger to pass request and get response based on input params.
## How to Run the Application
  To run locally use to open Application files in Visual studio 2022 and run locally using swagger service.
  Pass the inputs in an array of string. and click execute to get the response. 
            Sample input and output details
                  Input 	                              Result 
                  1 	                                    Divided 1 by 3 / Divided 1 by 5 	                                                      
                  3                                     	Fizz 
                  5                                     	Buzz 
                  <empty>                               	Invalid Item 
                  15                                  	FizzBuzz 
                  A                                     	Invalid item 
                  23                                  	Divided 23 by 3 	Divided 23 by 5 
##  Included Test cases
    To implement this program before we need to write the test cases and make the code functionality simple and feasibility.
    In Application to write unit test case we used Xunit packages to mock and execute the different use cases .
    In fizzbuzzy there is 4 test cases to test the inputs and retur response.

## Concludes
   FizzBuzzy program makes easy to understand and implemented in with latest design patterns and easy to test and execute application.
