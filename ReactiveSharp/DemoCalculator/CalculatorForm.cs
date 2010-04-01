using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ReactiveSharp;

namespace DemoCalculator
{
    public partial class CalculatorForm : Form
    {
        private class State
        {
            public enum StateTypeEnum
            {
                Left,
                Operator,
                Right,
                Enter,
            }

            public enum StateOperatorEnum
            {
                Add,
                Sub,
                Mul,
                Div,
            }

            public StateTypeEnum StateType { get; set; }
            public int LeftOperand { get; set; }
            public int RightOperand { get; set; }
            public StateOperatorEnum Operator { get; set; }

            public State(StateTypeEnum stateType, int leftOperand, int rightOperand, StateOperatorEnum op)
            {
                this.StateType = stateType;
                this.LeftOperand = leftOperand;
                this.RightOperand = rightOperand;
                this.Operator = op;
            }

            public int Result
            {
                get
                {
                    switch (this.StateType)
                    {
                        case StateTypeEnum.Left:
                            return this.LeftOperand;
                        case StateTypeEnum.Operator:
                            return this.LeftOperand;
                        case StateTypeEnum.Right:
                            return this.RightOperand;
                        case StateTypeEnum.Enter:
                            return this.LeftOperand;
                        default:
                            throw new Exception("Internal Error");
                    }
                }
            }

            private enum InputType
            {
                Number,
                Operator,
                Enter,
                Negative,
            }

            private StateOperatorEnum ToOperator(string input)
            {
                switch (input)
                {
                    case "+": return StateOperatorEnum.Add;
                    case "-": return StateOperatorEnum.Sub;
                    case "*": return StateOperatorEnum.Mul;
                    case "/": return StateOperatorEnum.Div;
                    default:
                        throw new Exception("Internal Error");
                }
            }

            private InputType Check(string input)
            {
                switch (input)
                {
                    case "=":
                        return InputType.Enter;
                    case "+":
                    case "-":
                    case "*":
                    case "/":
                        return InputType.Operator;
                    case "+/-":
                        return InputType.Negative;
                    default:
                        return InputType.Number;
                }
            }

            private State OnNumber(int i)
            {
                switch (this.StateType)
                {
                    case StateTypeEnum.Left:
                        {
                            int number = this.LeftOperand * 10 + i;
                            return new State(StateTypeEnum.Left, number, number, this.Operator);
                        }
                    case StateTypeEnum.Operator:
                        return new State(StateTypeEnum.Right, this.LeftOperand, i, this.Operator);
                    case StateTypeEnum.Right:
                        {
                            int number = this.RightOperand * 10 + i;
                            return new State(StateTypeEnum.Right, this.LeftOperand, number, this.Operator);
                        }
                    case StateTypeEnum.Enter:
                        return new State(StateTypeEnum.Left, i, i, this.Operator);
                    default:
                        return this;
                }
            }

            private State ToNegative()
            {
                switch (this.StateType)
                {
                    case StateTypeEnum.Left:
                        return new State(this.StateType, -this.LeftOperand, this.RightOperand, this.Operator);
                    case StateTypeEnum.Right:
                        return new State(this.StateType, this.LeftOperand, -this.RightOperand, this.Operator);
                    case StateTypeEnum.Operator:
                    case StateTypeEnum.Enter:
                    default:
                        return this;
                }
            }

            private State OnOperator(StateOperatorEnum op)
            {
                switch (this.StateType)
                {
                    case StateTypeEnum.Left:
                    case StateTypeEnum.Operator:
                    case StateTypeEnum.Enter:
                        return new State(StateTypeEnum.Operator, this.LeftOperand, this.RightOperand, op);
                    case StateTypeEnum.Right:
                        if (op == StateOperatorEnum.Div && this.RightOperand == 0)
                        {
                            return this;
                        }
                        else
                        {
                            return this.OnEnter().OnOperator(op);
                        }
                    default:
                        return this;
                }
            }

            private State OnEnter()
            {
                switch (this.StateType)
                {
                    case StateTypeEnum.Left:
                        return this;
                    case StateTypeEnum.Operator:
                    case StateTypeEnum.Right:
                    case StateTypeEnum.Enter:
                        {
                            int number = 0;
                            switch (this.Operator)
                            {
                                case StateOperatorEnum.Add:
                                    number = this.LeftOperand + this.RightOperand;
                                    break;
                                case StateOperatorEnum.Sub:
                                    number = this.LeftOperand - this.RightOperand;
                                    break;
                                case StateOperatorEnum.Mul:
                                    number = this.LeftOperand * this.RightOperand;
                                    break;
                                case StateOperatorEnum.Div:
                                    if (this.RightOperand == 0)
                                    {
                                        return this;
                                    }
                                    else
                                    {
                                        number = this.LeftOperand / this.RightOperand;
                                        break;
                                    }
                            }
                            return new State(StateTypeEnum.Enter, number, this.RightOperand, this.Operator);
                        }
                    default:
                        return this;
                }
            }

            public State Transform(string input)
            {
                switch (Check(input))
                {
                    case InputType.Enter:
                        return this.OnEnter();
                    case InputType.Operator:
                        return this.OnOperator(ToOperator(input));
                    case InputType.Negative:
                        return this.ToNegative();
                    default:
                        return this.OnNumber(int.Parse(input));
                }
            }
        }

        public CalculatorForm()
        {
            InitializeComponent();
            this.Controls
                .Cast<Control>()
                .Where(c => c.GetType() == typeof(Button))
                .AttachEvent<EventArgs>("Click")
                .Select(e => (e.V1 as Control).Text)
                .Aggregate(
                    new State(State.StateTypeEnum.Left, 0, 0, State.StateOperatorEnum.Add),
                    (s, c) => s.Transform(c)
                    )
                .Listen(s =>
                    {
                        textResult.Text = s.Result.ToString();
                    });
        }
    }
}
