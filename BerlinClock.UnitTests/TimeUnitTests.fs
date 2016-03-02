module TimeUnitTests

open NUnit.Framework
open System
open BerlinClock.Classes

[<Test>]
let ``is time exception thrown when hour is negative``() = 
    //arrange
    let time = "-10:00:00"

    //assert
    Assert.That((fun () -> Time.Parse(time) |> ignore), Throws.ArgumentException)


[<Test>]
let ``is time exception thrown when hour is not integer``() = 
    //arrange
    let time = "a:0:00"

    //assert
    Assert.That((fun () -> Time.Parse(time) |> ignore), Throws.ArgumentException)


[<Test>]
let ``is time exception thrown when hour is greater than 24``() = 
    //arrange
    let time = "26:0:00"

    //assert
    Assert.That((fun () -> Time.Parse(time) |> ignore), Throws.ArgumentException)


[<Test>]
let ``is time exception thrown when minute is negative``() = 
    //arrange
    let time = "10:-20:00"

    //assert
    Assert.That((fun () -> Time.Parse(time) |> ignore), Throws.ArgumentException)


[<Test>]
let ``is time exception thrown when minute is not integer``() = 
    //arrange
    let time = "10:z:00"

    //assert
    Assert.That((fun () -> Time.Parse(time) |> ignore), Throws.ArgumentException)


[<Test>]
let ``is time exception thrown when minute is greater than 59``() = 
    //arrange
    let time = "10:71:00"

    //assert
    Assert.That((fun () -> Time.Parse(time) |> ignore), Throws.ArgumentException)

[<Test>]
let ``is time exception thrown when second is negative``() = 
    //arrange
    let time = "10:20:-20"

    //assert
    Assert.That((fun () -> Time.Parse(time) |> ignore), Throws.ArgumentException)


[<Test>]
let ``is time exception thrown when second is not integer``() = 
    //arrange
    let time = "10:20:z"

    //assert
    Assert.That((fun () -> Time.Parse(time) |> ignore), Throws.ArgumentException)

[<Test>]
let ``is time exception thrown when second is greater than 59``() = 
    //arrange
    let time = "10:20:71"

    //assert
    Assert.That((fun () -> Time.Parse(time) |> ignore), Throws.ArgumentException)


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


[<Test>]
let ``is time 23:59:59 properly parsed``() = 
    //arrange
    let time = "23:59:59"
        
    //act
    let parsedTime = Time.Parse(time)

    //assert
    Assert.That(parsedTime.Hour, Is.EqualTo(23))
    Assert.That(parsedTime.Minute, Is.EqualTo(59))
    Assert.That(parsedTime.Second, Is.EqualTo(59))
        

[<Test>]
let ``is time 0:0:0 properly parsed``() = 
    //arrange
    let time = "0:0:0"

    //act
    let parsedTime = Time.Parse(time)

    //assert
    Assert.That(parsedTime.Hour, Is.EqualTo(0))
    Assert.That(parsedTime.Minute, Is.EqualTo(0))
    Assert.That(parsedTime.Second, Is.EqualTo(0))

[<Test>]
let ``is time 0:01:0 properly parsed``() = 
    //arrange
    let time = "0:01:0"

    //act
    let parsedTime = Time.Parse(time)

    //assert
    Assert.That(parsedTime.Hour, Is.EqualTo(0))
    Assert.That(parsedTime.Minute, Is.EqualTo(1))
    Assert.That(parsedTime.Second, Is.EqualTo(0))


[<Test>]
let ``is time 14:01:59 properly parsed``() = 
    //arrange
    let time = "14:01:59"

    //act
    let parsedTime = Time.Parse(time)

    //assert
    Assert.That(parsedTime.Hour, Is.EqualTo(14))
    Assert.That(parsedTime.Minute, Is.EqualTo(1))
    Assert.That(parsedTime.Second, Is.EqualTo(59))
