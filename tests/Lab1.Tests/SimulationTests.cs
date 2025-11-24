using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObjects;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class SimulationTests
{
    [Fact]
    public void Move_Should_Fail_When_TrainHasTooMuchPower()
    {
        // Arrange
        Train train = new(new(500), new(100), new(3));
        MagneticPath mpath = new(new(2000), new(200));
        Route route = new([mpath], new(1000));

        // Act
        RouteResult result = route.Move(train);

        // Assert
        RouteResult.ErrorRoute error = Assert.IsType<RouteResult.ErrorRoute>(result);
        Assert.Equal("Limit train power", error.LogError);
    }

    [Fact]
    public void Move_Should_Fail_When_TrainSpeedExceedsStationLimit()
    {
        // Arrange
        Train train = new(new(500), new(10000), new(3));
        MagneticPath mpath = new(new(3000), new(30));
        Station station = new(new(10), new(100));
        Route route = new([mpath, station], new(1000));

        // Act
        RouteResult result = route.Move(train);

        // Assert
        RouteResult.ErrorRoute error = Assert.IsType<RouteResult.ErrorRoute>(result);
        Assert.Equal("Limit station speed", error.LogError);
    }

    [Fact]
    public void Move_Should_Fail_When_TrainSpeedExceedsRouteLimit()
    {
        // Arrange
        Train train = new(new(500), new(9000), new(3));
        MagneticPath mpath = new(new(1000), new(200));
        Route route = new([mpath], new(20));

        // Act
        RouteResult result = route.Move(train);

        // Assert
        RouteResult.ErrorRoute error = Assert.IsType<RouteResult.ErrorRoute>(result);
        Assert.Equal("Limit route speed", error.LogError);
    }

    [Fact]
    public void Move_Should_CompleteSuccessfully_When_TrainSpeedAndRouteAreNormal()
    {
        // Arrange
        Train train = new(new(400), new(10000), new(5));
        MagneticPath mpath = new(new(1000), new(10));
        RailPath path = new(new(5000));
        Route route = new([mpath, path], new(400));
        Time expectedTime = new(1285);

        // Act
        RouteResult result = route.Move(train);

        // Assert
        var success = result as RouteResult.SuccessRoute;
        Assert.Equal(expectedTime, success?.Time);
    }

    [Fact]
    public void Move_Should_CompleteSuccessfully_When_TrainSpeedMatchesStationPathRequirements()
    {
        // Arrange
        Train train = new(new(600), new(2000), new(3));
        MagneticPath mpath = new(new(600), new(20));
        RailPath path = new(new(3000));
        Station station = new(new(300), new(50));
        RailPath path2 = new(new(1000));
        Route route = new([mpath, path, station, path2], new(600));
        Time expectedTime = new(1530);

        // Act
        RouteResult result = route.Move(train);

        // Assert
        var success = result as RouteResult.SuccessRoute;
        Assert.Equal(expectedTime, success?.Time);
    }

    [Fact]
    public void Move_Should_HandleSpeedChanges_When_TransitioningThroughMultiplePathTypesWithDifferentLimits()
    {
        // Arrange
        Train train = new(new(600), new(20000), new(3));
        MagneticPath mpath = new(new(600), new(10));
        RailPath path = new(new(500));
        MagneticPath mpath2 = new(new(600), new(-10));
        Station station = new(new(75), new(50));
        RailPath path2 = new(new(200));
        MagneticPath mpath3 = new(new(600), new(25));
        RailPath path3 = new(new(1000));
        MagneticPath mpath4 = new(new(600), new(-25));
        Route route = new([mpath, path, mpath2, station, path2, mpath3, path3, mpath4], new(600));
        Time expectedTime = new(1419);

        // Act
        RouteResult result = route.Move(train);

        // Assert
        var success = result as RouteResult.SuccessRoute;
        Assert.Equal(expectedTime, success?.Time);
    }

    [Fact]
    public void Move_Should_Fail_When_TrainWithoutBoostAttemptsLongRoute()
    {
        // Arrange
        Train train = new(new(500), new(1000), new(3));
        RailPath path = new(new(2000));
        Route route = new([path], new(400));

        // Act
        RouteResult result = route.Move(train);

        // Assert
        RouteResult.ErrorRoute error = Assert.IsType<RouteResult.ErrorRoute>(result);
        Assert.Equal("Boost or speed is equal Zero", error.LogError);
    }

    [Fact]
    public void Move_Should_Fail_When_TrainEncountersReverseMagneticPath()
    {
        // Arrange
        Train train = new(new(500), new(10000), new(3));
        MagneticPath mpath1 = new(new(100), new(10));
        MagneticPath mpath2 = new(new(100), new(-20));
        Route route = new([mpath1, mpath2], new(400));

        // Act
        RouteResult result = route.Move(train);

        // Assert
        RouteResult.ErrorRoute error = Assert.IsType<RouteResult.ErrorRoute>(result);
        Assert.Equal("Speed is negative", error.LogError);
    }
}