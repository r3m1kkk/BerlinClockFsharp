module TimeUnitTests

open Microsoft.VisualStudio.TestTools.UnitTesting;
open BerlinClock.Classes

[<TestClass>]
type TimeUnitTests() = 
    
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