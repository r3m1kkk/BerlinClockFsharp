module TimeUnitTests

open NUnit.Framework
open System
open BerlinClock.Classes

[<Test>]
let ``is time exception thrown when total time is greater than 24:0:0``() = 
    //arrange
    let time = "24:00:01"

    //assert
    Assert.That((fun () -> Time.Parse(time) |> ignore), Throws.ArgumentException)


[<Test>]
let ``is time exception thrown when unexpected format provided``() = 
    //arrange
    let time = "24:00"

    //assert
    Assert.That((fun () -> Time.Parse(time) |> ignore), Throws.ArgumentException)


[<TestCase("a:0:00")>]
[<TestCase("10:z:00")>]
[<TestCase("10:20:z")>]
let ``is time exception thrown when hour is not integer``(time) = 
    //assert
    Assert.That((fun () -> Time.Parse(time) |> ignore), Throws.ArgumentException)


[<TestCase("-10:00:00")>]
[<TestCase("10:-20:00")>]
[<TestCase("10:20:-20")>]
let ``is time exception thrown when segment is negative``(time) = 
    //assert
    Assert.That((fun () -> Time.Parse(time) |> ignore), Throws.ArgumentException)


[<TestCase("26:0:00")>]
[<TestCase("10:71:00")>]
[<TestCase("10:20:71")>]
let ``is time exception thrown when segment is greater than maximum``(time) = 
    //assert
    Assert.That((fun () -> Time.Parse(time) |> ignore), Throws.ArgumentException)


[<TestCase("14:01:59", 14, 1, 59)>]
[<TestCase("0:01:0", 0, 1, 0)>]
[<TestCase("0:0:0", 0, 0, 0)>]
[<TestCase("23:59:59", 23, 59, 59)>]
let ``is time properly parsed``(time, parsedHour, parsedMinute, parsedSecond) = 
    //act
    let parsedTime = Time.Parse(time)

    //assert
    Assert.That(parsedTime.Hour, Is.EqualTo(parsedHour))
    Assert.That(parsedTime.Minute, Is.EqualTo(parsedMinute))
    Assert.That(parsedTime.Second, Is.EqualTo(parsedSecond))
