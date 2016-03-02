module BerlinClockModelTests

open NUnit.Framework
open System
open BerlinClock.Classes

[<Test>]
let ``has berlin clock second light off at 23:59:59``() = 
    //arrange
    let time = new Time(23, 59, 59);

    //act
    let clock = new BerlinClockModel(time);

    //assert
    Assert.That(clock.OnSecondLight, Is.False);

[<Test>]
let ``has berlin clock second light on at 23:59:58``() = 
    //arrange
    let time = new Time(23, 59, 59);

    //act
    let clock = new BerlinClockModel(time);

    //assert
    Assert.That(clock.OnSecondLight, Is.False);

[<Test>]
let ``has berlin clock 4 and 3 hour lights on at 23:59:59``() = 
    //arrange
    let time = new Time(23, 59, 59);

    //act
    let clock = new BerlinClockModel(time);

    //assert
    Assert.That(clock.OnHourFirstRowLights, Is.EqualTo(4));
    Assert.That(clock.OffHourFirstRowLights, Is.EqualTo(0));
    Assert.That(clock.OnHourSecondRowLights, Is.EqualTo(3));
    Assert.That(clock.OffHourSecondRowLights, Is.EqualTo(1));

[<Test>]
let ``has berlin clock 2 and 1 hour lights on at 12:31:59``() = 
    //arrange
    let time = new Time(12, 31, 59);

    //act
    let clock = new BerlinClockModel(time);

    //assert
    Assert.That(clock.OnHourFirstRowLights, Is.EqualTo(2));
    Assert.That(clock.OffHourFirstRowLights, Is.EqualTo(2));
    Assert.That(clock.OnHourSecondRowLights, Is.EqualTo(2));
    Assert.That(clock.OffHourSecondRowLights, Is.EqualTo(2));

[<Test>]
let ``has berlin clock 4 and 4 minutes lights on at 10:24:59``() = 
    //arrange
    let time = new Time(10, 24, 59);

    //act
    let clock = new BerlinClockModel(time);

    //assert
    Assert.That(clock.OnMinutesFirstRowLights, Is.EqualTo(4));
    Assert.That(clock.OffMinutesFirstRowLights, Is.EqualTo(7));
    Assert.That(clock.OnMinutesSecondRowLights, Is.EqualTo(4));
    Assert.That(clock.OffMinutesSecondRowLights, Is.EqualTo(0));

[<Test>]
let ``has berlin clock 0 and 0 minutes lights on at 10:00:00``() = 
    //arrange
    let time = new Time(10, 0, 0);

    //act
    let clock = new BerlinClockModel(time);

    //assert
    Assert.That(clock.OnMinutesFirstRowLights, Is.EqualTo(0));
    Assert.That(clock.OffMinutesFirstRowLights, Is.EqualTo(11));
    Assert.That(clock.OnMinutesSecondRowLights, Is.EqualTo(0));
    Assert.That(clock.OffMinutesSecondRowLights, Is.EqualTo(4));
