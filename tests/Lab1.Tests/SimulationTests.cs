using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class SimulationTests
{
    [Fact]
    public void Train_has_too_more_power()
    {
        Train train = new(500, 100, 3, 10000);
        MagneticPath mpath = new(2000, 200);
        Simulation calc = new();

        calc.Calculator(train, mpath);

        string message = calc.ResultSimulation.MakeResult();

        Assert.False(calc.ResultSimulation.IsSuccessfully);
        Assert.Equal("Fail!", message);
    }

    [Fact]
    public void Train_has_more_speed_than_station_limit()
    {
        Train train = new(500, 10000, 3, 10000);
        MagneticPath mpath = new(3000, 300);
        Station station = new(10, 100);
        Simulation calc = new();

        calc.Calculator(train, mpath, station);

        string message = calc.ResultSimulation.MakeResult();

        Assert.False(calc.ResultSimulation.IsSuccessfully);
        Assert.Equal("Fail!", message);
    }

    [Fact]
    public void Train_has_more_speed_than_limit_route()
    {
        Train train = new(500, 5000, 3, 40);
        MagneticPath mpath = new(3000, 4000);
        Simulation calc = new();

        calc.Calculator(train, mpath);

        string message = calc.ResultSimulation.MakeResult();

        Assert.False(calc.ResultSimulation.IsSuccessfully);
        Assert.Equal("Fail!", message);
    }

    [Fact]
    public void Train_has_normal_speed_and_normal_way()
    {
        Train train = new(400, 1000, 5, 450);
        MagneticPath mpath = new(1000, 10);
        RailPath path = new(5000);
        Simulation calc = new();

        calc.Calculator(train, mpath, path);

        Assert.True(calc.ResultSimulation.IsSuccessfully);
        Assert.Equal(700, calc.ResultSimulation.TimeTrain.Seconds);
    }

    [Fact]
    public void Normal_speed_fromMpath_path_station_path()
    {
        Train train = new(600, 2000, 3, 300);
        MagneticPath mpath = new(600, 20);
        RailPath path = new(3000);
        Station station = new(300, 50);
        RailPath path2 = new(1000);
        Simulation calc = new();

        calc.Calculator(train, mpath, path, station, path2);

        Assert.True(calc.ResultSimulation.IsSuccessfully);
        Assert.Equal(588.33, calc.ResultSimulation.TimeTrain.Seconds);
    }

    [Fact]
    public void Unnormal_speed_fromMpath_path_MpathLow_station_path_MpathHigh_path_MpathLow()
    {
        Train train = new(600, 2000, 3, 75);
        MagneticPath mpath = new(600, 150);
        RailPath path = new(1000);
        MagneticPath mpath2 = new(600, -150);
        Station station = new(75, 50);
        RailPath path2 = new(2000);
        MagneticPath mpath3 = new(600, 250);
        RailPath path3 = new(1000);
        MagneticPath mpath4 = new(600, -250);
        Simulation calc = new();

        calc.Calculator(train, mpath, path, mpath2, station, path2, mpath3, path3, mpath4);

        Assert.True(calc.ResultSimulation.IsSuccessfully);
        Assert.Equal(330.33, calc.ResultSimulation.TimeTrain.Seconds);
    }

    [Fact]
    public void Train_without_boost()
    {
        Train train = new(500, 1000, 3, 75);
        RailPath path = new(2000);
        Simulation calc = new();

        calc.Calculator(train, path);

        Assert.False(calc.ResultSimulation.IsSuccessfully);
    }

    [Fact]
    public void Train_go_back()
    {
        Train train = new(500, 1000, 3, 75);
        MagneticPath mpath1 = new(1000, 10);
        MagneticPath mpath2 = new(1000, -20);
        Simulation calc = new();

        calc.Calculator(train, mpath1, mpath2);

        Assert.False(calc.ResultSimulation.IsSuccessfully);
    }
}