# Api.SequenceCalculator

This is the API which actually responds to the web.

To Run the App : 

IIS Express : Press F5 to run the application. On the browser, enter the following URL which will invoke the API.
localhost:52244/v1/sequence/3

Run the Web Application (https://github.com/maheshpatel/SequenceCalculator) by doing "ng serve" on your local machine from the path where the web project has been cloned.

Project Details: 

I have tried to use Strategy Pattern for the WebAPI logic. Due to this if we have a new requirement in the future to add one more type of sequence number calculation it will be easy to add. I believe thus we also adhere to the Open Closed Principle in SOLID principles.

There is lot more that can be done with the project, but due to limited scope, I am listing them.

1. Basic Authentication - Using OWIN Middleware we can also have a middleware which will check for basic authentication.
2. CSRF/AntiForgery token implementation between Angular Web project and API using OWIN middleware
3. Wrapping the responses in API in a special class which also has validation errors sent to the front-end.
4. On the UI - we can have extensive logic to handle Http StatusCodes and display suitable error messages. Currently it doesn't show any error messages if the WebAPI throws Http errors (BadRequest, InternalServer).
