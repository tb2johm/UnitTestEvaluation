using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestEvalualtion.Model;

namespace UnitTestEvalualtion.ViewModel
{
    public class ViewModel : ViewModelBase
    {
        public RelayCommand ChangeCalculusCommand { get; set; }
        public RelayCommand CalculateCommand { get; set; }
        private IModel _myModel;

        private String _varA;
        public String VarA
        {
            get { return _varA; }
            set
            {
                if (_varA == value) return;
                _varA = value;
                Notify("VarA");
                CalculateCommand.RaiseCanExecuteChanged();
            }
        }

        private String _varB;
        public String VarB
        {
            get { return _varB; }
            set
            {
                if (_varB == value) return;
                _varB = value;
                Notify("VarB");
                CalculateCommand.RaiseCanExecuteChanged();
            }
        }

        private String _result;
        public String Result
        {
            get { return _result; }
            set
            {
                if (value == _result) return;
                _result = value;
                Notify("Result");
            }
        }

        private string _calculus;
        public string Calculus
        {
            get { return _calculus; }
            set
            {
                if (value == _calculus) return;
                _calculus = value;
                Notify("Calculus");
            }
        }


        public ViewModel() : this(new Model.Model()) { }

        public ViewModel(IModel myModel)
        {
            _myModel = myModel;
            ChangeCalculusCommand = new RelayCommand(ChangeCalculus);
            CalculateCommand = new RelayCommand(Calculate, CanCalculate);
            Calculus = "+";
        }

        private bool CanCalculate()
        {
            return _myModel.Validate(VarA, VarB);
        }

        private void Calculate()
        {
            switch (Calculus)
            {
                case "+":
                    Result = _myModel.Add(VarA, VarB);
                    break;
                case "-":
                    Result = _myModel.Sub(VarA, VarB);
                    break;
            }
        }


        private void ChangeCalculus()
        {
            switch (Calculus)
            {
                case "+":
                    Calculus = "-";
                    break;
                case "-":
                    Calculus = "+";
                    break;
            }
        }

        
    }
}
