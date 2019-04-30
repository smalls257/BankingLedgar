This small console application was built with simplicity in mind. I want to note that due to the limited scope
of this application, there would need to be some changes on the implementation for additional features. This
application can be started just like any other console app. Upon starting a help menu is displayed with 
commands. 

The Program.cs file was designed to hold the "cache" of bank accounts and parsing the input. Actual functionality
of modifying accounts was done in BankAccount.cs. Finally, the cache is designed to act as a storage for all 
bank accounts and keep track of the currently logged in account.