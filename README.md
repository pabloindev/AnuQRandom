AnuQRandom
==========

.NET library to query ANU Quantum Random Numbers Server

There are 2 projects in the solution
AnuQRandom: dll
FormTest: Test project for dll

To get the data use the object AQRandJSON
AQRandJSON j = new AQRandJSON();

then call the getBinary method
byte[] b = j.getBinary(DataType.hex16, 1010); //get array of bytes with 1010 elements
to get array of bytes, 

or use getString
string s = j.getString(1010); //get random 1010 characters
to get random string

Another method to get a random string is to use AQRand object that extract the data from the page https://qrng.anu.edu.au/RawChar.php
AQRand r = new AQRand();
string s = r.getString(2000);

The test project use AnuQRandom to get random data and set the text propriety of a textbox