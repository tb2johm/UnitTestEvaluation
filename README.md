UnitTestEvaluation
==================

This is a project to test/evaluate the C# unit test, using MVVM

I've made a very stupid example program, a calculator. The program is designed using the
MVVM pattern. There is a View, a ViewModel and a Model.

Of course the View is responsible for presenting the data.
The Model is the one the does the actual calculations,
and the ViewModel is what connects them. 

First of all the program creates the View, which in turn creates an instance of the
ViewModel (that would be the <wm:ViewModel x:key="ViewModel"> line in the View.xaml)
The view then binds to Properties and Commands in the ViewModel.

The ViewModel extends the ViewModelBase which is more or less a helper class that 
implements the INotifyPropertyChanged interface.
So all Properties that is expected to be used by the View will call the 
Notify(#propertyName#) function (located in the ViewModelBase class) that invokes the
PropertyChanged event on the class. This will update the values in the View.

All Commands in the ViewModel are Properties of the type RelayCommand which
also is just a helper class that helps creating the Commands.
The contructor to the RelayCommand takes an Action (which is called when the 
Command is executed), and - optionally - a function that decides whether or not
the command can be executed (sets the Enabled property on the bounded Control).

The ViewModel also creates an instance of the Model. In a project this small
it would almost make more sence not to have any model at all and just add or subtract
the numbers in the ViewModel. However, this project is created to evaluate how to
work with the unit test in VS, so don't case about how stupid the model is.
