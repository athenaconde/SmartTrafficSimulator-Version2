using STLS.Model;
using STLS.Utilities;
using STLS.View.UserControls;
using STLS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace STLS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView : Window
    {
        private Timer _timer;
        private Test.Trial _currentTrial;
        private readonly TrafficMonitoringViewModel _vm;
        private readonly List<Storyboard> _storyBoards;
        public MainView()
        {
            InitializeComponent();
            _vm = new TrafficMonitoringViewModel();
            this._vm.Start();
            this.DataContext = _vm;
            _storyBoards = new List<Storyboard>();
            this.OnInitialized();
        }

        private void OnInitialized()
        {
            this.Trial1Button.Click += TrialButton_Click;
            this.Trial2Button.Click += TrialButton_Click;
            this.Trial3Button.Click += TrialButton_Click;
            this.StartSimulatorButton.Click += TrialButton_Click;
            this.AddVehicleButton.Click += TrialButton_Click;
        }

        private void TrialButton_Click(object sender, RoutedEventArgs e)
        {
            var button = e.Source as Button;
           if (button != null)
            {
                switch (button.Name)
                {
                    case "Trial1Button":
                        //this._trialList = this._trialViewModel.GetTrial1();
                        this._vm.Trial(1);
                        break;
                    case "Trial2Button":
                        //this._trialList = this._trialViewModel.GetTrial2();
                        this._vm.Trial(2);

                        break;
                    case "Trial3Button":
                        //this._trialList = this._trialViewModel.GetTrial3();
                        this._vm.Trial(3);
                        break;
                    case "StartSimulatorButton":
                        this.Simulator();
                        break;

                    case "AddVehicleButton":
                        this.AddMoreVehicle();
                        break;
                    default:
                        break;
                }
            }
        }

        //private void AddCarToCanvas(Canvas canvas)
        //{
        //    var car = new Car2();
        //    car.Background = Brushes.Blue;
        //    var trigger = (EventTrigger)this.Resources["CarOnMouseOverExampleTrigger"];
        //    car.Triggers.Add(trigger);
        //    canvas.Children.Add(car);
        //}

        private void Animator(Test.RouteEnum routeEnum, FrameworkElement vehicleToAnimate, double animationDuration , Random randomNum)
        {
            switch (routeEnum)
            {
                case Test.RouteEnum.Blue:
                    if (randomNum.Next(1, 5) != 3)
                    {
                        var doubleAnimation = new DoubleAnimation()
                        {
                            //From = Canvas.GetTop(car),
                            To = -50,
                            Duration = new Duration(TimeSpan.FromSeconds(animationDuration))
                        };
                        var doubleAnimation2 = new DoubleAnimation()
                        {
                            //From = Canvas.GetTop(car),
                            To = -1000,
                            BeginTime = TimeSpan.FromSeconds(animationDuration),
                            Duration = new Duration(TimeSpan.FromSeconds(3))
                        };
                        //car.BeginAnimation(Canvas.TopProperty, doubleAnimation);
                        var storyBoard = new Storyboard();
                        storyBoard.Children.Add(doubleAnimation);
                        storyBoard.Children.Add(doubleAnimation2);
                        Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(Canvas.TopProperty));
                        Storyboard.SetTargetProperty(doubleAnimation2, new PropertyPath(Canvas.TopProperty));
                        storyBoard.Begin(vehicleToAnimate, true);
                        _storyBoards.Add(storyBoard);
                    }
                    else
                    {
                        //var duration2 = runningDurationInSeconds - (initStaticduration / 2);
                        var firstAnimation = new DoubleAnimation()
                        {
                            //From = Canvas.GetTop(car),
                            To = -50,
                            BeginTime = TimeSpan.FromMilliseconds(0),
                            Duration = new Duration(TimeSpan.FromSeconds(animationDuration))
                        };
                        var rotateAnimation = (DoubleAnimation)this.Resources["AngleRotateTransformAnimationKey"];
                        rotateAnimation.From = 0;
                        rotateAnimation.To = 90;
                        rotateAnimation.BeginTime = TimeSpan.FromSeconds(animationDuration);
                        rotateAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.200));

                        var thirdAnimation = new DoubleAnimation()
                        {
                            From = 12,
                            To = -1000,
                            BeginTime = TimeSpan.FromSeconds(animationDuration),
                            Duration = new Duration(TimeSpan.FromSeconds(3))
                        };
                        var storyboard = new Storyboard();
                        storyboard.Children.Add(firstAnimation);
                        storyboard.Children.Add(rotateAnimation);
                        storyboard.Children.Add(thirdAnimation);
                        Storyboard.SetTargetProperty(firstAnimation, new PropertyPath(Canvas.TopProperty));
                        //Storyboard.SetTargetProperty(rotateAnimation, new PropertyPath(RotateTransform.AngleProperty));
                        Storyboard.SetTargetProperty(thirdAnimation, new PropertyPath(Canvas.RightProperty));
                        storyboard.Begin(vehicleToAnimate, true);
                        _storyBoards.Add(storyboard);
                    }
                    break;
                case Test.RouteEnum.Red:
                    if (randomNum.Next(1, 5) != 3)
                    {
                        var doubleAnimation = new DoubleAnimation()
                        {
                            To = -25,
                            Duration = new Duration(TimeSpan.FromSeconds(animationDuration))
                        };
                        var doubleAnimation2 = new DoubleAnimation()
                        {
                            To = -1000,
                            BeginTime = TimeSpan.FromSeconds(animationDuration),
                            Duration = new Duration(TimeSpan.FromSeconds(3))
                        };
                        //car.BeginAnimation(Canvas.TopProperty, doubleAnimation);
                        var storyBoard = new Storyboard();
                        storyBoard.Children.Add(doubleAnimation);
                        storyBoard.Children.Add(doubleAnimation2);
                        Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(Canvas.RightProperty));
                        Storyboard.SetTargetProperty(doubleAnimation2, new PropertyPath(Canvas.RightProperty));
                        storyBoard.Begin(vehicleToAnimate, true);
                        _storyBoards.Add(storyBoard);
                    }
                    else
                    {
                        //var duration2 = runningDurationInSeconds - (initStaticduration / 2);
                        var firstAnimation = new DoubleAnimation()
                        {
                            //From = Canvas.GetTop(car),
                            To = -50,
                            BeginTime = TimeSpan.FromMilliseconds(0),
                            Duration = new Duration(TimeSpan.FromSeconds(animationDuration))
                        };
                        var rotateAnimation = (DoubleAnimation)this.Resources["AngleRotateTransformAnimationKey"];
                        rotateAnimation.From = 0;
                        rotateAnimation.To = 90;
                        rotateAnimation.BeginTime = TimeSpan.FromSeconds(animationDuration);
                        rotateAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.200));

                        var thirdAnimation = new DoubleAnimation()
                        {
                            From = 12,
                            To = -1000,
                            BeginTime = TimeSpan.FromSeconds(animationDuration),
                            Duration = new Duration(TimeSpan.FromSeconds(3))
                        };
                        var storyboard = new Storyboard();
                        storyboard.Children.Add(firstAnimation);
                        storyboard.Children.Add(rotateAnimation);
                        storyboard.Children.Add(thirdAnimation);
                        Storyboard.SetTargetProperty(firstAnimation, new PropertyPath(Canvas.RightProperty));
                        Storyboard.SetTargetProperty(thirdAnimation, new PropertyPath(Canvas.BottomProperty));
                        storyboard.Begin(vehicleToAnimate, true);
                        _storyBoards.Add(storyboard);
                    }
                    break;
                case Test.RouteEnum.Green:
                    var doubleAnimationG1 = new DoubleAnimation()
                    {
                        // From = Canvas.GetLeft(car),
                        To = -25,
                        Duration = new Duration(TimeSpan.FromSeconds(animationDuration))
                    };

                    var doubleAnimationG2 = new DoubleAnimation()
                    {
                        //From = Canvas.GetLeft(car),
                        To = -1000,
                        BeginTime = TimeSpan.FromSeconds(animationDuration),
                        Duration = new Duration(TimeSpan.FromSeconds(3))
                    };

                    var storyBoardG = new Storyboard();
                    storyBoardG.Children.Add(doubleAnimationG1);
                    storyBoardG.Children.Add(doubleAnimationG2);

                    Storyboard.SetTargetProperty(doubleAnimationG1, new PropertyPath(Canvas.LeftProperty));
                    Storyboard.SetTargetProperty(doubleAnimationG2, new PropertyPath(Canvas.LeftProperty));
                    storyBoardG.Begin(vehicleToAnimate);
                    _storyBoards.Add(storyBoardG);

                    break;
                case Test.RouteEnum.Yello:
                    var doubleAnimationY1 = new DoubleAnimation()
                    {
                        //From = Canvas.GetBottom(car),
                        To = -25,
                        Duration = new Duration(TimeSpan.FromSeconds(animationDuration))
                    };
                    var doubleAnimationY2 = new DoubleAnimation()
                    {
                        //From = Canvas.GetLeft(car),
                        To = -1000,
                        BeginTime = TimeSpan.FromSeconds(animationDuration),
                        Duration = new Duration(TimeSpan.FromSeconds(3))
                    };

                    var storyBoardY = new Storyboard();
                    storyBoardY.Children.Add(doubleAnimationY1);
                    storyBoardY.Children.Add(doubleAnimationY2);

                    Storyboard.SetTargetProperty(doubleAnimationY1, new PropertyPath(Canvas.BottomProperty));
                    Storyboard.SetTargetProperty(doubleAnimationY2, new PropertyPath(Canvas.BottomProperty));
                    storyBoardY.Begin(vehicleToAnimate);
                    _storyBoards.Add(storyBoardY);

                    break;
                case Test.RouteEnum.Yellow_left:
                    var firstAnimationYL = new DoubleAnimation()
                    {
                        //From = Canvas.GetBottom(car),
                        To = -25,
                        //BeginTime = TimeSpan.FromMilliseconds(0),
                        Duration = new Duration(TimeSpan.FromSeconds(animationDuration))
                    };

                    var secondAnimationYL = new DoubleAnimation()
                    {
                        To = -100,
                        BeginTime = TimeSpan.FromSeconds(animationDuration),
                        Duration = new Duration(TimeSpan.FromSeconds(0.25))
                    };

                    var rotateAnimationYL1 = (DoubleAnimation)this.Resources["AngleRotateTransformAnimation2Key"];
                    //rotateAnimation1.From = 0;
                    rotateAnimationYL1.To = -90;
                    rotateAnimationYL1.BeginTime = TimeSpan.FromSeconds(animationDuration);
                    rotateAnimationYL1.Duration = new Duration(TimeSpan.FromSeconds(0.50));

                    var thirdAnimationYL = new DoubleAnimation()
                    {
                        // From = 0,
                        To = -1000,
                        BeginTime = TimeSpan.FromSeconds(animationDuration),
                        Duration = new Duration(TimeSpan.FromSeconds(3.5))
                    };



                    /*var rotateAnimation2 = (DoubleAnimation)this.Resources["AngleRotateTransformAnimationKey"];
                    //rotateAnimation2.From = -45;
                    rotateAnimation2.To = -90;
                    rotateAnimation2.BeginTime = TimeSpan.FromSeconds(runningDurationInSeconds + 0.200);
                    rotateAnimation2.Duration = new Duration(TimeSpan.FromSeconds(0.200));*/

                    //var fifthAnimation = new DoubleAnimation()
                    //{
                    //  //  From = 0,
                    //    To = -1000,
                    //    BeginTime = TimeSpan.FromSeconds(runningDurationInSeconds),
                    //    Duration = new Duration(TimeSpan.FromSeconds(3))
                    //};

                    var storyBoardYL = new Storyboard();
                    storyBoardYL.Children.Add(firstAnimationYL);
                    storyBoardYL.Children.Add(secondAnimationYL);
                    storyBoardYL.Children.Add(rotateAnimationYL1);
                    storyBoardYL.Children.Add(thirdAnimationYL);
                    // storyBoard.Children.Add(fourthAnimation);
                    //storyBoard.Children.Add(rotateAnimation2);
                    //storyBoard.Children.Add(fifthAnimation);

                    Storyboard.SetTargetProperty(firstAnimationYL, new PropertyPath(Canvas.BottomProperty));
                    Storyboard.SetTargetProperty(secondAnimationYL, new PropertyPath(Canvas.BottomProperty));
                    Storyboard.SetTargetProperty(thirdAnimationYL, new PropertyPath(Canvas.RightProperty));
                    // Storyboard.SetTargetProperty(fourthAnimation, new PropertyPath(Canvas.BottomProperty));
                    //Storyboard.SetTargetProperty(fifthAnimation, new PropertyPath(Canvas.BottomProperty));

                    storyBoardYL.Begin(vehicleToAnimate);
                    _storyBoards.Add(storyBoardYL);
                    break;
                default:
                    break;
            }
        }
        private void ChangeTrafficLight(object trial)
        {
            this.Dispatcher.Invoke(() =>
            {
                var t = trial as Test.Trial;
                if (t != null)
                {
                    _vm.TrafficLights[0].IsGo = t.Route.Route == Test.RouteEnum.Blue;
                    _vm.TrafficLights[1].IsGo = t.Route.Route == Test.RouteEnum.Green;
                    _vm.TrafficLights[2].IsGo = t.Route.Route == Test.RouteEnum.Red;
                    _vm.TrafficLights[3].IsGo = t.Route.Route == Test.RouteEnum.Yello || t.Route.Route == Test.RouteEnum.Yellow_left;

                    _currentTrial = t;

                    var runningDurationInSeconds = Constants.INIT_DURATION_SECONDS;
                    var randomNum = new Random();
                    _storyBoards.Clear();
                    //var runningDurationInSeconds2 = runningDurationInSeconds * (50/1000);
                    switch (t.Route.Route)
                    {
                        case Test.RouteEnum.Blue:
                            foreach (FrameworkElement car in FromWestRoadCanvas.Children)
                            {
                                Animator(t.Route.Route, car, runningDurationInSeconds, randomNum);
                                runningDurationInSeconds++;
                            }
                            break;
                        case Test.RouteEnum.Red:
                            foreach (FrameworkElement car in FromNorthRoadCanvas.Children)
                            {
                                Animator(t.Route.Route, car, runningDurationInSeconds, randomNum);
                                runningDurationInSeconds++;
                            }

                            break;
                        case Test.RouteEnum.Green:
                            foreach (FrameworkElement car in FromSouthRoadCanvas.Children)
                            {
                                Animator(t.Route.Route, car, runningDurationInSeconds, randomNum);
                                runningDurationInSeconds++;
                            }
                            break;
                        case Test.RouteEnum.Yello:
                            foreach (FrameworkElement car in FromEastRoadCanvas.Children)
                            {
                                Animator(t.Route.Route, car, runningDurationInSeconds, randomNum);
                                runningDurationInSeconds++;
                            }

                            foreach (FrameworkElement car in FromEastRoadCanvas2.Children)
                            {
                                Animator(t.Route.Route, car, runningDurationInSeconds, randomNum);
                                runningDurationInSeconds++;
                            }
                            break;
                        //case Test.RouteEnum.Yellow_left:
                        //    foreach (FrameworkElement car in FromEastRoadCanvas2.Children)
                        //    {
                        //        Animator(t.Route.Route, car, runningDurationInSeconds, randomNum);
                        //        runningDurationInSeconds++;
                        //    }
                        //    break;
                        default:
                            break;
                    }
                    //GoSignalTimer(t);
                    // _timer.Dispose();
                    if (_vm.SmartTrafficActivated)
                        _timer = new Timer(WarningToStopTrafficLight, t, 1000, Timeout.Infinite);
                    else
                        _timer = new Timer(WarningToStopTrafficLight, t, (t.Route.GoTicksInSeconds) * 1000, Timeout.Infinite);
                }
            });
        }

        private  void WarningToStopTrafficLight(object obj)
        {
                this.Dispatcher.Invoke(() =>
                {
                    var t = obj as Test.Trial;
                    if (t != null)
                    {
                        if (_vm.SmartTrafficActivated)
                        {
                            switch (t.Route.Route)
                            {
                                case Test.RouteEnum.Blue:
                                    if (_vm.TrafficLights[0].IsGo)
                                    {
                                        if (SmartTrafficSensor(FromWestRoadCanvas, Canvas.TopProperty))
                                        {
                                                _timer = new Timer(WarningToStopTrafficLight, t, 1000, Timeout.Infinite);
                                                return;
                                        }
                                    }
                                    break;
                                case Test.RouteEnum.Red:
                                    if (_vm.TrafficLights[2].IsGo)
                                    {
                                        if (SmartTrafficSensor(FromNorthRoadCanvas, Canvas.RightProperty))
                                        {
                                            _timer = new Timer(WarningToStopTrafficLight, t, 1000, Timeout.Infinite);
                                            return;
                                        }
                                    }
                                    break;
                                case Test.RouteEnum.Green:
                                    if (_vm.TrafficLights[1].IsGo)
                                    {
                                        if (SmartTrafficSensor(FromSouthRoadCanvas, Canvas.LeftProperty))
                                        {
                                            _timer = new Timer(WarningToStopTrafficLight, t, 1000, Timeout.Infinite);
                                            return;
                                        }
                                    }
                                    break;
                                case Test.RouteEnum.Yello:
                                    if (_vm.TrafficLights[3].IsGo)
                                    {
                                        if (SmartTrafficSensor(FromEastRoadCanvas, Canvas.BottomProperty))
                                        {
                                            _timer = new Timer(WarningToStopTrafficLight, t, 1000, Timeout.Infinite);
                                            return;
                                        }
                                    }
                                    break;
                                case Test.RouteEnum.Yellow_left:
                                    if (_vm.TrafficLights[3].IsGo)
                                    {
                                        if (SmartTrafficSensor(FromEastRoadCanvas2, Canvas.BottomProperty))
                                        {
                                            _timer = new Timer(WarningToStopTrafficLight, t, 1000, Timeout.Infinite);
                                            return;
                                        }
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }

                        _vm.TrafficLights[0].IsWarning = t.Route.Route == Test.RouteEnum.Blue;
                        _vm.TrafficLights[1].IsWarning = t.Route.Route == Test.RouteEnum.Green;
                        _vm.TrafficLights[2].IsWarning = t.Route.Route == Test.RouteEnum.Red;
                        _vm.TrafficLights[3].IsWarning = t.Route.Route == Test.RouteEnum.Yello || t.Route.Route == Test.RouteEnum.Yellow_left;


                    //  _timer.Dispose();
                    _timer = new Timer(DelayAfterStopBeforeSettingGoTheOTher, t, 3 * 1000, Timeout.Infinite);
                    }
                });
        }

        private void DelayAfterStopBeforeSettingGoTheOTher(object obj)
        {
            this.Dispatcher.Invoke(() =>
            {
                var t = obj as Test.Trial;
                if (t != null)
                {
                    var carIndex = 0;
                    var nextStopingPoint = 0.0;
                    switch (t.Route.Route)
                    {
                        case Test.RouteEnum.Blue:
                            foreach (FrameworkElement car in FromWestRoadCanvas.Children)
                            {
                                if (Canvas.GetTop(car) >= 0)
                                {
                                  
                                    var storyboard = _storyBoards[carIndex];
                                    storyboard.Pause(car);
                                    var doubleAnimation = new DoubleAnimation()
                                    {
                                        //From = Canvas.GetTop(car),
                                        To = nextStopingPoint,
                                        Duration = new Duration(TimeSpan.FromSeconds(1))
                                    };
                                    car.ApplyAnimationClock(Canvas.TopProperty, doubleAnimation.CreateClock());
                                    nextStopingPoint = nextStopingPoint + car.ActualHeight + car.ActualHeight / 2;
                                }
                                carIndex++;
                            }
                            break;
                        case Test.RouteEnum.Red:
                            foreach (FrameworkElement car in FromNorthRoadCanvas.Children)
                            {
                                if (Canvas.GetRight(car) >= 0)
                                {
                                    var storyBoard = _storyBoards[carIndex];
                                    storyBoard.Pause(car);

                                        var doubleAnimation = new DoubleAnimation()
                                        {
                                            To = nextStopingPoint,
                                            Duration = new Duration(TimeSpan.FromSeconds(1))
                                        };
                                    car.ApplyAnimationClock(Canvas.RightProperty, doubleAnimation.CreateClock());
                                    nextStopingPoint = nextStopingPoint + car.ActualWidth + car.ActualWidth / 2;
                                }
                                carIndex++;
                            }

                            break;
                        case Test.RouteEnum.Green:
                            foreach (FrameworkElement car in FromSouthRoadCanvas.Children)
                            {
                                if (Canvas.GetLeft(car) >= 0)
                                {
                                    var storyBoard = _storyBoards[carIndex];
                                    storyBoard.Pause(car);

                                    var doubleAnimation = new DoubleAnimation()
                                    {
                                       // From = Canvas.GetLeft(car),
                                        To = nextStopingPoint,
                                        Duration = new Duration(TimeSpan.FromSeconds(1))
                                    };
                                    car.ApplyAnimationClock(Canvas.LeftProperty, doubleAnimation.CreateClock());
                                    nextStopingPoint = nextStopingPoint + car.ActualWidth + car.ActualWidth / 2;
                                }
                            }
                            break;
                        case Test.RouteEnum.Yello:
                            foreach (FrameworkElement car in FromEastRoadCanvas.Children)
                            {
                                if (Canvas.GetBottom(car) >= 0)
                                {
                                    var storyBoard = _storyBoards[carIndex];
                                    storyBoard.Pause(car);

                                    var doubleAnimation = new DoubleAnimation()
                                    {
                                       // From = Canvas.GetBottom(car),
                                        To = nextStopingPoint,
                                        Duration = new Duration(TimeSpan.FromSeconds(1))
                                    };
                                    car.ApplyAnimationClock(Canvas.BottomProperty, doubleAnimation.CreateClock());
                                    nextStopingPoint = nextStopingPoint + car.ActualHeight + car.ActualHeight / 2;
                                }
                            }
                            break;
                        case Test.RouteEnum.Yellow_left:
                            foreach (FrameworkElement car in FromEastRoadCanvas2.Children)
                            {
                                if (Canvas.GetBottom(car) >= 0)
                                {
                                    var storyBoard = _storyBoards[carIndex];
                                    storyBoard.Pause(car);
                                    var doubleAnimation = new DoubleAnimation()
                                    {
                                      //  From = Canvas.GetBottom(car),
                                        To = nextStopingPoint,
                                        Duration = new Duration(TimeSpan.FromSeconds(1))
                                    };
                                    car.ApplyAnimationClock(Canvas.BottomProperty, doubleAnimation.CreateClock());
                                    nextStopingPoint = nextStopingPoint + car.ActualHeight + car.ActualHeight / 2;
                                }
                                carIndex++;
                            }
                            break;
                        default:
                            break;
                    }
                    foreach (var tf in _vm.TrafficLights)
                    {
                       tf.IsStop = true;
                    }
                    //Set net route to Go;
                    var ix = this._vm.SimulatorTrials.IndexOf(t);
                    if (ix < this._vm.SimulatorTrials.Count - 1)
                    {
                        var nextRoute = this._vm.SimulatorTrials[ix + 1];
                        //  _timer.Dispose();
                        _timer = new Timer(ChangeTrafficLight, nextRoute, 2 * 1000, Timeout.Infinite);
                    }
                }
            });
        }

        private void Simulator()
        {
            if (_timer != null)
            {
                _timer.Dispose();
                _timer = null;
            }
            if (_vm.SimulatorTrials == null) return;
            //_trialList = _trialViewModel.GetTrial1();
            Task.Run(() =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    this.FromEastRoadCanvas.Children.Clear();
                    this.FromNorthRoadCanvas.Children.Clear();
                    this.FromSouthRoadCanvas.Children.Clear();
                    this.FromWestRoadCanvas.Children.Clear();
                    this.FromEastRoadCanvas2.Children.Clear();

                    foreach (var trial in _vm.SimulatorTrials)
                    {
                        var left = 0.0;
                        var right = 0.0;
                        var top = 0.0;
                        var bottom = 0.0;
                        for (int i = 0; i < trial.NumberOfVehicle; i++)
                        {

                            switch (trial.Route.Route)
                            {
                                case Test.RouteEnum.Blue:
                                    var carBlue = new Car1() { Background = Brushes.Blue, Height = 50, Width = 24};
                                    Canvas.SetTop(carBlue, top);
                                    Canvas.SetRight(carBlue, 12);
                                    var transform = new RotateTransform(0, 0, 0);
                                    carBlue.RenderTransformOrigin = new Point(0, 0);
                                    carBlue.RenderTransform = transform;
                                    FromWestRoadCanvas.Children.Add(carBlue);
                                    top = top + carBlue.Height + carBlue.Height / 2;
                                    break;
                                case Test.RouteEnum.Red:
                                    var carRed = new Car2() { Background = Brushes.Red , Height = 24, Width = 50};
                                    Canvas.SetRight(carRed, right);
                                    Canvas.SetBottom(carRed, 12);
                                    var transformRed = new RotateTransform(0, 0, 0);
                                    carRed.RenderTransformOrigin = new Point(0.5, 0.5);
                                    carRed.RenderTransform = transformRed;
                                    FromNorthRoadCanvas.Children.Add(carRed);
                                    right = right + carRed.Width + carRed.Width / 2;
                                    break;
                                case Test.RouteEnum.Green:
                                    var carGreen = new Car2() { Background = Brushes.Green , Height = 24, Width = 50};
                                    Canvas.SetLeft(carGreen, left);
                                    Canvas.SetTop(carGreen, 12);
                                    FromSouthRoadCanvas.Children.Add(carGreen);
                                    left = left + carGreen.Width + carGreen.Width / 2;
                                    break;
                                case Test.RouteEnum.Yello:
                                    var carYellow = new Car1() { Background = Brushes.Yellow, Height = 50, Width = 24};
                                    Canvas.SetBottom(carYellow, bottom);
                                    //Canvas.SetLeft(carYellow, 12);
                                    FromEastRoadCanvas.Children.Add(carYellow);
                                    bottom = bottom + carYellow.Height + carYellow.Height / 2;
                                    break;
                                case Test.RouteEnum.Yellow_left:
                                    var carYL = new Car1() { Background = Brushes.Yellow, Height = 50, Width = 24};
                                    Canvas.SetBottom(carYL, bottom);
                                    Canvas.SetRight(carYL, 0);
                                    carYL.RenderTransformOrigin = new Point(0.5, 0.5);
                                    var transformYL = new RotateTransform(0,0,0);
                                    carYL.RenderTransform = transformYL;
                                    FromEastRoadCanvas2.Children.Add(carYL);
                                    bottom = bottom + carYL.Height + carYL.Height / 2;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                });
            }); 
            _timer = new Timer(ChangeTrafficLight, this._vm.SimulatorTrials.First(), 0, Timeout.Infinite);
        }

        private void AddMoreVehicle()
        {
            Task.Run(() =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    if (_vm.TrafficLights == null)
                        return;

                    var currentTrafficFlow = _vm.TrafficLights.Where(t => t.IsGo == true).FirstOrDefault();
                    if (currentTrafficFlow != null)
                    {
                        if (_currentTrial != null)
                        {
                            var initAnimationDuration = Constants.INIT_DURATION_SECONDS;
                            switch (_currentTrial.Route.Route)
                            {
                                case Test.RouteEnum.Blue:
                                    var lastCarB = FromWestRoadCanvas.Children[FromWestRoadCanvas.Children.Count - 1] as FrameworkElement;
                                    var top = FromWestRoadCanvas.ActualHeight;
                                    if (Canvas.GetTop(lastCarB) >= top)
                                        top = Canvas.GetTop(lastCarB) + lastCarB.Height + lastCarB.Height / 2;

                                    var carBlue = new Car1() { Background = Brushes.Blue, Height = 50, Width = 24 };
                                    Canvas.SetTop(carBlue, top);
                                    Canvas.SetRight(carBlue, 12);
                                    var transform = new RotateTransform(0, 0, 0);
                                    carBlue.RenderTransformOrigin = new Point(0, 0);
                                    carBlue.RenderTransform = transform;
                                    FromWestRoadCanvas.Children.Add(carBlue);
                                    Animator(_currentTrial.Route.Route, carBlue, initAnimationDuration + (top / (lastCarB.Height + lastCarB.Height / 2)), new Random());

                                    _currentTrial.NumberOfVehicle++;
                                    break;
                                case Test.RouteEnum.Red:
                                    var lastCarR = FromNorthRoadCanvas.Children[FromNorthRoadCanvas.Children.Count - 1] as FrameworkElement;
                                    var right = FromNorthRoadCanvas.ActualWidth;
                                    if (Canvas.GetRight(lastCarR) >= right)
                                        right = Canvas.GetRight(lastCarR) + lastCarR.Width + lastCarR.Width / 2;

                                    var carRed = new Car2() { Background = Brushes.Red, Height = 24, Width = 50 };
                                    Canvas.SetRight(carRed, right);
                                    Canvas.SetBottom(carRed, 12);
                                    var transformRed = new RotateTransform(0, 0, 0);
                                    carRed.RenderTransformOrigin = new Point(0.5, 0.5);
                                    carRed.RenderTransform = transformRed;
                                    FromNorthRoadCanvas.Children.Add(carRed);
                                    Animator(_currentTrial.Route.Route, carRed, initAnimationDuration + (right / (lastCarR.Width + lastCarR.Width / 2)), new Random());
                                    _currentTrial.NumberOfVehicle++;
                                    break;
                                case Test.RouteEnum.Green:
                                    var lastCarG = FromSouthRoadCanvas.Children[FromSouthRoadCanvas.Children.Count - 1] as FrameworkElement;
                                    var left = FromSouthRoadCanvas.ActualWidth;
                                    if (Canvas.GetLeft(lastCarG) >= left)
                                        left = Canvas.GetLeft(lastCarG) + lastCarG.Width + lastCarG.Width / 2;

                                    var carGreen = new Car2() { Background = Brushes.Green, Height = 24, Width = 50 };
                                    Canvas.SetLeft(carGreen, left);
                                    Canvas.SetTop(carGreen, 12);
                                    FromSouthRoadCanvas.Children.Add(carGreen);
                                    Animator(_currentTrial.Route.Route, carGreen, initAnimationDuration + (left / (lastCarG.Width + lastCarG.Width / 2)), new Random());
                                    _currentTrial.NumberOfVehicle++;
                                    break;
                                case Test.RouteEnum.Yello:
                                    var lastCarY = FromEastRoadCanvas.Children[FromEastRoadCanvas.Children.Count - 1] as FrameworkElement;
                                    var bottom = FromEastRoadCanvas.ActualHeight;
                                    if (Canvas.GetBottom(lastCarY) >= bottom)
                                        bottom = Canvas.GetBottom(lastCarY) + lastCarY.Height + lastCarY.Height / 2;

                                    var carYellow = new Car1() { Background = Brushes.Yellow, Height = 50, Width = 24 };
                                    Canvas.SetBottom(carYellow, bottom);
                                    //Canvas.SetLeft(carYellow, 12);
                                    FromEastRoadCanvas.Children.Add(carYellow);
                                    Animator(_currentTrial.Route.Route, carYellow, initAnimationDuration + (bottom / (lastCarY.Height + lastCarY.Height / 2)), new Random());
                                    _currentTrial.NumberOfVehicle++;
                                    break;
                                case Test.RouteEnum.Yellow_left:
                                    var lastCarYL = FromEastRoadCanvas2.Children[FromEastRoadCanvas2.Children.Count - 1] as FrameworkElement;
                                    var bottom2 = FromEastRoadCanvas2.ActualHeight;
                                    if (Canvas.GetBottom(lastCarYL) >= bottom2)
                                        bottom2 = Canvas.GetBottom(lastCarYL) + lastCarYL.Height + lastCarYL.Height / 2;

                                    var carYL = new Car1() { Background = Brushes.Yellow, Height = 50, Width = 24 };
                                    Canvas.SetBottom(carYL, bottom2);
                                    Canvas.SetRight(carYL, 0);
                                    carYL.RenderTransformOrigin = new Point(0.5, 0.5);
                                    var transformYL = new RotateTransform(0, 0, 0);
                                    carYL.RenderTransform = transformYL;
                                    FromEastRoadCanvas2.Children.Add(carYL);
                                    Animator(_currentTrial.Route.Route, carYL, initAnimationDuration + (bottom2 / (lastCarYL.Height + lastCarYL.Height / 2)), new Random());
                                    _currentTrial.NumberOfVehicle++;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                });
            });
        }
        private bool SmartTrafficSensor(Canvas road, DependencyProperty dp)
        {
           // var approachingVehicleCount = 0;
           // var approachingVehicleTreshold = 3;
            var approachingRangeFrom = Constants.APPROACHING_VEHICLE_TO_TRAFFIC_RANGE_FROM;

            foreach (FrameworkElement car in road.Children)
            {
                if (dp == Canvas.TopProperty)
                {
                    if (Canvas.GetTop(car) >= approachingRangeFrom && Canvas.GetTop(car) <= _vm.SmartTrafficApproachingVehicleRangeSensorActual)
                        return true;
                       // approachingVehicleCount++;
                }
                else if (dp == Canvas.RightProperty)
                {
                    if (Canvas.GetRight(car) >= approachingRangeFrom && Canvas.GetRight(car) <= _vm.SmartTrafficApproachingVehicleRangeSensorActual)
                        return true;
                        //approachingVehicleCount++;
                }
                else if (dp == Canvas.LeftProperty)
                {
                    if (Canvas.GetLeft(car) >= approachingRangeFrom && Canvas.GetLeft(car) <= _vm.SmartTrafficApproachingVehicleRangeSensorActual)
                        return true;
                        //approachingVehicleCount++;
                }
                else if (dp == Canvas.BottomProperty)
                {
                    if (Canvas.GetBottom(car) >= approachingRangeFrom && Canvas.GetBottom(car) <= _vm.SmartTrafficApproachingVehicleRangeSensorActual)
                        return true;
                        //approachingVehicleCount++;
                }

                //if (approachingVehicleCount >= approachingVehicleTreshold)
                    //return true;
            }

            return false;
        }
       /* private int i = 0;
        private void GoSignalTimer(object obj)
        {
            try
            {
                this.Dispatcher.Invoke(() =>
                {
                var t = obj as Test.Trial;
                    if (t != null)
                    {
                        if (i < t.NumberOfVehicle)
                        {
                            i++;
                            var durationInSeconds = 3.0;
                            var left = 0.0;
                            var right = 0.0;
                            var top = 0.0;
                            var bottom = 0.0;
                            switch (t.Route.Route)
                            {
                                case Test.RouteEnum.Blue:

                                    var carBlue = new Car1() { Background = Brushes.Blue };
                                    Canvas.SetTop(carBlue, FromWestRoadCanvas.ActualHeight);
                                    var transform = new RotateTransform(0, 0, 0);
                                    carBlue.RenderTransformOrigin = new Point(0, 0);
                                    carBlue.RenderTransform = transform;
                                    FromWestRoadCanvas.Children.Add(carBlue);
                                    var randomNum = new Random();
                                    if (randomNum.Next(0,5) != 3)
                                    {
                                        var doubleAnimation = new DoubleAnimation()
                                        {
                                            //From = Canvas.GetTop(carBlue),
                                            To = -(this.ActualHeight + carBlue.ActualHeight),
                                            Duration = new Duration(TimeSpan.FromSeconds(durationInSeconds))
                                        };
                                        //car.BeginAnimation(Canvas.TopProperty, doubleAnimation);
                                        var storyBoard = new Storyboard();
                                        storyBoard.Children.Add(doubleAnimation);
                                        Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(Canvas.TopProperty));
                                        storyBoard.Begin(carBlue);
                                    }
                                    else
                                    {
                                        var firstAnimation = new DoubleAnimation()
                                        {
                                           // From = Canvas.GetTop(carBlue),
                                            To = -50,
                                            BeginTime = TimeSpan.FromMilliseconds(0),
                                            Duration = new Duration(TimeSpan.FromSeconds(durationInSeconds/2))
                                        };
                                        var rotateAnimation = (DoubleAnimation)this.Resources["AngleRotateTransformAnimationKey"];
                                        rotateAnimation.From = 0;
                                        rotateAnimation.To = 90;
                                        rotateAnimation.BeginTime = TimeSpan.FromSeconds(durationInSeconds/2);
                                        rotateAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.250));

                                        var thirdAnimation = new DoubleAnimation()
                                        {
                                            From = 0,
                                            To = -1000,
                                            BeginTime = TimeSpan.FromSeconds((durationInSeconds/2)),
                                            Duration = new Duration(TimeSpan.FromSeconds(3))
                                        };
                                        var storyboard = new Storyboard();
                                        storyboard.Children.Add(firstAnimation);
                                        storyboard.Children.Add(rotateAnimation);
                                        storyboard.Children.Add(thirdAnimation);
                                        Storyboard.SetTargetProperty(firstAnimation, new PropertyPath(Canvas.TopProperty));
                                        //Storyboard.SetTargetProperty(rotateAnimation, new PropertyPath(RotateTransform.AngleProperty));
                                        Storyboard.SetTargetProperty(thirdAnimation, new PropertyPath(Canvas.RightProperty));
                                        storyboard.Begin(carBlue);
                                    }
                                    break;
                                case Test.RouteEnum.Red:
                                    foreach (UIElement car in FromNorthRoadCanvas.Children)
                                    {
                                        var doubleAnimation = new DoubleAnimation()
                                        {
                                            From = Canvas.GetRight(car),
                                            To = -1000,
                                            Duration = new Duration(TimeSpan.FromSeconds(durationInSeconds))
                                        };
                                        durationInSeconds++;
                                        car.BeginAnimation(Canvas.RightProperty, doubleAnimation);
                                    }

                                    break;
                                case Test.RouteEnum.Green:
                                    foreach (UIElement car in FromSouthRoadCanvas.Children)
                                    {
                                        var doubleAnimation = new DoubleAnimation()
                                        {
                                            From = Canvas.GetLeft(car),
                                            To = -1000,
                                            Duration = new Duration(TimeSpan.FromSeconds(durationInSeconds))
                                        };
                                        durationInSeconds++;
                                        car.BeginAnimation(Canvas.LeftProperty, doubleAnimation);
                                    }
                                    break;
                                case Test.RouteEnum.Yello:
                                    foreach (UIElement car in FromEastRoadCanvas.Children)
                                    {
                                        var doubleAnimation = new DoubleAnimation()
                                        {
                                            From = Canvas.GetBottom(car),
                                            To = -1000,
                                            Duration = new Duration(TimeSpan.FromSeconds(durationInSeconds))
                                        };
                                        durationInSeconds++;
                                        car.BeginAnimation(Canvas.BottomProperty, doubleAnimation);
                                    }
                                    break;
                                case Test.RouteEnum.Yellow_left:
                                    foreach (UIElement car in FromEastRoadCanvas.Children)
                                    {
                                        var doubleAnimation = new DoubleAnimation()
                                        {
                                            From = Canvas.GetBottom(car),
                                            To = -1000,
                                            Duration = new Duration(TimeSpan.FromSeconds(durationInSeconds))
                                        };
                                        durationInSeconds++;
                                        car.BeginAnimation(Canvas.BottomProperty, doubleAnimation);
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }

                        var timer = new Timer(GoSignalTimer, obj, 1000, Timeout.Infinite);
                    }
                });
            }
            catch (Exception)
            { }
        }*/
    }
}
