module TimeUnitTests

open Microsoft.VisualStudio.TestTools.UnitTesting;
open System
open BerlinClock.Classes

[<TestClass>]
type TimeUnitTests() = 
    
    [<TestMethod; ExpectedException(typeof<ArgumentException>)>]
    member this.``is time exception thrown when hour is negative``() = 
        //arrange
        let time = "-10:00:00"

        //act
        let parsedTime = Time.Parse(time)

        //assert
        Assert.IsNull(parsedTime)


    [<TestMethod; ExpectedException(typeof<ArgumentException>)>]
    member this.``is time exception thrown when hour is not integer``() = 
        //arrange
        let time = "a:0:00"

        //act
        let parsedTime = Time.Parse(time)

        //assert
        Assert.IsNull(parsedTime)


    [<TestMethod; ExpectedException(typeof<ArgumentException>)>]
    member this.``is time exception thrown when hour is greater than 24``() = 
        //arrange
        let time = "26:0:00"

        //act
        let parsedTime = Time.Parse(time)

        //assert
        Assert.IsNull(parsedTime)


    [<TestMethod; ExpectedException(typeof<ArgumentException>)>]
    member this.``is time exception thrown when minute is negative``() = 
        //arrange
        let time = "10:-20:00"

        //act
        let parsedTime = Time.Parse(time)

        //assert
        Assert.IsNull(parsedTime)


    [<TestMethod; ExpectedException(typeof<ArgumentException>)>]
    member this.``is time exception thrown when minute is not integer``() = 
        //arrange
        let time = "10:z:00"

        //act
        let parsedTime = Time.Parse(time)

        //assert
        Assert.IsNull(parsedTime)


    [<TestMethod; ExpectedException(typeof<ArgumentException>)>]
    member this.``is time exception thrown when minute is greater than 59``() = 
        //arrange
        let time = "10:71:00"

        //act
        let parsedTime = Time.Parse(time)

        //assert
        Assert.IsNull(parsedTime)

    [<TestMethod; ExpectedException(typeof<ArgumentException>)>]
    member this.``is time exception thrown when second is negative``() = 
        //arrange
        let time = "10:20:-20"

        //act
        let parsedTime = Time.Parse(time)

        //assert
        Assert.IsNull(parsedTime)


    [<TestMethod; ExpectedException(typeof<ArgumentException>)>]
    member this.``is time exception thrown when second is not integer``() = 
        //arrange
        let time = "10:20:z"

        //act
        let parsedTime = Time.Parse(time)

        //assert
        Assert.IsNull(parsedTime)

    [<TestMethod; ExpectedException(typeof<ArgumentException>)>]
    member this.``is time exception thrown when second is greater than 59``() = 
        //arrange
        let time = "10:20:71"

        //act
        let parsedTime = Time.Parse(time)

        //assert
        Assert.IsNull(parsedTime)


    [<TestMethod; ExpectedException(typeof<ArgumentException>)>]
    member this.``is time exception thrown when total time is greater than 24:0:0``() = 
        //arrange
        let time = "24:00:01"

        //act
        let parsedTime = Time.Parse(time)

        //assert
        Assert.IsNull(parsedTime)


    [<TestMethod; ExpectedException(typeof<ArgumentException>)>]
    member this.``is time exception thrown when unexpected format provided``() = 
        //arrange
        let time = "24:00"

        //act
        let parsedTime = Time.Parse(time)

        //assert
        Assert.IsNull(parsedTime)


    [<TestMethod>]
    member this.``is time 23:59:59 properly parsed``() = 
        //arrange
        let time = "23:59:59"
        
        //act
        let parsedTime = Time.Parse(time)

        //assert
        Assert.AreEqual(23, parsedTime.Hour)
        Assert.AreEqual(59, parsedTime.Minute)
        Assert.AreEqual(59, parsedTime.Second)
        

    [<TestMethod>]
    member this.``is time 0:0:0 properly parsed``() = 
        //arrange
        let time = "0:0:0"

        //act
        let parsedTime = Time.Parse(time)

        //assert
        Assert.AreEqual(0, parsedTime.Hour)
        Assert.AreEqual(0, parsedTime.Minute)
        Assert.AreEqual(0, parsedTime.Second)

    [<TestMethod>]
    member this.``is time 0:01:0 properly parsed``() = 
        //arrange
        let time = "0:01:0"

        //act
        let parsedTime = Time.Parse(time)

        //assert
        Assert.AreEqual(0, parsedTime.Hour)
        Assert.AreEqual(1, parsedTime.Minute)
        Assert.AreEqual(0, parsedTime.Second)


    [<TestMethod>]
    member this.``is time 14:01:59 properly parsed``() = 
        //arrange
        let time = "14:01:59"

        //act
        let parsedTime = Time.Parse(time)

        //assert
        Assert.AreEqual(14, parsedTime.Hour)
        Assert.AreEqual(1, parsedTime.Minute)
        Assert.AreEqual(59, parsedTime.Second)
