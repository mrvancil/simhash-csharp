simhash-csharp
=================
This is a C# port of a very clear and concise simhash implementation in python 
(also on github at https://github.com/liangsun/simhash).  I have ported most all 
of the tests as well, adding a couple of other along the way. The port is pretty 
close but I have diverged from the overloading of the class and implemented methods
for calculation because I prefer this approach.

## Getting Started 

This project was written using Visual Studio 2015. ~~In keeping with the *clean* implementation
there are no other external dependencies to build.~~  There is an external (nuget) dependency 
on hashing algorithms, System.Data.HashFunction.Core, System.Data.HashFunction.Interfaces,
and System.Data.HashFunction.Jenkins .  Jenkins, MurMur and FNV seem to be the most popular
for hashing the feature set.  The default in this library is Jenkins (you can specify bit length
of 64) but there is also an MD5 implementation (not recommended due to BigInteger messypants).

## Issues

Currently there are no known issues.  

## Performance Optimization

Since some of the types from python to C# not are exactly the same (HoneyBadger don't care
you got a huge number!) there might be some speed loss/improvements depending on how
I implemented the native types in C#.

With Jenkins as the hashing algorithm, it takes roughly 2 minutes (on a smallish laptop)
to generate fingerprints for 11,000 full text articles.

With the MD5 as the hashing algorithm, it takes roughly 18 minutes (on a smallish laptop)
to generate fingerprints for 11,000 full text articles.

It takes roughly 15 seconds to calculate the hamming distance for all the articles against
those 11,000 fingerprints (still on the smallish laptop).  

## Database Backends

Work is currenly underway to implement multiple backend providers with this code.  This will
mimic the concepts around another popular simhash library (https://github.com/seomoz/simhash-db-py).

## Future Work

Database backends (Redis, HBase, Sql, Mongo)
Nuget Submission
Interfaces
Alternate Hashing Functions
More test coverage
Ensure the Converters are up-to-snuff.





    



